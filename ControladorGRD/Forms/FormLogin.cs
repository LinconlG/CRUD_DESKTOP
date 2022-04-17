using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ControladorGRD.Forms
{
    public partial class FormLogin : Form
    {
        private MySqlConnection conexao;
        private string data_source = "datasource=localhost;username=root;password=12345;database=db_login";
        public bool pass = false;
        MySqlCommand cmd = new MySqlCommand();
        string user;

        public FormLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            
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
                cmd.Parameters.AddWithValue("@senha", $"{txtSenha.Text}");
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
    }
}
