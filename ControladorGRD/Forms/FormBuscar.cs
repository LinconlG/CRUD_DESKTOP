using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using ControladorGRD.Entities;
using System.Printing;
using System.IO;
using System.Data;

namespace ControladorGRD.Forms
{
    public partial class FormBuscar : Form
    {
        DataTable dt;

        public FormBuscar()
        {
            InitializeComponent();
            lista.MultiSelect = false;

            ClassPage.NRPP = 30;
            ClassPage.Page = 1;

            comboBox.Text = "GRD";

            btnRelat.Enabled = false;
        }


        private void btnBuscarDocGrd_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPage.Page = 1;
                if (comboBox.Text == "GRD")
                {
                    ConnectSQL.Connect();

                    if (checkPend.Checked)
                    {
                        
                        ConnectSQL.cmd.CommandText = $"SELECT emissaogrd.dataEmissao, grd_dados.grd, documento.numero, emissaogrd.revDoc, recebimento.nome " +
                            $"FROM documento join emissaogrd on emissaogrd.idDoc = documento.id join grd_dados on emissaogrd.idgrd = grd_dados.grd join recebimento on emissaogrd.idgrd = recebimento.grdId " +
                        "WHERE recebimento.entregue='0'" +
                        $" AND documento.numero LIKE '%{txtBuscarDocGrd.Text}%' ORDER BY grd_dados.grd DESC, documento.numero";

                        ConnectSQL.cmd.CommandType = CommandType.Text;

                        SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
                        dt = new DataTable();
                        x.Fill(dt);

                        ClassPage.DadosListView(dt, lista, comboBox.Text);
                        Pagina(ClassPage.Page, ClassPage.TotalPages);
                    }
                    else
                    {
                        if (checkBox.Checked)
                        {
                            ConnectSQL.cmd.CommandText = $"select emissaogrd.dataEmissao, grd_dados.grd, documento.numero , emissaogrd.revDoc, grd_dados.resps, grd_dados.usuariogrd " +
                            $"from documento join grd_dados join emissaogrd on emissaogrd.idGrd = grd_dados.grd AND emissaogrd.idDoc = documento.id " +
                            $"WHERE documento.numero LIKE '%{txtBuscarDocGrd.Text}%' ORDER BY grd_dados.grd DESC";
                        }
                        else
                        {
                            ConnectSQL.cmd.CommandText = $"select emissaogrd.dataEmissao, grd_dados.grd, documento.numero , emissaogrd.revDoc, grd_dados.resps, grd_dados.usuariogrd " +
                            $"from documento join grd_dados join emissaogrd on emissaogrd.idGrd = grd_dados.grd AND emissaogrd.idDoc = documento.id " +
                            $"WHERE grd_dados.grd LIKE '%{txtBuscarDocGrd.Text}%' ORDER BY grd_dados.grd DESC";
                        }

                        ConnectSQL.cmd.CommandType = CommandType.Text;

                        SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
                        dt = new DataTable();
                        x.Fill(dt);

                        ClassPage.DadosListView(dt, lista, comboBox.Text);
                        Pagina(ClassPage.Page, ClassPage.TotalPages);
                    }
                }
                else
                {
                    ConnectSQL.Connect();

                    ConnectSQL.cmd.CommandText = "SELECT dataRegistro, numero, rev, os, obs, usuario " +
                        $"FROM documento WHERE numero LIKE '%{txtBuscarDocGrd.Text}%' OR os LIKE '%{txtBuscarDocGrd.Text}%' OR obs LIKE '%{txtBuscarDocGrd.Text}%'";

                    ConnectSQL.cmd.CommandType = CommandType.Text;

                    SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
                    dt = new DataTable();
                    x.Fill(dt);

                    ClassPage.DadosListView(dt, lista, comboBox.Text);
                    Pagina(ClassPage.Page, ClassPage.TotalPages);
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

        private void carregarGRD()
        {
            try
            {
                lista.Columns.Clear();
                lista.View = View.Details;
                lista.GridLines = true;
                lista.FullRowSelect = true;

                lista.Columns.Add("Data", 90, HorizontalAlignment.Left);
                lista.Columns.Add("GRD", 60, HorizontalAlignment.Left);
                lista.Columns.Add("Numero", 140, HorizontalAlignment.Left);
                lista.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
                lista.Columns.Add("Responsaveis", 220, HorizontalAlignment.Left);
                lista.Columns.Add("Usuario", 100, HorizontalAlignment.Left);

                ConnectSQL.cmd.CommandText = "select dataEmissao, grd_dados.grd, documento.numero, emissaogrd.revDoc, grd_dados.resps, grd_dados.usuariogrd " +
                                    "from documento join grd_dados join emissaogrd " +
                                    "on emissaogrd.idGrd = grd_dados.grd on emissaogrd.idDoc = documento.id" +
                                    " ORDER BY grd_dados.grd DESC, documento.numero";

                ConnectSQL.cmd.CommandType = CommandType.Text;

                SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
                dt = new DataTable();
                x.Fill(dt);

                ClassPage.DadosListView(dt, lista, comboBox.Text);
                Pagina(ClassPage.Page, ClassPage.TotalPages);

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
            lista.Columns.Clear();
            lista.View = View.Details;
            lista.GridLines = true;
            lista.FullRowSelect = true;

            lista.Columns.Add("Data", 90, HorizontalAlignment.Left);
            lista.Columns.Add("Numero", 140, HorizontalAlignment.Left);
            lista.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
            lista.Columns.Add("OS", 100, HorizontalAlignment.Left);
            lista.Columns.Add("OBS/Legenda", 220, HorizontalAlignment.Left);
            lista.Columns.Add("Usuario", 100, HorizontalAlignment.Left);

            ConnectSQL.cmd.CommandText = $"SELECT dataRegistro, numero, rev, os, obs, usuario FROM documento ORDER BY id DESC";
            ConnectSQL.cmd.CommandType = CommandType.Text;

            SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
            dt = new DataTable();
            x.Fill(dt);

            ClassPage.DadosListView(dt, lista, comboBox.Text);
            Pagina(ClassPage.Page, ClassPage.TotalPages);

        }

        private void txtBuscarDocGrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarDocGrd_Click(this, e);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.Text == "Documentos")
            {
                carregarDoc();
                checkPend.Hide();
                checkBox.Hide();

            }
            else
            {
                carregarGRD();
                checkBox.Show();
                checkPend.Show();

            }
        }

