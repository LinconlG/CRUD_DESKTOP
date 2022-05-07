using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormAlterar : Form
    {
        int grd;
        string planilhaPath;
        public FormAlterar()
        {
            InitializeComponent();
            txtData.Enabled = false;
            listResp.MultiSelect = false;
            listDoc.MultiSelect = false;
            planilhaPath = String.Format("{0}Resources\\GRD.xlsx", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            txtObs.Enabled = false;
        }

        private void txtGRD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                try
                {
                    contextMenuStrip1.Enabled = true;
                    contextMenuStrip2.Enabled = true;
                    carregarGeral();
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
        private void carregarListas(string numero)
        {
            listDoc.Columns.Clear();
            listDoc.View = View.Details;
            listDoc.GridLines = true;
            listDoc.FullRowSelect = true;

            btnImprimir.Enabled = true;
            txtObs.Enabled = true;

            listDoc.Columns.Add("Numero", 250, HorizontalAlignment.Left);
            listDoc.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
            listDoc.Columns.Add("OS", 90, HorizontalAlignment.Left);
            listDoc.Columns.Add("OBS/Legenda", 250, HorizontalAlignment.Left);
            
            ConnectSQL.cmd.CommandText = $"SELECT numero, rev, os, obs FROM documento WHERE numero='{numero}'";

            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] row =
                {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3)
                };
                var linha_listview = new ListViewItem(row);
                listDoc.Items.Add(linha_listview);
            }
            reader.Close();
        }


        public void carregarResps(int id)
        {
            
            listResp.Clear();
            listResp.Columns.Clear();
            listResp.View = View.Details;
            listResp.GridLines = true;
            listResp.FullRowSelect = true;

            listResp.Columns.Add("Nome", 150, HorizontalAlignment.Left);

            ConnectSQL.cmd.CommandText = $"SELECT nome FROM recebimento WHERE grdId='{id}' AND entregue='0'";

            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            if (reader.HasRows)
            {
                btnCancelar.Enabled = true;
                while (reader.Read())
                {
                    string[] row =
                    {
                    reader.GetString(0)
                };
                    var linha_listview = new ListViewItem(row);
                    listResp.Items.Add(linha_listview);
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("GRD já recebida por todos os responsáveis");
                btnCancelar.Enabled = false;
                contextMenuStrip1.Enabled = false;
                contextMenuStrip2.Enabled = false;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                if (listDoc.Items.Count == 0)
                {
                    MessageBox.Show("Não há GRD selecionada");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja cancelar?", "Exclusão", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        ConnectSQL.Connect();
                        int pend;
                        MySqlDataReader reader;

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
                        ConnectSQL.cmd.Prepare();
                        ConnectSQL.cmd.ExecuteNonQuery();

                        ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}'";
                        ConnectSQL.cmd.Prepare();
                        ConnectSQL.cmd.ExecuteNonQuery();

                        ConnectSQL.cmd.CommandText = $"DELETE FROM recebimento WHERE grdId='{grd}'";
                        ConnectSQL.cmd.Prepare();
                        ConnectSQL.cmd.ExecuteNonQuery();

                        Cursor.Current = Cursors.Default;

                        limpar();
                        txtGRD.Focus();
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

        private void limpar()
        {
            btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            txtObs.Enabled = false;
            txtData.Text = String.Empty;
            txtGRD.Text = String.Empty;
            listDoc.Clear();
            listResp.Clear();
        }

        private void listResp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection resp_selecionado = listResp.SelectedItems;
            FormRecebimento receb = new FormRecebimento(resp_selecionado[0].SubItems[0].Text, grd, this, listDoc);
            receb.Show();
        }

        private void carregarGeral()
        {
            grd = Convert.ToInt32(txtGRD.Text);
            listDoc.Clear();
            listResp.Clear();
            ConnectSQL.Connect();
            string[] documentos;
            string[] responsaveis;

            MySqlDataReader reader = ConnectSQL.ExibirRecebimentoDocs(txtGRD.Text);
            if (!reader.HasRows)
            {
                MessageBox.Show("GRD não encontrada");
                btnImprimir.Enabled = false;
                btnCancelar.Enabled = false;
                txtObs.Enabled = false;
            }
            else
            {
                string[] row = new string[3];

                while (reader.Read())
                {
                    row[0] = reader.GetString(0);
                    row[1] = reader.GetString(1);
                    row[2] = reader.GetString(2);
                }
                reader.Close();

                txtData.Text = row[2].Substring(0, 10);

                if (row[0] != null)
                {
                    row[0] = row[0].Substring(2, row[0].Length - 3).Replace("\"", "").Replace(",", "").Replace(" ", "/");
                    row[1] = row[1].Substring(2, row[1].Length - 3).Replace("\"", "").Replace(",", "").Replace(" ", "/");
                }

                documentos = row[0].Split('/');
                responsaveis = row[1].Split('/');

                for (int i = 0; i < documentos.Length; i++)
                {
                    carregarListas(documentos[i]);
                }

                carregarResps(grd);
            }
        }

        private void removerDocumentoDaGRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDoc.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja remover este documento?", "Remoção", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        ListView.SelectedListViewItemCollection doc_selecionado = listDoc.SelectedItems;

                        ConnectSQL.Connect();

                        ConnectSQL.cmd.CommandText = $"SELECT docs FROM grd_dados WHERE grd='{grd}'";

                        ConnectSQL.cmd.Prepare();
                        MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();
                        reader.Read();
                        string linha = reader.GetString(0).Substring(2, reader.GetString(0).Length - 3).Replace("\"", "").Replace(",", "").Replace(" ", "/");
                        reader.Close();
                        string[] numeros = linha.Split('/');
                        int i;
                        for (i = 0; i < numeros.Length; i++)
                        {
                            if (numeros[i] == doc_selecionado[0].SubItems[0].Text)
                            {
                                ConnectSQL.cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{numeros[i]}'";
                                MySqlDataReader reader1 = ConnectSQL.cmd.ExecuteReader();
                                reader1.Read();
                                int pend = Int32.Parse(reader1.GetString(0));
                                reader1.Close();
                                ConnectSQL.cmd.CommandText = $"UPDATE documento SET pend='{pend - 1}' WHERE numero='{numeros[i]}'";
                                ConnectSQL.cmd.Prepare();
                                ConnectSQL.cmd.ExecuteNonQuery();
                                numeros = numeros.Where(val => val != $"{numeros[i]}").ToArray();
                                break;
                            }
                        }
                        if (numeros.Length == 0)
                        {
                            ConnectSQL.cmd.CommandText = $"DELETE FROM grd_dados WHERE grd='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"DELETE FROM recebimento WHERE grdId='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            MessageBox.Show("Documento removido, GRD cancelada!");
                            limpar();

                        }
                        else
                        {
                            ConnectSQL.cmd.CommandText = $"UPDATE grd_dados SET docs=@docs WHERE grd='{grd}'";
                            ConnectSQL.cmd.Parameters.Clear();

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

                            ConnectSQL.cmd.Parameters.AddWithValue("@docs", docs);
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"SELECT id FROM documento WHERE numero='{doc_selecionado[0].SubItems[0].Text}'";
                            ConnectSQL.cmd.Prepare();
                            MySqlDataReader id = ConnectSQL.cmd.ExecuteReader();
                            id.Read();
                            ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}' AND idDoc='{id.GetString(0)}'";
                            id.Close();
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            MessageBox.Show("Documento removido com sucesso!");

                            carregarGeral();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um item");
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
        private void ImprimirGRD()
        {
            Cursor.Current = Cursors.WaitCursor;
            string pathtxt = String.Format("{0}Resources\\Localgrd.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            string local = File.ReadAllText($"{pathtxt}");
            var planilha = new Microsoft.Office.Interop.Excel.Application();
            var pastaTrabalho = planilha.Workbooks.Open($@"{planilhaPath}", ReadOnly: true);
            planilha.DisplayAlerts = false;
            var aba = pastaTrabalho.Worksheets[1];
            int qtd;
            int count = 0;
            

            ConnectSQL.Connect();
            ConnectSQL.cmd.CommandText = $"Select count(nome) from recebimento where grdId='{grd}'";
            ConnectSQL.cmd.Prepare();
            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();
            reader.Read();
            string[] nomes = new string[reader.GetInt32(0)];
            reader.Close();

            ConnectSQL.cmd.CommandText = $"SELECT nome FROM recebimento WHERE grdId='{grd}'";
            ConnectSQL.cmd.Prepare();
            reader = ConnectSQL.cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                nomes[i] = reader.GetString(0);
                i++;
            }

            qtd = nomes.Length;

            foreach (string resp in nomes)
            {

                aba.Cells[4, 3] = grd.ToString();
                aba.Cells[5, 3] = resp;
                aba.Cells[5, 10] = DateTime.Now.ToString("dd/MM/yy");
                aba.Cells[4, 12] = $"Pag {qtd-count}/{qtd}";

                i = 9;
                foreach (ListViewItem doc in listDoc.Items)
                {
                    aba.Cells[i, 1] = doc.SubItems[0].Text;
                    aba.Cells[i, 5] = doc.SubItems[1].Text;
                    aba.Cells[i, 6] = doc.SubItems[3].Text;
                    aba.Cells[i, 11] = doc.SubItems[2].Text;
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
                janela.FileName = grd.ToString();

                if (janela.ShowDialog() == DialogResult.OK)
                {
                    aba.PageSetup.Orientation = PageOrientation.Landscape;
                    pastaTrabalho.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, $@"{janela.FileName}");

                }

            }


            pastaTrabalho.Close();
            planilha.Quit();
        }


        private void removerResponsavelDaGRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listResp.SelectedItems.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja remover este responsavel?", "Remoção", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        ListView.SelectedListViewItemCollection res_selecionado = listResp.SelectedItems;

                        ConnectSQL.Connect();

                        ConnectSQL.cmd.CommandText = $"SELECT resps FROM grd_dados WHERE grd='{grd}'";

                        ConnectSQL.cmd.Prepare();
                        MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();
                        reader.Read();
                        string linha = reader.GetString(0).Substring(2, reader.GetString(0).Length - 3).Replace("\"", "").Replace(",", "").Replace(" ", "/");
                        reader.Close();
                        string[] resps = linha.Split('/');
                        int i;
                        for (i = 0; i < resps.Length; i++)
                        {
                            if (resps[i] == res_selecionado[0].SubItems[0].Text)
                            {
                                foreach (ListViewItem doc in listDoc.Items)
                                {
                                    ConnectSQL.cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{doc.SubItems[0].Text}'";
                                    MySqlDataReader reader2 = ConnectSQL.cmd.ExecuteReader();
                                    reader2.Read();
                                    int pend = Int32.Parse(reader2.GetString(0));
                                    reader2.Close();
                                    ConnectSQL.cmd.CommandText = $"UPDATE documento SET pend='{pend - 1}' WHERE numero='{doc.SubItems[0].Text}'";
                                    ConnectSQL.cmd.Prepare();
                                    ConnectSQL.cmd.ExecuteNonQuery();
                                }
                                resps = resps.Where(val => val != $"{resps[i]}").ToArray();
                                break;
                            }
                        }
                        if (resps.Length == 0)
                        {
                            ConnectSQL.cmd.CommandText = $"DELETE FROM grd_dados WHERE grd='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"DELETE FROM recebimento WHERE grdId='{grd}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            MessageBox.Show("Responsável removido, GRD cancelada!");
                            limpar();

                        }
                        else
                        {
                            ConnectSQL.cmd.CommandText = $"UPDATE grd_dados SET resps=@resps WHERE grd='{grd}'";
                            ConnectSQL.cmd.Parameters.Clear();

                            string respos = "[\"";
                            int k = 0;
                            foreach (var item in resps)
                            {
                                if (k == 0)
                                {
                                    respos += item;
                                }
                                else
                                {
                                    respos += "\", \"" + item;
                                }
                                k++;
                            }
                            respos += "\"]";

                            ConnectSQL.cmd.Parameters.AddWithValue("@resps", respos);
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            ConnectSQL.cmd.CommandText = $"DELETE FROM recebimento WHERE grdId='{grd}' AND nome='{res_selecionado[0].SubItems[0].Text}'";
                            ConnectSQL.cmd.Prepare();
                            ConnectSQL.cmd.ExecuteNonQuery();

                            MessageBox.Show("Responsável removido com sucesso!");

                            carregarGeral();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um item");
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
            limpar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ImprimirGRD();
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
