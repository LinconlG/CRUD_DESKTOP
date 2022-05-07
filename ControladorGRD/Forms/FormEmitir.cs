using System;
using System.Windows.Forms;
using ControladorGRD.Entities;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;
using System.Printing;
using System.Globalization;
using System.Resources;

namespace ControladorGRD.Forms
{
    public partial class FormEmitir : Form
    {
        string user;
        string planilhaPath;
        string grdEmitida;

        public FormEmitir(string user, FormCadastroDoc cadastroDoc)
        {
            InitializeComponent();
            txtData.Text = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
            carregarDoc();
            carregarResp();
            carregarCombo(comboResp);
            this.user = user;
            planilhaPath = String.Format("{0}Resources\\GRD.xlsx", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            labelqtd.Text = "0 documento(s) na lista";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDoc.Items.Count < 22)
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
                            labelqtd.Text = $"{listDoc.Items.Count} documento(s) na lista";
                        }
                    }
                    txtNumero.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("A lista de emissão atingiu a cota maxima de 22 documentos");
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

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDoc.Items.Count == 0)
                {
                    MessageBox.Show("Lista de documentos está vazia");
                }
                else if (listResp.Items.Count == 0)
                {
                    MessageBox.Show("Lista de responsaveis está vazia");
                }
                else
                {
                    ConnectSQL.Connect();
                    ConnectSQL.InsertGRD(listDoc, listResp, user);
                    grdEmitida = ConnectSQL.InsertEmissao(listDoc);
                    ConnectSQL.InsertRec(listResp, listDoc);

                    ImprimirGRD();

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
            listDoc.FullRowSelect = true;
            
            listDoc.Columns.Add("Numero", 120, HorizontalAlignment.Left);
            listDoc.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
            listDoc.Columns.Add("OS", 90, HorizontalAlignment.Left);
            listDoc.Columns.Add("OBS/Legenda", 250, HorizontalAlignment.Left);
        }

        private void carregarResp()
        {
            listResp.View = View.Details;
            listResp.GridLines = true;
            listResp.FullRowSelect = true;
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
                labelqtd.Text = $"{listDoc.Items.Count} documento(s) na lista";
            }
        }

        private void removerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listResp.SelectedItems)
            {
                listResp.Items.Remove(item);
            }
        }

        private void ImprimirGRD()
        {
            Cursor.Current = Cursors.WaitCursor;
            string pathtxt = String.Format("{0}Resources\\Localgrd.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            string local = File.ReadAllText($"{pathtxt}");
            var planilha = new Microsoft.Office.Interop.Excel.Application();
            var pastaTrabalho = planilha.Workbooks.Open($@"{planilhaPath}", ReadOnly: true);
            planilha.DisplayAlerts = false;
            var aba = pastaTrabalho.Worksheets[1];
            int qtd = listResp.Items.Count;
            int count = 0;

            foreach (ListViewItem resp in listResp.Items)
            {

                aba.Cells[4, 3] = grdEmitida;
                aba.Cells[5, 3] = resp.Text;
                aba.Cells[5, 10] = DateTime.Now.ToString("dd/MM/yy");
                aba.Cells[4, 12] = $"Pag {count + 1}/{qtd}";

                int i = 9;
                foreach (ListViewItem doc in listDoc.Items)
                {
                    aba.Cells[i, 1] = doc.SubItems[0].Text;
                    aba.Cells[i, 5] = doc.SubItems[1].Text;
                    aba.Cells[i, 6] = doc.SubItems[3].Text;
                    aba.Cells[i, 11] = doc.SubItems[2].Text ;
                    i++;
                }
                aba.Cells[32, 3] = txtObs.Text;
                count++;
                if (count < qtd)
                {
                    aba.Copy(pastaTrabalho.Sheets[planilha.Sheets.Count]);
                    aba = pastaTrabalho.Sheets[1];
                }
            }
            Cursor.Current = Cursors.Default;
            using (SaveFileDialog janela = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                janela.InitialDirectory = $@"{local}";
                janela.RestoreDirectory = true;
                aba = pastaTrabalho.Worksheets[1];
                janela.FileName = grdEmitida;

                if (janela.ShowDialog() == DialogResult.OK)
                {
                    aba.PageSetup.Orientation = PageOrientation.Landscape;
                    pastaTrabalho.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, $@"{janela.FileName}");

                }

            }


            pastaTrabalho.Close();
            planilha.Quit();
        }
    }
}
