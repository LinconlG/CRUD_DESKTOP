using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;
using System.Globalization;

namespace ControladorGRD.Forms
{
    public partial class FormCadastroDoc : Form
    {

        private int? id_contatoSelecionado = null;
        private bool multiplos = false;
        private bool revisao = false;
        public string user;

        public FormCadastroDoc(string user)
        {
            InitializeComponent();
            txtData.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
            this.user = user;
        }

        public FormCadastroDoc()
        {
            InitializeComponent();
            txtData.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text == "" || txtRev.Text == "" || comboOS.Text == "")
                {
                    MessageBox.Show("Campo vazio");
                }
                else
                {
                    ConnectSQL.Connect();

                    if (!multiplos)
                    {
                        if (id_contatoSelecionado != null)
                        {
                            ConnectSQL.Update((int)id_contatoSelecionado, txtNumero.Text, txtRev.Text, comboOS.Text, txtObs.Text, user);

                            MessageBox.Show("Atualizado!");

                        }
                        else
                        {
                            ConnectSQL.Insert(txtNumero.Text, txtRev.Text, comboOS.Text, txtObs.Text, user);

                            MessageBox.Show("Salvo!");
                        }
                    }
                    else
                    {

                        MessageBox.Show("aqui abriria a janela!");
                        //trabalhar com a planilha excel
                        /*if (revisao)
                        {

                        }
                        else
                        {

                        }*/

                    }


                    limpar();
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

        private void button1_Click(object sender, EventArgs e)
        {
            multiplos = true;
        }

        private void checkRev_CheckedChanged(object sender, EventArgs e)
        {
            revisao = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_contatoSelecionado != null)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que quer excluir?", "Exclusão", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ConnectSQL.Connect();
                        ConnectSQL.Delete(id_contatoSelecionado);

                        MessageBox.Show("Deletado!");

                        limpar();
                    }
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            FormProcurar procurar = new FormProcurar(this);
            procurar.Show();    
        }

        public void Preencher(int? id, string numero, string rev, string os, string obs, string data)
        {

            txtCod.Text = id.ToString();
            id_contatoSelecionado = id;
            txtNumero.Text = numero;
            txtRev.Text = rev;
            comboOS.Text = os;
            txtObs.Text = obs;
            DateTime d = DateTime.Parse(data);
            txtData.Text = $"{d.Day}/{d.Month}/{d.Year}";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar()
        {
            id_contatoSelecionado = null;
            txtNumero.Text = String.Empty;
            txtRev.Text = String.Empty;
            txtObs.Text = String.Empty;
            comboOS.Text = String.Empty;
            txtCod.Text = String.Empty;
            txtData.Text = String.Empty;
        }
    }
}

