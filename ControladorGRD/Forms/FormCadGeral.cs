using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControladorGRD.Entities;
using MySql.Data.MySqlClient;

namespace ControladorGRD.Forms
{
    public partial class FormCadGeral : Form
    {

        public FormCadGeral()
        {
            InitializeComponent();
            listViewResp.View = View.Details;
            listViewResp.GridLines = true;
            listViewResp.FullRowSelect = true;
            listViewResp.AllowColumnReorder = true;

            listViewResp.Columns.Add("Nome", 250, HorizontalAlignment.Left);

            carregarResp();
        }

        private void btnOsResp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtResp.Text == "")
                {
                    MessageBox.Show("Campo vazio");
                }
                else
                {
                    ConnectSQL.Connect();

                    ConnectSQL.InsertResp(txtResp.Text.ToUpper());

                    MessageBox.Show("Responsavel cadastrado");

                    txtResp.Text = String.Empty;

                    carregarResp();
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

        private void carregarResp()
        {
            try
            {

                ConnectSQL.Connect();


                MySqlDataReader reader = ConnectSQL.ExbirResp();

                listViewResp.Items.Clear();

                while (reader.Read())
                {
                    string[] row = {

                        reader.GetString(0),//exibe o nome
                    };

                    var linha_listview = new ListViewItem(row);
                    listViewResp.Items.Add(linha_listview);
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();
                ConnectSQL.cmd.CommandText = $"SELECT * FROM responsavel WHERE nome LIKE @q";
                ConnectSQL.cmd.Parameters.Clear();
                ConnectSQL.cmd.Parameters.AddWithValue("@q", $"%{txtPesquisarResp.Text}%");

                MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

                listViewResp.Items.Clear();

                while (reader.Read())
                {
                    string[] row = {

                        reader.GetString(0),//exibe o nome
                    };

                    var linha_listview = new ListViewItem(row);
                    listViewResp.Items.Add(linha_listview);
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

        private void txtResp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                btnOsResp_Click(this, e);
            }   
        }

        private void txtPesquisarResp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                btnPesquisar_Click(this, e);
            }
        }
    }
}
