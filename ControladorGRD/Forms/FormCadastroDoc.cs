using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;
using System.Globalization;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Text.RegularExpressions;

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
        string filePath;

        public FormCadastroDoc(string user)
        {
            InitializeComponent();
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.user = user;
            Assembly asm = Assembly.GetExecutingAssembly();
            string a = System.AppDomain.CurrentDomain.BaseDirectory;
            filePath = String.Format("{0}Resources\\listaOS.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));
            carregarOS(filePath);

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
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
                            ConnectSQL.AtualizarDocGRD((int)id_contatoSelecionado, txtNumero);
                            ConnectSQL.Update((int)id_contatoSelecionado, txtNumero.Text.ToUpper(), txtRev.Text.ToUpper(), comboOS.Text, txtObs.Text.ToUpper(), user);
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Atualizado!");
                            limpar();
                        }
                        else
                        {

                            ConnectSQL.Insert(txtNumero.Text.ToUpper(), txtRev.Text.ToUpper(), comboOS.Text, txtObs.Text.ToUpper(), user);
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Documento cadastrado!");
                            limpar();
                        }
                    }
                    else
                    {
                        if (!checkRev.Checked)
                        {
                            MySqlDataReader reader;
                            int k = 0;
                            for (int i = 0; i < qtdlinhas; i++)
                            {
                                ConnectSQL.cmd.CommandText = $"SELECT numero FROM documento WHERE numero='{numeros[i]}'";
                                reader = ConnectSQL.cmd.ExecuteReader();
                                reader.Read();
                                if (reader.HasRows)
                                {
                                    MessageBox.Show($"Documento da linha {i + 2} já cadastrado");
                                    reader.Close();
                                }
                                else
                                {
                                    reader.Close();
                                    ConnectSQL.Insert(numeros[i], revisoes[i], oss[i], obss[i], user);
                                    k++;
                                }

                            }
                            if (k > 0)
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Documento(s) cadastrado(s)!");
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Nenhum documento cadastrado");
                            }

                            limpar();

                        }
                        else
                        {
                            for (int i = 0; i < qtdlinhas; i++)
                            {
                                ConnectSQL.AtualizarDocGRD((int)ConnectSQL.SearchID(numeros[i]), txtNumero);
                                ConnectSQL.Update((int)ConnectSQL.SearchID(numeros[i]), numeros[i], revisoes[i], oss[i], obss[i], user);
                            }
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Atualizado(s)!");
                            limpar();
                        }

                    }
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

        private void btnMultiplos_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();


                using (OpenFileDialog arquivoDialogo = new OpenFileDialog())
                {
                    arquivoDialogo.InitialDirectory = "Downloads";
                    arquivoDialogo.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    arquivoDialogo.FilterIndex = 1;
                    arquivoDialogo.RestoreDirectory = true;

                    if (arquivoDialogo.ShowDialog() == DialogResult.OK)
                    {
                        multiplos = true;
                        checkRev.Enabled = false;
                        var fileStream = arquivoDialogo.OpenFile();
                        Cursor.Current = Cursors.WaitCursor;

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
                        wb.Close();
                        planilha.Quit();

                        labelMultiplo.Text = Path.GetFileName(arquivoDialogo.FileName);
                        Cursor.Current = Cursors.Default;

                        if (checkRev.Checked)
                        {
                            MySqlDataReader reader;
                            int pend;
                            foreach (string numero in numeros)
                            {
                                ConnectSQL.cmd.CommandText = $"SELECT pend FROM documento WHERE numero='{numero}'";
                                reader = ConnectSQL.cmd.ExecuteReader();
                                reader.Read();
                                pend = Int32.Parse(reader.GetString(0));
                                reader.Close();
                                if (pend > 0)
                                {
                                    MessageBox.Show("Atenção, há documento(s) pendente(s) na planilha");
                                    btnSalvar.Enabled = false;
                                    break;
                                }
                            }
                        }

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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_contatoSelecionado != null)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (txtRev.Enabled)
                        {
                            ConnectSQL.Connect();
                            ConnectSQL.Delete(id_contatoSelecionado);

                            MessageBox.Show("Cadastro excluído!");

                            limpar();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir, o documento tem emissão pendente");
                        }

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
            FormProcurar procurar = new FormProcurar(this, txtRev, txtNumero);
            procurar.ShowDialog();
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

        private void btnRegistrarOS_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNovaOS.Text == "")
                {
                    MessageBox.Show("Campo vazio");

                }
                else
                {
                    File.AppendAllText(filePath, txtNovaOS.Text + Environment.NewLine);
                    comboOS.Items.Clear();
                    carregarOS(filePath);
                    MessageBox.Show("OS Registrada");
                    txtNovaOS.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
            checkRev.Checked = false;
            txtRev.Enabled = true;
            btnSalvar.Enabled = true;
            checkRev.Enabled = true;
            txtNumero.Enabled = true;
        }

        private void checarCelulas(ref int linhas, dynamic ws)
        {
            dynamic cell;

            for (int l = 0; l <= linhas; l++)
            {
                cell = ws.Cells[l + 1, 1].Value;

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

        private void carregarOS(string path)
        {
            if (File.Exists($@"{path}"))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    comboOS.Items.Add(line);
                }
            }
            else
            {
                File.Create($@"{path}");
                carregarOS(path);
            }
        }
    }
}

