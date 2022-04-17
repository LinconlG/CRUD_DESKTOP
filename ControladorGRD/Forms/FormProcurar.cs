using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ControladorGRD.Entities;

namespace ControladorGRD.Forms
{
    public partial class FormProcurar : Form
    {
        private int? id_contatoSelecionado = null;

        public string numero, rev, os, tipo, obs;

        public FormProcurar()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectSQL.Connect();

                id_contatoSelecionado = ConnectSQL.SearchID(txtProcurar.Text);


                if (id_contatoSelecionado != null)
                {
                    ConnectSQL.Values(id_contatoSelecionado);

                    //se o id for encontrado, colocar os valores nas caixas de textos
                    //acessar as varias desses metodo para a caixas receberem?
                }
                else
                {
                    MessageBox.Show("Não encontrado");
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
