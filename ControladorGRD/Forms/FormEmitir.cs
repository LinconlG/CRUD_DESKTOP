using System;
using System.Windows.Forms;
using ControladorGRD.Entities;
using MySql.Data.MySqlClient;

namespace ControladorGRD.Forms
{
    public partial class FormEmitir : Form
    {
        string user;
        public FormEmitir(string user)
        {
            InitializeComponent();
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            carregarDoc();
            carregarResp();
            carregarCombo(comboResp);
            this.user = user;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();
                ListViewItem linha_listview = new ListViewItem();

                MySqlDataReader reader = ConnectSQL.AddDoc(txtNumero.Text);
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Documento não cadastrado");
                }
                else
                {
                    while (reader.Read())
                    {
                        string[] row = {

                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    };

                        linha_listview = new ListViewItem(row);

                    }

                    if (listDoc.FindItemWithText(txtNumero.Text) != null)
                    {
                        MessageBox.Show("Documento já foi adicionado");
                    }
                    else
                    {
                        listDoc.Items.Add(linha_listview);
                    }
                }
                txtNumero.Text = String.Empty;
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

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDoc.Items.Count == 0)
                {
                    MessageBox.Show("Lista de documentos está vazia");
                }
                else if(listResp.Items.Count == 0)
                {
                    MessageBox.Show("Lista de responsaveis está vazia");
                }
                else
                {
                    ConnectSQL.Connect();
                    ConnectSQL.InsertGRD(listDoc, listResp, user);
                    ConnectSQL.InsertEmissao(listDoc);
                    MessageBox.Show("Emitido");
                    listDoc.Items.Clear();
                    listResp.Items.Clear();
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

        private void carregarDoc()
        {

            listDoc.View = View.Details;
            listDoc.GridLines = true;
            listDoc.Columns.Add("Numero", 120, HorizontalAlignment.Left);
            listDoc.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
            listDoc.Columns.Add("OS", 90, HorizontalAlignment.Left);
            listDoc.Columns.Add("OBS/Legenda", 250, HorizontalAlignment.Left);
        }

        private void carregarResp()
        {
            listResp.View = View.Details;
            listResp.GridLines = true;
            listResp.Columns.Add("Nome", 150, HorizontalAlignment.Left);
        }

        private void comboResp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                try
                {
                    ConnectSQL.Connect();
                    ListViewItem linha_listview = new ListViewItem();

                    MySqlDataReader reader = ConnectSQL.AddResp(comboResp.Text);
                    if (reader.HasRows == false)
                    {
                        MessageBox.Show("Responsavel não cadastrado");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            string[] row = {

                                reader.GetString(0)
                            };

                            linha_listview = new ListViewItem(row);

                        }

                        if (listResp.FindItemWithText(comboResp.Text) != null)
                        {
                            MessageBox.Show("Responsavel já foi adicionado");
                        }
                        else
                        {
                            listResp.Items.Add(linha_listview);
                        }
                    }
                    comboResp.Text = String.Empty;
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

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                btnAdicionar_Click(this, e);
            }
        }

        //excluir docs e resp com botao direito

        private void carregarCombo(ComboBox combo)
        {
            try
            {
                ConnectSQL.Connect();

                MySqlDataReader reader = ConnectSQL.ExbirResp();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0)
                    };
                    combo.Items.Add(row[0]);
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

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listDoc.SelectedItems)
            {
                listDoc.Items.Remove(item);
            }
        }

        private void removerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listResp.SelectedItems)
            {
                listDoc.Items.Remove(item);
            }
        }

    }
}
