
namespace ControladorGRD.Forms
{
    partial class FormBuscar
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
            this.listaGRD = new System.Windows.Forms.ListView();
            this.txtBuscarDocGrd = new System.Windows.Forms.TextBox();
            this.btnBuscarDocGrd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaGRD
            // 
            this.listaGRD.HideSelection = false;
            this.listaGRD.Location = new System.Drawing.Point(12, 189);
            this.listaGRD.Name = "listaGRD";
            this.listaGRD.Size = new System.Drawing.Size(699, 329);
            this.listaGRD.TabIndex = 0;
            this.listaGRD.UseCompatibleStateImageBehavior = false;
            // 
            // txtBuscarDocGrd
            // 
            this.txtBuscarDocGrd.Location = new System.Drawing.Point(12, 122);
            this.txtBuscarDocGrd.Name = "txtBuscarDocGrd";
            this.txtBuscarDocGrd.Size = new System.Drawing.Size(240, 20);
            this.txtBuscarDocGrd.TabIndex = 1;
            this.txtBuscarDocGrd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDocGrd_KeyDown);
            // 
            // btnBuscarDocGrd
            // 
            this.btnBuscarDocGrd.Location = new System.Drawing.Point(273, 122);
            this.btnBuscarDocGrd.Name = "btnBuscarDocGrd";
            this.btnBuscarDocGrd.Size = new System.Drawing.Size(85, 25);
            this.btnBuscarDocGrd.TabIndex = 2;
            this.btnBuscarDocGrd.Text = "Buscar";
            this.btnBuscarDocGrd.UseVisualStyleBackColor = true;
            this.btnBuscarDocGrd.Click += new System.EventHandler(this.btnBuscarDocGrd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PF Square Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar documento/GRD";
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 629);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarDocGrd);
            this.Controls.Add(this.txtBuscarDocGrd);
            this.Controls.Add(this.listaGRD);
            this.Name = "FormBuscar";
            this.Text = "FormBuscar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listaGRD;
        private System.Windows.Forms.TextBox txtBuscarDocGrd;
        private System.Windows.Forms.Button btnBuscarDocGrd;
        private System.Windows.Forms.Label label1;
    }
}