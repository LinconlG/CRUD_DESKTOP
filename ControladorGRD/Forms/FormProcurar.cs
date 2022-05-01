using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormProcurar : Form
    {
        public int? id_contatoSelecionado = null;
        FormCadastroDoc FormCadastroDoc;
        public string numero, rev, os, obs, data;

        string[] dados = new string[5];

        public FormProcurar(FormCadastroDoc FormCadastroDoc)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormCadastroDoc = FormCadastroDoc;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();

                id_contatoSelecionado = ConnectSQL.SearchID(txtProcurar.Text.ToUpper());


                if (id_contatoSelecionado != null)
                {
                    dados = ConnectSQL.Values((int)id_contatoSelecionado);
                    numero = dados[0];
                    rev = dados[1];
                    os = dados[2];
                    obs = dados[3];
                    data = dados[4];

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
