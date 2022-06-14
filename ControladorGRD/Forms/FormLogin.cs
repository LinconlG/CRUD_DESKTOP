using System;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormLogin : Form
    {
        
        public bool pass = false;
        string user;
        string filePath;
        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            try
            {
                filePath = String.Format("{0}Resources\\database.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                carregardb(filePath);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.login(txtDS.Text, txtUN.Text, txtPW.Text, txtDB.Text);
                user = txtUsuario.Text;
                
                //conexao = new MySqlConnection(data_source);
                //conexao.Open();

                ConnectSQL.cmd.CommandText = $"SELECT * FROM tb_login WHERE usuario=@usuario AND senha=@senha";
                ConnectSQL.cmd.Parameters.Clear();
                ConnectSQL.cmd.Parameters.AddWithValue("@usuario", SqlDbType.VarChar).Value = $"{txtUsuario.Text}";
                ConnectSQL.cmd.Parameters.AddWithValue("@senha", SqlDbType.VarChar).Value = $"{sha256_hash(txtSenha.Text)}";
                ////ConnectSQL.//cmd.Prepare();

                SqlDataAdapter sda = new SqlDataAdapter(ConnectSQL.cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                ConnectSQL.cmd.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    pass = true;
                    this.Close();
                }
                else
                {
                    ConnectSQL.cmd.Parameters.Clear();
                    MessageBox.Show("Usuário/senha incorreta. Tente novamente.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConnectSQL.conexao.Close();
                
            }

        }

        public string User()
        {
            return user;
        }

        private void carregardb(string filepath)
        {
            if (File.Exists(filepath))
            {
                string[] lines = File.ReadAllLines(filepath);
                txtDS.Text = lines[0];
                txtDB.Text = lines[3];
                txtUN.Text = lines[1];
                txtPW.Text = lines[2];
            }
            else
            {
                File.Create(filepath);
                carregardb(filepath);
            }
        }

        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
