using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ControladorGRD.Forms;

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

        public static void Insert(string txtNumero, string txtRev, string comboOS, string txtObs, string user)
        {
            cmd.CommandText = "INSERT INTO documento (numero, rev, os, obs, dataRegistro, usuario)" +
                                " VALUES (@numero, @rev, @os, @obs, @dataRegistro, @usuario)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@numero", txtNumero);
            cmd.Parameters.AddWithValue("@rev", txtRev);
            cmd.Parameters.AddWithValue("@os", comboOS);
            cmd.Parameters.AddWithValue("@obs", txtObs);
            cmd.Parameters.AddWithValue("@dataRegistro", Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")));
            cmd.Parameters.AddWithValue("@usuario", user);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void Update(int id, string txtNumero, string txtRev, string comboOS, string txtObs, string user)
        {
            cmd.CommandText = "UPDATE documento " +
                              "SET numero=numero, rev=@rev, os=@os, obs=@obs, usuario=@usuario" +
                               " WHERE id=@id";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@numero", txtNumero);
            cmd.Parameters.AddWithValue("@rev", txtRev);
            cmd.Parameters.AddWithValue("@os", comboOS);
            cmd.Parameters.AddWithValue("@obs", txtObs);
            cmd.Parameters.AddWithValue("@usuario", user);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void Delete(int? id)
        {
            cmd.CommandText = $"DELETE FROM documento WHERE id='{id}'";

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static int? SearchID(string numero)
        {
            cmd.CommandText = $"SELECT id FROM documento WHERE numero='{numero}'";

            cmd.Prepare();
            MySqlDataReader dr = ConnectSQL.cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                int? id = Convert.ToInt32(dr.GetValue(0));
                dr.Close();
                return id;
            }
            else
            {
                return null;
            }

        }

        public static string[] Values(int id)// como acessar as variaveis desse metodo?
        {
            string[] dados = new string[5];

            ConnectSQL.cmd.CommandText = $"SELECT * FROM documento WHERE id='{id}'";

            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            while (reader.Read())
            {

                dados[0] = reader.GetValue(1).ToString();

                dados[1] = reader.GetValue(2).ToString();

                dados[2] = reader.GetValue(3).ToString();

                dados[3] = reader.GetValue(4).ToString();

                dados[4] = reader.GetValue(5).ToString();
            }

            ConnectSQL.cmd.Prepare();
            reader.Close();

            return dados;
        }

    }
}
