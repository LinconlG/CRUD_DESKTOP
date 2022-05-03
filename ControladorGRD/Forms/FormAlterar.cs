using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormAlterar : Form
    {
        int grd;

        public FormAlterar()
        {
            InitializeComponent();
            txtData.Enabled = false;
            listResp.MultiSelect = false;
            listDoc.MultiSelect = false;
        }

        private void txtGRD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                try
                {
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

            listDoc.Columns.Add("Numero", 250, HorizontalAlignment.Left);
            listDoc.Columns.Add("Revisão", 60, HorizontalAlignment.Left);

            ConnectSQL.cmd.CommandText = $"SELECT numero, rev FROM documento WHERE numero='{numero}'";

            MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

            while (reader.Read())
            {
                string[] row =
                {
                    reader.GetString(0),
                    reader.GetString(1)
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
                limpar();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            try
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
                            ConnectSQL.cmd.CommandText = $"SELECT pend FROM document WHERE numero='{doc.SubItems[0].Text}'";
                            reader = ConnectSQL.cmd.ExecuteReader();
                            reader.Read();
                            pend = Int32.Parse(reader.GetString(0));
                            reader.Close();
                            ConnectSQL.cmd.CommandText = $"UPDATE documento SET pend='{pend - 1}' WHERE numero='{doc.SubItems[0].Text}'";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                ConnectSQL.conexao.Close();
            }
        }

        private void removerResponsavelDaGRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
