using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                ConnectSQL.Connect();

                if (!multiplos)
                {
                    if (id_contatoSelecionado != null)
                    {
                        ConnectSQL.Update(txtNumero.Text, txtRev.Text, comboOS.Text, comboTipo.Text, txtObs.Text, user);

                        MessageBox.Show("Atualizado!");

                    }
                    else
                    {
                        ConnectSQL.Insert(txtNumero.Text, txtRev.Text, comboOS.Text, comboTipo.Text, txtObs.Text, user);

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


                id_contatoSelecionado = null;
                txtNumero.Text = String.Empty;
                txtRev.Text = String.Empty;
                txtObs.Text = String.Empty;
                comboOS.Text = String.Empty;
                comboTipo.Text = String.Empty;

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
                        ConnectSQL.Delete(id_contatoSelecionado);

                        MessageBox.Show("Deletado!");

                        id_contatoSelecionado = null;
                        txtNumero.Text = String.Empty;
                        txtRev.Text = String.Empty;
                        txtObs.Text = String.Empty;
                        comboOS.Text = String.Empty;
                        comboTipo.Text = String.Empty;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormProcurar procurar = new FormProcurar();
            procurar.Show();
            txtNumero.Text = procurar.numero;
            txtRev.Text = procurar.rev;
            comboOS.Text = procurar.os;
            comboTipo.Text = procurar.tipo;
            txtObs.Text = procurar.obs;

        }
    }
}

