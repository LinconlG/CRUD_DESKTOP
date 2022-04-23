using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;
using System.Globalization;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ControladorGRD.Forms
{
    public partial class FormCadastroDoc : Form
    {

        private int? id_contatoSelecionado = null;
        private bool multiplos = false;
        public string user;
        object[,] dados;
        string[] numeros, revisoes, oss, obss;
        int qtdlinhas;

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

                if ((txtNumero.Text == "" || txtRev.Text == "" || comboOS.Text == "") && (multiplos == false))
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
                        if (!checkRev.Checked)
                        {
                            for (int i = 0; i < qtdlinhas; i++)
                            {
                                ConnectSQL.Insert(numeros[i], revisoes[i], oss[i], obss[i], user);
                            }
                            MessageBox.Show("Salvo!");
                        }
                        else
                        {
                            for (int i = 0; i < qtdlinhas; i++)
                            {
                                ConnectSQL.Update((int)ConnectSQL.SearchID(numeros[i]),numeros[i], revisoes[i], oss[i], obss[i], user);
                            }
                            MessageBox.Show("Atualizado!");
                        }

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

        private void btnMultiplos_Click(object sender, EventArgs e)
        {
            try
            {
                multiplos = true;
                using (OpenFileDialog arquivoDialogo = new OpenFileDialog())
                {
                    arquivoDialogo.InitialDirectory = "Downloads";
                    arquivoDialogo.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    arquivoDialogo.FilterIndex = 2;
                    arquivoDialogo.RestoreDirectory = true;

                    if (arquivoDialogo.ShowDialog() == DialogResult.OK)
                    {

                        var fileStream = arquivoDialogo.OpenFile();


                        var planilha = new Excel.Application();
                        var wb = planilha.Workbooks.Open($@"{arquivoDialogo.FileName}", ReadOnly: true);
                        Excel._Worksheet workSheet = (Excel.Worksheet)wb.ActiveSheet;
                        var ws = wb.Worksheets[1];
                        int linhas = 0;
                        checarCelulas(ref linhas, ws);
                        linhas = linhas - 1;
                        dynamic r = ws.Range["A2"].Resize[linhas, 4];
                        dados = r.Value;
                        qtdlinhas = linhas;
                        numeros = new string[linhas];
                        revisoes = new string[linhas];
                        oss = new string[linhas];
                        obss = new string[linhas];

                        for (int i = 1; i <= linhas; i++)
                        {
                            for (int j = 1; j <= 4; j++)
                            {
                                string text = Convert.ToString(dados[i, j]);
                                switch (j)
                                {
                                    case 1:
                                        numeros[i - 1] = text;
                                        break;
                                    case 2:
                                        revisoes[i - 1] = text;
                                        break;
                                    case 3:
                                        oss[i - 1] = text;
                                        break;
                                    case 4:
                                        obss[i - 1] = text;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        labelMultiplo.Text = arquivoDialogo.FileName;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_contatoSelecionado != null)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ConnectSQL.Connect();
                        ConnectSQL.Delete(id_contatoSelecionado);

                        MessageBox.Show("Cadastro excluído!");

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
            multiplos = false;
            labelMultiplo.Text = "Nenhum arquivo selecionado";
        }

        private void checarCelulas(ref int linhas, dynamic ws)
        {
            dynamic cell;

            for (int l = 0; l <= linhas; l++)
            {
                cell = ws.Cells[l+1, 1].Value;

                if (cell == null)
                {
                    break;
                }
                else
                {
                    linhas++;
                }
            }
        }
    }
}

