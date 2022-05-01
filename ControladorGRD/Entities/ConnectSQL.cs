using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ControladorGRD.Forms;
using System.Windows.Forms;

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

        public static void InsertGRD(ListView listaDoc, ListView listaResp, string user)
        {
            cmd.CommandText = "INSERT INTO grd_dados (datagrd, docs, resps, usuariogrd)" +
                                " VALUES (@data, @docs, @resps, @usuario)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd"));

            //--------------------------------------------------------
            string docs = "[\"";
            int k = 0;
            foreach (ListViewItem item in listaDoc.Items)
            {
                if (k == 0)
                {
                    docs += item.Text;
                }
                else
                {
                    docs += "\", \"" + item.Text;
                }
                k++;
            }
            docs += "\"]";

            cmd.Parameters.AddWithValue("@docs", docs);


            //--------------------------------------------------------

            k = 0;
            string resps = "[\"";
            foreach (ListViewItem item in listaResp.Items)
            {
                if (k == 0)
                {
                    resps += item.Text;
                }
                else
                {
                    resps += "\", \"" + item.Text;
                }
                k++;
            }
            resps += "\"]";

            cmd.Parameters.AddWithValue("@resps", resps);
            //-------------------------------------------------------

            cmd.Parameters.AddWithValue("@usuario", user);

            cmd.Prepare();
            cmd.ExecuteNonQuery();


        }

        public static string InsertEmissao(ListView listaDocs)
        {
            cmd.CommandText = "SELECT grd from grd_dados ORDER BY grd desc limit 1";
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string id = id = reader.GetString(0);
            reader.Close();

            foreach (ListViewItem item in listaDocs.Items)
            {
                cmd.CommandText = $"SELECT id, rev from documento WHERE numero='{item.Text}'";

                reader = cmd.ExecuteReader();
                reader.Read();
                cmd.CommandText = "INSERT INTO emissaogrd (dataEmissao, idDoc, revDoc, idgrd) " +
                    $"VALUES(@data, @idDoc, @docRev, @grd)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@idDoc", reader.GetString(0));
                cmd.Parameters.AddWithValue("@docRev", reader.GetString(1));
                cmd.Parameters.AddWithValue("@grd", id);
                reader.Close();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }

            return id;
        }

        public static void InsertRec(ListView listaResp)
        {
            cmd.CommandText = "SELECT grd from grd_dados ORDER BY grd desc limit 1";
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string id = id = reader.GetString(0);
            reader.Close();

            foreach (ListViewItem item in listaResp.Items)
            {
                cmd.CommandText = "INSERT INTO recebimento (grdId, nome) " +
                    $"VALUES(@grd, @nome)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@grd", id);
                cmd.Parameters.AddWithValue("@nome", item.Text);

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
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

        public static string[] Values(int id) 
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

        public static void InsertResp(string responsavel)
        {
            cmd.CommandText = "INSERT INTO responsavel (nome)" +
                    " VALUES (@nome)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", responsavel);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static MySqlDataReader ExbirResp()
        {
            cmd.CommandText = "SELECT * FROM responsavel ORDER BY nome";

            cmd.Prepare();
            return cmd.ExecuteReader();
        }

        public static MySqlDataReader ExibirGRD()
        {
            cmd.CommandText = "select dataEmissao, grd_dados.grd, documento.numero , emissaogrd.revDoc, grd_dados.resps, grd_dados.usuariogrd " +
                "from documento join grd_dados join emissaogrd " +
                "on emissaogrd.idGrd = grd_dados.grd AND emissaogrd.idDoc = documento.id" +
                " ORDER BY grd_dados.grd DESC, documento.numero";

            cmd.Prepare();
            return cmd.ExecuteReader();
        }

        public static MySqlDataReader ExibirDoc()
        {
            ConnectSQL.cmd.CommandText = "SELECT dataRegistro, numero, rev, os, obs, usuario " +
                        "from documento ORDER BY id DESC";

            cmd.Prepare();
            return cmd.ExecuteReader();
        }

        public static MySqlDataReader AddDoc(string numero)
        {
            ConnectSQL.cmd.CommandText = $"SELECT numero, rev, os, obs" +
            $" FROM documento WHERE numero='{numero}'";

            cmd.Prepare();
            return cmd.ExecuteReader();

        }

        public static MySqlDataReader AddResp(string nome)
        {
            ConnectSQL.cmd.CommandText = $"SELECT nome" +
            $" FROM responsavel WHERE nome='{nome}'";

            cmd.Prepare();
            return cmd.ExecuteReader();

        }

        public static MySqlDataReader ExibirRecebimentoDocs(string grd)
        {
            cmd.CommandText = $"SELECT docs, resps, datagrd from grd_dados WHERE grd_dados.grd='{grd}'";

            cmd.Prepare();

            return cmd.ExecuteReader();
        }

    }
}
