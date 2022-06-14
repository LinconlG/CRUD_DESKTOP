using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormRecebimento : Form
    {
        int grd;
        ListView listdoc = new ListView();
        FormAlterar alterar;
        TextBox txt;
        public FormRecebimento(string resp, int grd, FormAlterar alterar, ListView listdoc, ref TextBox txtGrd)
        {
            InitializeComponent();
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            label1.Text = resp;
            this.grd = grd;
            this.alterar = alterar;
            this.listdoc = listdoc;
            txt = txtGrd;
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
                    ConnectSQL.cmd.Parameters.AddWithValue("@data", SqlDbType.Date).Value = "1111-11-11";
                }
                else
                {
                    ConnectSQL.cmd.Parameters.AddWithValue("@data", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                //ConnectSQL.//cmd.Prepare();
                ConnectSQL.cmd.ExecuteNonQuery();

                int pend;
                SqlDataReader reader;

                foreach (ListViewItem doc in listdoc.Items)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                alterar.carregarResps(grd);
                ConnectSQL.conexao.Close();
                txt.Focus();
                txt.SelectAll();
                this.Close();
            }
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            txt.Focus();
            txt.SelectAll();
            this.Close();
        }
    }
}
