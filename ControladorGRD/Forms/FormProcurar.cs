using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormProcurar : Form
    {
        public int? id_contatoSelecionado = null;
        FormCadastroDoc FormCadastroDoc;
        public string numero, rev, os, obs, data;
        TextBox txtNumero;
        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, e);
            }
        }

        TextBox txtRev;
        string[] dados = new string[5];

        public FormProcurar(FormCadastroDoc FormCadastroDoc, TextBox txtRev, TextBox txtNumero)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormCadastroDoc = FormCadastroDoc;
            this.txtRev = txtRev;
            this.txtNumero = txtNumero;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();
                string numero = txtProcurar.Text;

                while (numero.StartsWith(" "))
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }
                while (numero.EndsWith(" "))
                {
                    numero = numero.Substring(0, numero.Length - 1);
                }

                id_contatoSelecionado = ConnectSQL.SearchID(numero.ToUpper());


                if (id_contatoSelecionado != null)
                {
                    dados = ConnectSQL.Values((int)id_contatoSelecionado);
                    numero = dados[0];
                    rev = dados[1];
                    os = dados[2];
                    obs = dados[3];
                    data = dados[4];

                    ConnectSQL.cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{numero}'";
                    SqlDataReader reader = ConnectSQL.cmd.ExecuteReader();
                    reader.Read();
                    int pend = reader.GetInt32(0);
                    reader.Close();
                    if (pend > 0)
                    {
                        txtRev.Enabled = false;
                        txtNumero.Enabled = false;   
                    }
                    else
                    {
                        txtRev.Enabled = true;
                        txtNumero.Enabled = true;
                    }

                    FormCadastroDoc.Preencher(id_contatoSelecionado, numero, rev, os, obs, data);

                    //se o id for encontrado, colocar os valores nas caixas de textos
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Não encontrado");
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
    }
}
