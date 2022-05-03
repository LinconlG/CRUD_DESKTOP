
namespace ControladorGRD.Forms
{
    partial class FormResps
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
            this.listResp = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listResp
            // 
            this.listResp.HideSelection = false;
            this.listResp.Location = new System.Drawing.Point(12, 12);
            this.listResp.Name = "listResp";
            this.listResp.Size = new System.Drawing.Size(294, 175);
            this.listResp.TabIndex = 0;
            this.listResp.UseCompatibleStateImageBehavior = false;
            this.listResp.SelectedIndexChanged += new System.EventHandler(this.listResp_SelectedIndexChanged);
            // 
            // FormResps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 200);
            this.Controls.Add(this.listResp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recebimento";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listResp;
    }
}