        private void listaGRD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (comboBox.Text == "GRD")
            {
                ListView.SelectedListViewItemCollection item_selecionado = lista.SelectedItems;
                new FormResps(item_selecionado[0].SubItems[1].Text).ShowDialog();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (comboBox.Text == "GRD")
            {
                checkPend.Checked = false;
                carregarGRD();
            }
            else
            {
                carregarDoc();
            }
        }

        private void checkPend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkPend.Checked)
                {
                    checkBox.Checked = true;
                    checkBox.Enabled = false;
                    btnRelat.Enabled = true;
                    lista.Columns.Clear();
                    lista.View = View.Details;
                    lista.GridLines = true;
                    lista.FullRowSelect = true;

                    lista.Columns.Add("Data", 70, HorizontalAlignment.Left);
                    lista.Columns.Add("GRD", 60, HorizontalAlignment.Left);
                    lista.Columns.Add("Numero", 200, HorizontalAlignment.Left);
                    lista.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
                    lista.Columns.Add("Responsável Pendente", 200, HorizontalAlignment.Left);
                    lista.Columns.Add("Usuario", 100, HorizontalAlignment.Left);

                    ConnectSQL.cmd.CommandText = "SELECT emissaogrd.dataEmissao, grd_dados.grd, documento.numero, emissaogrd.revDoc, recebimento.nome, grd_dados.usuariogrd " +
                        "FROM documento JOIN emissaogrd on emissaogrd.idDoc = documento.id JOIN grd_dados on emissaogrd.idgrd = grd_dados.grd JOIN recebimento on emissaogrd.idgrd = recebimento.grdId " +
                        "WHERE recebimento.entregue='0'" +
                        " ORDER BY grd_dados.grd DESC, documento.numero";

                    ConnectSQL.cmd.CommandType = CommandType.Text;
                    SqlDataAdapter x = new SqlDataAdapter(ConnectSQL.cmd);
                    dt = new DataTable();
                    x.Fill(dt);

                    ClassPage.DadosListView(dt, lista, comboBox.Text);
                    Pagina(ClassPage.Page, ClassPage.TotalPages);
                }
                else
                {
                    checkBox.Checked = false;
                    checkBox.Enabled = true;
                    btnRelat.Enabled = false;
                    carregarGRD();
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

        private void btnRelat_Click(object sender, EventArgs e)
        {
            try
            {
                string pathtxt = String.Format("{0}Resources\\Localgrd.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                string local = File.ReadAllText($"{pathtxt}");

                Cursor.Current = Cursors.WaitCursor;
                string planilhaPath = String.Format("{0}Resources\\relatorio template.xlsx", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
                var planilha = new Microsoft.Office.Interop.Excel.Application();
                var pastaTrabalho = planilha.Workbooks.Open($@"{planilhaPath}", ReadOnly: true);
                var aba = pastaTrabalho.Worksheets[1];
                planilha.DisplayAlerts = false;

                int i = 2;

                ClassPage.Page = 1;

                for (int n = 0; n < ClassPage.TotalPages; n++)
                {
                    foreach (ListViewItem doc in lista.Items)
                    {
                        aba.Cells[i, 1] = doc.SubItems[0].Text;
                        aba.Cells[i, 2] = doc.SubItems[1].Text;
                        aba.Cells[i, 3] = doc.SubItems[2].Text;
                        aba.Cells[i, 4] = doc.SubItems[3].Text;
                        aba.Cells[i, 5] = doc.SubItems[4].Text;
                        i++;
                    }

                    btnProx_Click(this, e);
                }

                Cursor.Current = Cursors.Default;
                using (SaveFileDialog janela = new SaveFileDialog() { Filter = "xlsx file|*.xlsx", ValidateNames = true })
                {
                    janela.InitialDirectory = $@"{local}";
                    janela.RestoreDirectory = true;
                    aba = pastaTrabalho.Worksheets[1];
                    janela.FileName = "pendentes";

                    if (janela.ShowDialog() == DialogResult.OK)
                    {
                        pastaTrabalho.SaveAs(janela.FileName);
                    }
                }
                pastaTrabalho.Close();
                planilha.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//classpage = 1

        private void btnProx_Click(object sender, EventArgs e)
        {
            if (ClassPage.Page < ClassPage.TotalPages)
            {
                ClassPage.Page++;
                if (comboBox.Text == "GRD")
                {
                    carregarGRD();
                }
                else
                {
                    carregarDoc();
                }
            }
        }
        private void Pagina(int pag1, int pag2)
        {
            labelPage.Text = $"Página {pag1} de {pag2}";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (ClassPage.Page > 1)
            {
                ClassPage.Page--;
                if (comboBox.Text == "GRD")
                {
                    carregarGRD();
                }
                else
                {
                    carregarDoc();
                }
            }
        }

        private void txtPag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                if ((System.Text.RegularExpressions.Regex.IsMatch(txtPag.Text, "^[0-9]+$")))
                {
                    if (int.Parse(txtPag.Text) <= ClassPage.TotalPages && int.Parse(txtPag.Text) > 0)
                    {
                        ClassPage.Page = int.Parse(txtPag.Text);
                        if (comboBox.Text == "GRD")
                        {
                            carregarGRD();
                        }
                        else
                        {
                            carregarDoc();
                        }
                    }
                }
            }
        }
    }
}
