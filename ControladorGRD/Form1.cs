using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControladorGRD.Forms;
using ControladorGRD.Entities;

namespace ControladorGRD
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Form activeForm;
        string activeuser;

        public Form1(FormLogin active)
        {
            InitializeComponent();
            activeuser = active.User();
        }

        private Color SelectThemeColor()
        {
            return ColorTranslator.FromHtml(ThemeColor.ColorList[0]);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("PF Square Sans Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(10, 120, 40);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("PF Square Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCadastroDoc(activeuser), sender);

        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormEmitir(), sender);
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormReceber(), sender);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBuscar(), sender);
        }

        private void btnResp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCadGeral(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            DisableButton();
        }
    }
}
