using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControladorGRD.Entities
{
    static class ConnectSQL
    {
        public static MySqlConnection conexao { get; set; }
        public static MySqlCommand cmd = new MySqlCommand();

        private static string data_source = "datasource=localhost;username=root;password=12345;database=db_documentos";

        public static void Connect()
        {
            conexao = new MySqlConnection(data_source);
            conexao.Open();


            cmd.Connection = conexao;
        }

        public static void Insert(string txtNumero, string txtRev, string comboOS, string comboTipo, string txtObs, string user)
        {
            cmd.CommandText = "INSERT INTO documento (numero, rev, os, tipo, obs, dataRegistro, usuario)" +
                                " VALUES (@numero, @rev, @os, @tipo, @obs, @dataRegistro, @usuario)";

            cmd.Parameters.AddWithValue("@numero", txtNumero);
            cmd.Parameters.AddWithValue("@rev", txtRev);
            cmd.Parameters.AddWithValue("@os", comboOS);
            cmd.Parameters.AddWithValue("@tipo", comboTipo);
            cmd.Parameters.AddWithValue("@obs", txtObs);
            cmd.Parameters.AddWithValue("@dataRegistro", Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")));
            cmd.Parameters.AddWithValue("@usuario", user);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void Update(string txtNumero, string txtRev, string comboOS, string comboTipo, string txtObs, string user)
        {
            cmd.CommandText = "UPDATE documento " +
                              "SET numero=numero, rev=@rev, os=@os, tipo=@tipo, obs=@obs, dataRegistro=@dataRegistro, usuario=@usuario" +
                               " WHERE id=@id";

            cmd.Parameters.AddWithValue("@numero", txtNumero);
            cmd.Parameters.AddWithValue("@rev", txtRev);
            cmd.Parameters.AddWithValue("@os", comboOS);
            cmd.Parameters.AddWithValue("@tipo", comboTipo);
            cmd.Parameters.AddWithValue("@obs", txtObs);
            cmd.Parameters.AddWithValue("@dataRegistro", Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")));
            cmd.Parameters.AddWithValue("@usuario", user);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void Delete(int? id)
        {
            cmd.CommandText = $"DELETE * FROM documento WHERE id='{id}'";

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static int? SearchID(string numero)
        {
            cmd.CommandText = $"SELECT id FROM documento WHERE numero='{numero}'";

            cmd.Prepare();
            MySqlDataReader dr = ConnectSQL.cmd.ExecuteReader();
            dr.Read();
            int? id = Convert.ToInt32(dr.GetValue(0));
            dr.Close();
            return id;
        }

        public static void Values(int? id)// como acessar as variaveis desse metodo?
        {
            string numero, rev, os, tipo, obs;

            ConnectSQL.cmd.CommandText = $"SELECT * FROM documento WHERE id='{id}'";

            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            while (reader.Read())
            {

                numero = reader.GetValue(1).ToString();

                rev = reader.GetValue(2).ToString();

                os = reader.GetValue(3).ToString();

                tipo = reader.GetValue(4).ToString();

                obs = reader.GetValue(5).ToString();
            }
            ConnectSQL.cmd.Prepare();
            ConnectSQL.cmd.ExecuteNonQuery();
            reader.Close();

        }

    }
}
