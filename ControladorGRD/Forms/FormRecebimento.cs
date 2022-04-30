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
    public partial class FormRecebimento : Form
    {
        int grd;
        FormAlterar alterar;
        public FormRecebimento(string resp, int grd, FormAlterar alterar)
        {
            InitializeComponent();
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label1.Text = resp;
            this.grd = grd;
            this.alterar = alterar;
        }

        private void BtnSim_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();

                ConnectSQL.cmd.CommandText = $"UPDATE recebimento SET dataEntrega=@data, entregue='1' WHERE grdId='{grd}' AND nome='{label1.Text}'";
                ConnectSQL.cmd.Parameters.Clear();
                if (checkBox.Checked)
                {
                    ConnectSQL.cmd.Parameters.AddWithValue("@data", "0000-00-00");
                }
                else
                {
                    ConnectSQL.cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd"));
                }

                ConnectSQL.cmd.Prepare();
                ConnectSQL.cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                alterar.carregarResps(grd);
                ConnectSQL.conexao.Close();
                this.Close();
            }
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
