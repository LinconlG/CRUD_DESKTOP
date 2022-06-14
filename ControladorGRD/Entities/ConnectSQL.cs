using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControladorGRD.Forms;
using System.Windows.Forms;
using System.Data;

namespace ControladorGRD.Entities
{
    static class ConnectSQL
    {
        public static SqlConnection conexao { get; set; }
        public static SqlCommand cmd = new SqlCommand();
        public static string ds, us, ps, db;
        public static void login(string a, string b, string p, string d)
        {
            ds = a;
            us = b;
            ps = p;
            db = d;

            conexao = new SqlConnection($@"Data Source={ds};Initial Catalog={db};User ID={us};Password={ps}");
            conexao.Open();


            cmd.Connection = conexao;
        }
        
        public static void Connect()
        {
            conexao = new SqlConnection($@"Data Source={ds};Initial Catalog=db_documentos;User ID={us};Password={ps}");
            conexao.Open();


            cmd.Connection = conexao;
        }
        public static void Insert(string txtNumero, string txtRev, string comboOS, string txtObs, string user)
        {
            cmd.CommandText = "INSERT INTO documento (numero, rev, os, obs, dataRegistro, usuario)" +
                                " VALUES (@numero, @rev, @os, @obs, @dataRegistro, @usuario)";

            DocParam(txtNumero, txtRev, comboOS, txtObs, user);

            ////cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void InsertGRD(ListView listaDoc, ListView listaResp, string user)
        {
            cmd.CommandText = "INSERT INTO grd_dados (datagrd, docs, resps, usuariogrd)" +
                                " VALUES (@data, @docs, @resps, @usuario)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@data", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");

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

            cmd.Parameters.AddWithValue("@docs", SqlDbType.VarChar).Value = docs;


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

            cmd.Parameters.AddWithValue("@resps", SqlDbType.VarChar).Value = resps;
            //-------------------------------------------------------

            cmd.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = user;

            ////cmd.Prepare();
            cmd.ExecuteNonQuery();


        }
        public static string InsertEmissao(ListView listaDocs)
        {
            cmd.CommandText = "SELECT grd from grd_dados ORDER BY grd desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();

            foreach (ListViewItem item in listaDocs.Items)
            {
                cmd.CommandText = $"SELECT id, rev from documento WHERE numero='{item.Text}'";

                reader = cmd.ExecuteReader();
                reader.Read();
                cmd.CommandText = "INSERT INTO emissaogrd (dataEmissao, idDoc, revDoc, idgrd) " +
                    $"VALUES(@data, @idDoc, @docRev, @grd)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@data", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@idDoc", SqlDbType.Int).Value = reader.GetInt32(0);
                cmd.Parameters.AddWithValue("@docRev", SqlDbType.VarChar).Value = reader.GetString(1);
                cmd.Parameters.AddWithValue("@grd", SqlDbType.Int).Value = id;
                reader.Close();
                ////cmd.Prepare();
                cmd.ExecuteNonQuery();
            }

            return id.ToString();
        }
        public static void InsertRec(ListView listaResp, ListView listadoc)
        {
            cmd.CommandText = "SELECT grd from grd_dados ORDER BY grd desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();
            int pend;
            foreach (ListViewItem item in listaResp.Items)
            {
                foreach (ListViewItem doc in listadoc.Items)
                {
                    cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{doc.SubItems[0].Text}'";
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    pend = reader.GetInt32(0);
                    reader.Close();
                    cmd.CommandText = "UPDATE documento " +
                              $"SET pend='{pend + 1}' WHERE numero='{doc.SubItems[0].Text}'";
                    ////cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "INSERT INTO recebimento (grdId, nome) " +
                    $"VALUES(@grd, @nome)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@grd", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@nome", SqlDbType.VarChar).Value = item.Text;

                ////cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
        public static void Update(int id, string txtNumero, string txtRev, string comboOS, string txtObs, string user)
        {
            cmd.CommandText = "UPDATE documento " +
                              "SET numero=@numero, rev=@rev, os=@os, obs=@obs, usuario=@usuario" +
                               " WHERE id=@id";

            cmd.Parameters.Clear();
            DocParam(txtNumero, txtRev, comboOS, txtObs, user);
            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

            ////cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void Delete(int? id)
        {
            cmd.CommandText = $"DELETE FROM documento WHERE id='{id}'";

            ////cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static int? SearchID(string numero)
        {
            cmd.CommandText = $"SELECT id FROM documento WHERE numero='{numero}'";

            SqlDataReader dr = ConnectSQL.cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                int? id = Convert.ToInt32(dr.GetValue(0));
                dr.Close();
                return id;
            }
            else
            {
                dr.Close();
                return null;
            }

        }
        public static string[] Values(int id)
        {
            string[] dados = new string[5];

            ConnectSQL.cmd.CommandText = $"SELECT * FROM documento WHERE id='{id}'";

            SqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            while (reader.Read())
            {

                dados[0] = reader.GetValue(1).ToString();

                dados[1] = reader.GetValue(2).ToString();

                dados[2] = reader.GetValue(3).ToString();

                dados[3] = reader.GetValue(4).ToString();

                dados[4] = reader.GetValue(5).ToString();
            }

            reader.Close();

            return dados;
        }
        public static void InsertResp(string responsavel)
        {
            cmd.CommandText = "INSERT INTO responsavel (nome)" +
                    " VALUES (@nome)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", SqlDbType.VarChar).Value = responsavel;

            //cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public static void CancelarGRD(ListView listResp, ListView listDoc, int grd)
        {

            int pend;
            SqlDataReader reader;

            foreach (ListViewItem resp in listResp.Items)
            {
                foreach (ListViewItem doc in listDoc.Items)
                {
                    ConnectSQL.cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{doc.SubItems[0].Text}'";
                    reader = ConnectSQL.cmd.ExecuteReader();
                    reader.Read();
                    pend = Int32.Parse(reader.GetString(0));
                    reader.Close();
                    ConnectSQL.cmd.CommandText = $"UPDATE documento SET pend='{pend - 1}' WHERE numero='{doc.SubItems[0].Text}'";
                    ConnectSQL.cmd.ExecuteNonQuery();
                }
            }

            ConnectSQL.cmd.CommandText = $"DELETE FROM grd_dados WHERE grd='{grd}'";
            //ConnectSQL.//cmd.Prepare();
            ConnectSQL.cmd.ExecuteNonQuery();

            ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}'";
            //ConnectSQL.//cmd.Prepare();
            ConnectSQL.cmd.ExecuteNonQuery();

            ConnectSQL.cmd.CommandText = $"DELETE FROM recebimento WHERE grdId='{grd}'";
            //ConnectSQL.//cmd.Prepare();
            ConnectSQL.cmd.ExecuteNonQuery();
        }
        public static void AtualizarDocGRD(int id, TextBox txtNumero)
        {
            int[] grds = new int[0];
            int i = 0;
            string linha;
            SqlDataReader reader;
            SqlDataReader reader2;
            cmd.CommandText = $"SELECT numero FROM documento WHERE id='{id}'";
            //cmd.Prepare();
            reader2 = cmd.ExecuteReader();
            reader2.Read();
            if (reader2.GetString(0) == txtNumero.Text)
            {
                reader2.Close();
            }
            else
            {
                reader2.Close();
                cmd.CommandText = $"SELECT idgrd FROM emissaogrd WHERE idDoc='{id}'";
                //cmd.Prepare();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Array.Resize<int>(ref grds, grds.Length + 1);
                    grds[i] = reader.GetInt32(0);
                    i++;
                }
                reader.Close();

                for (i = 0; i < grds.Length; i++)
                {
                    cmd.CommandText = $"SELECT docs FROM grd_dados WHERE grd='{grds[i]}'";

                    //cmd.Prepare();
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    linha = reader.GetString(0).Substring(2, reader.GetString(0).Length - 3).Replace("\"", "").Replace(",", "").Replace(" ", "/");
                    reader.Close();
                    string[] numeros = linha.Split('/');

                    for (int j = 0; j < numeros.Length; j++)
                    {
                        cmd.CommandText = $"SELECT id FROM documento WHERE numero='{numeros[j]}'";
                        //cmd.Prepare();
                        reader2 = cmd.ExecuteReader();
                        reader2.Read();

                        if (reader2.GetInt32(0) == id)
                        {
                            reader2.Close();

                            numeros[j] = txtNumero.Text.ToUpper();

                            string docs = "[\"";
                            int k = 0;
                            foreach (var item in numeros)
                            {
                                if (k == 0)
                                {
                                    docs += item;
                                }
                                else
                                {
                                    docs += "\", \"" + item;
                                }
                                k++;
                            }

                            docs += "\"]";

                            cmd.CommandText = $"UPDATE grd_dados SET docs=@docs WHERE grd='{grds[i]}'";

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@docs", SqlDbType.VarChar).Value = docs;
                            //cmd.Prepare();

                            cmd.ExecuteNonQuery();


                            break;
                        }
                        reader2.Close();
                    }
                }

            }
        }
        public static SqlDataReader ExbirResp()
        {
            cmd.CommandText = "SELECT * FROM responsavel ORDER BY nome";

            ////cmd.Prepare();
            return cmd.ExecuteReader();
        }
        public static SqlDataReader ExibirGRD()
        {
            cmd.CommandText = "select dataEmissao, grd_dados.grd, documento.numero , emissaogrd.revDoc, grd_dados.resps, grd_dados.usuariogrd " +
                "from documento join grd_dados join emissaogrd " +
                "on emissaogrd.idGrd = grd_dados.grd AND emissaogrd.idDoc = documento.id" +
                " ORDER BY grd_dados.grd DESC, documento.numero";

            ////cmd.Prepare();
            return cmd.ExecuteReader();
        }
        public static SqlDataReader ExibirPend()
        {
            cmd.CommandText = "SELECT emissaogrd.dataEmissao, grd_dados.grd, documento.numero, emissaogrd.revDoc, recebimento.nome FROM documento join grd_dados join emissaogrd join recebimento " +
                        "WHERE emissaogrd.idgrd = grd_dados.grd AND emissaogrd.idDoc = documento.id AND emissaogrd.idgrd = recebimento.grdId AND recebimento.entregue='0'" +
                        " ORDER BY grd_dados.grd DESC, documento.numero";

            ////cmd.Prepare();
            return cmd.ExecuteReader();
        }
        public static SqlDataReader ExibirDoc()
        {
            ConnectSQL.cmd.CommandText = "SELECT dataRegistro, numero, rev, os, obs, usuario " +
                        "from documento ORDER BY id DESC";

            ////cmd.Prepare();
            return cmd.ExecuteReader();
        }
        public static SqlDataReader ExibirCadastro()
        {
            ConnectSQL.cmd.CommandText = "SELECT id, dataRegistro, numero, rev, os, obs " +
                        "from documento ORDER BY id DESC";

            ////cmd.Prepare();
            return cmd.ExecuteReader();
        }
        public static SqlDataReader AddDoc(string numero)
        {
            ConnectSQL.cmd.CommandText = $"SELECT numero, rev, os, obs" +
            $" FROM documento WHERE numero='{numero}'";

            ////cmd.Prepare();
            return cmd.ExecuteReader();

        }
        public static SqlDataReader AddResp(string nome)
        {
            ConnectSQL.cmd.CommandText = $"SELECT nome" +
            $" FROM responsavel WHERE nome='{nome}'";

            ////cmd.Prepare();
            return cmd.ExecuteReader();

        }
        public static SqlDataReader ExibirRecebimentoDocs(string grd)
        {
            cmd.CommandText = $"SELECT docs, resps, datagrd from grd_dados WHERE grd_dados.grd='{grd}'";

            ////cmd.Prepare();

            return cmd.ExecuteReader();
        }

        private static void DocParam(string txtNumero, string txtRev, string comboOS, string txtObs, string user)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@numero", SqlDbType.VarChar).Value = txtNumero.ToUpper();
            cmd.Parameters.AddWithValue("@rev", SqlDbType.VarChar).Value = txtRev.ToUpper();
            cmd.Parameters.AddWithValue("@os", SqlDbType.VarChar).Value = comboOS;
            cmd.Parameters.AddWithValue("@obs", SqlDbType.Text).Value = txtObs.ToUpper();
            cmd.Parameters.AddWithValue("@dataRegistro", SqlDbType.Date).Value = Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = user;
        }


    }
}
