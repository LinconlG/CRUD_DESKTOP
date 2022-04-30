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
        }

        private void txtGRD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                try
                {
                    grd = Convert.ToInt32(txtGRD.Text);
                    listDoc.Clear();
                    listResp.Clear();
                    ConnectSQL.Connect();
                    string[] documentos;
                    string[] responsaveis;

                    MySqlDataReader reader = ConnectSQL.ExibirRecebimentoDocs(txtGRD.Text);
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
                    ConnectSQL.Connect();

                    ConnectSQL.cmd.CommandText = $"DELETE FROM grd_dados WHERE grd='{grd}'";
                    ConnectSQL.cmd.Prepare();
                    ConnectSQL.cmd.ExecuteNonQuery();

                    ConnectSQL.cmd.CommandText = $"DELETE FROM emissaogrd WHERE idgrd='{grd}'";
                    ConnectSQL.cmd.Prepare();
                    ConnectSQL.cmd.ExecuteNonQuery();

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
            FormRecebimento receb = new FormRecebimento(resp_selecionado[0].SubItems[0].Text, grd, this);
            receb.Show();
        }
    }
}
