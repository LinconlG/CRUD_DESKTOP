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
    public partial class FormBuscar : Form
    {
        public FormBuscar()
        {
            InitializeComponent();
            listaGRD.View = View.Details;
            listaGRD.GridLines = true;
            listaGRD.FullRowSelect = true;
 
            listaGRD.Columns.Add("Data", 90, HorizontalAlignment.Left);
            listaGRD.Columns.Add("GRD", 60, HorizontalAlignment.Left);
            listaGRD.Columns.Add("Numero", 200, HorizontalAlignment.Left);
            listaGRD.Columns.Add("Revisão", 60, HorizontalAlignment.Left);
            listaGRD.Columns.Add("Responsável", 280, HorizontalAlignment.Left);

            carregarGRD();
        }

        private void btnBuscarDocGrd_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();
                ConnectSQL.cmd.CommandText = $"select dataEmissao, grd_dados.grd, documento.numero , emissaogrd.revDoc, grd_dados.resps " +
                    $"from documento join grd_dados join emissaogrd on emissaogrd.idGrd = grd_dados.grd AND emissaogrd.idDoc = documento.id " +
                    $"WHERE grd_dados.grd LIKE @g OR documento.numero LIKE @g ORDER BY grd_dados.grd DESC;";
                ConnectSQL.cmd.Parameters.Clear();
                ConnectSQL.cmd.Parameters.AddWithValue("@g", $"%{txtBuscarDocGrd.Text}%");


                MySqlDataReader reader = ConnectSQL.cmd.ExecuteReader();

                listaGRD.Items.Clear();

                while (reader.Read())
                {
                    string[] row = {

                        reader.GetString(0).Substring(0,10),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    };

                    var linha_listview = new ListViewItem(row);
                    listaGRD.Items.Add(linha_listview);
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

                ConnectSQL.Connect();


                MySqlDataReader reader = ConnectSQL.ExibirGRD();

                listaGRD.Items.Clear();

                while (reader.Read())
                {
                    string[] row = {

                        reader.GetString(0).Substring(0,10),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
                    };

                    var linha_listview = new ListViewItem(row);
                    listaGRD.Items.Add(linha_listview);
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

        private void txtBuscarDocGrd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarDocGrd_Click(this, e);
            }
        }
    }
}
