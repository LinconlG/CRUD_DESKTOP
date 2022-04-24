
namespace ControladorGRD.Forms
{
    partial class FormCadGeral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtResp = new System.Windows.Forms.TextBox();
            this.btnOsResp = new System.Windows.Forms.Button();
            this.listViewResp = new System.Windows.Forms.ListView();
            this.labelListaResp = new System.Windows.Forms.Label();
            this.txtPesquisarResp = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(120)))), ((int)(((byte)(40)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(450, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 629);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PF Square Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insira o nome do responsável :";
            // 
            // txtResp
            // 
            this.txtResp.Location = new System.Drawing.Point(12, 101);
            this.txtResp.Name = "txtResp";
            this.txtResp.Size = new System.Drawing.Size(208, 20);
            this.txtResp.TabIndex = 3;
            this.txtResp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResp_KeyDown);
            // 
            // btnOsResp
            // 
            this.btnOsResp.Location = new System.Drawing.Point(12, 137);
            this.btnOsResp.Name = "btnOsResp";
            this.btnOsResp.Size = new System.Drawing.Size(90, 25);
            this.btnOsResp.TabIndex = 4;
            this.btnOsResp.Text = "Cadastrar";
            this.btnOsResp.UseVisualStyleBackColor = true;
            this.btnOsResp.Click += new System.EventHandler(this.btnOsResp_Click);
            // 
            // listViewResp
            // 
            this.listViewResp.HideSelection = false;
            this.listViewResp.Location = new System.Drawing.Point(12, 286);
            this.listViewResp.Name = "listViewResp";
            this.listViewResp.Size = new System.Drawing.Size(318, 264);
            this.listViewResp.TabIndex = 5;
            this.listViewResp.UseCompatibleStateImageBehavior = false;
            // 
            // labelListaResp
            // 
            this.labelListaResp.AutoSize = true;
            this.labelListaResp.Location = new System.Drawing.Point(12, 239);
            this.labelListaResp.Name = "labelListaResp";
            this.labelListaResp.Size = new System.Drawing.Size(135, 13);
            this.labelListaResp.TabIndex = 6;
            this.labelListaResp.Text = "Responsaveis cadastrados";
            // 
            // txtPesquisarResp
            // 
            this.txtPesquisarResp.Location = new System.Drawing.Point(15, 260);
            this.txtPesquisarResp.Name = "txtPesquisarResp";
            this.txtPesquisarResp.Size = new System.Drawing.Size(157, 20);
            this.txtPesquisarResp.TabIndex = 7;
            this.txtPesquisarResp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisarResp_KeyDown);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(179, 257);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 8;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // FormCadGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 629);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPesquisarResp);
            this.Controls.Add(this.labelListaResp);
            this.Controls.Add(this.listViewResp);
            this.Controls.Add(this.btnOsResp);
            this.Controls.Add(this.txtResp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FormCadGeral";
            this.Text = "FormResp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtResp;
        private System.Windows.Forms.Button btnOsResp;
        private System.Windows.Forms.ListView listViewResp;
        private System.Windows.Forms.Label labelListaResp;
        private System.Windows.Forms.TextBox txtPesquisarResp;
        private System.Windows.Forms.Button btnPesquisar;
    }
}