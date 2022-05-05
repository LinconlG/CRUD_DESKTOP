using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ControladorGRD.Forms
{
    public partial class FormLogin : Form
    {
        private MySqlConnection conexao;
        private string data_source;
        public bool pass = false;
        MySqlCommand cmd = new MySqlCommand();
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
                data_source = $"datasource={txtDS.Text};username={txtUN.Text};password={txtPW.Text};database={txtDB.Text}";
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
                user = txtUsuario.Text;
                conexao = new MySqlConnection(data_source);
                conexao.Open();

                cmd.Connection = conexao;
                cmd.CommandText = $"SELECT * FROM login WHERE usuario=@usuario AND senha=@senha";
                cmd.Parameters.AddWithValue("@usuario", $"{txtUsuario.Text}");
                cmd.Parameters.AddWithValue("@senha", $"{sha256_hash(txtSenha.Text)}");
                cmd.Prepare();

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                
                cmd.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    pass = true;
                    this.Close();
                }
                else
                {
                    cmd.Parameters.Clear();
                    MessageBox.Show("Usuário/senha incorreta. Tente novamente.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                
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
