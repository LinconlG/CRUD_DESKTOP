
namespace ControladorGRD.Forms
{
    partial class FormProcurar
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
            this.labelProcurar = new System.Windows.Forms.Label();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelProcurar
            // 
            this.labelProcurar.AutoSize = true;
            this.labelProcurar.Location = new System.Drawing.Point(12, 48);
            this.labelProcurar.Name = "labelProcurar";
            this.labelProcurar.Size = new System.Drawing.Size(153, 13);
            this.labelProcurar.TabIndex = 0;
            this.labelProcurar.Text = "Insira o numero do documento:";
            // 
            // txtProcurar
            // 
            this.txtProcurar.Location = new System.Drawing.Point(15, 73);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(268, 20);
            this.txtProcurar.TabIndex = 1;
            this.txtProcurar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProcurar_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(104, 132);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormProcurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 210);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.labelProcurar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProcurar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procurar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProcurar;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Button btnOK;
    }
}