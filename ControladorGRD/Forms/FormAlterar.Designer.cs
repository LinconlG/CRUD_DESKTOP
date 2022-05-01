
namespace ControladorGRD.Forms
{
    partial class FormAlterar
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
            this.components = new System.ComponentModel.Container();
            this.txtGRD = new System.Windows.Forms.TextBox();
            this.listDoc = new System.Windows.Forms.ListView();
            this.listResp = new System.Windows.Forms.ListView();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerDocumentoDaGRDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerResponsavelDaGRDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGRD
            // 
            this.txtGRD.Location = new System.Drawing.Point(12, 72);
            this.txtGRD.Name = "txtGRD";
            this.txtGRD.Size = new System.Drawing.Size(116, 20);
            this.txtGRD.TabIndex = 0;
            this.txtGRD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGRD_KeyDown);
            // 
            // listDoc
            // 
            this.listDoc.ContextMenuStrip = this.contextMenuStrip1;
            this.listDoc.HideSelection = false;
            this.listDoc.Location = new System.Drawing.Point(15, 174);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(337, 229);
            this.listDoc.TabIndex = 1;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            // 
            // listResp
            // 
            this.listResp.ContextMenuStrip = this.contextMenuStrip2;
            this.listResp.HideSelection = false;
            this.listResp.Location = new System.Drawing.Point(384, 174);
            this.listResp.Name = "listResp";
            this.listResp.Size = new System.Drawing.Size(173, 229);
            this.listResp.TabIndex = 2;
            this.listResp.UseCompatibleStateImageBehavior = false;
            this.listResp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listResp_MouseDoubleClick);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(215, 72);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "GRD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Emissão:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(474, 443);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 28);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerDocumentoDaGRDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 26);
            // 
            // removerDocumentoDaGRDToolStripMenuItem
            // 
            this.removerDocumentoDaGRDToolStripMenuItem.Name = "removerDocumentoDaGRDToolStripMenuItem";
            this.removerDocumentoDaGRDToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removerDocumentoDaGRDToolStripMenuItem.Text = "Remover documento da GRD";
            this.removerDocumentoDaGRDToolStripMenuItem.Click += new System.EventHandler(this.removerDocumentoDaGRDToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerResponsavelDaGRDToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(232, 48);
            // 
            // removerResponsavelDaGRDToolStripMenuItem
            // 
            this.removerResponsavelDaGRDToolStripMenuItem.Name = "removerResponsavelDaGRDToolStripMenuItem";
            this.removerResponsavelDaGRDToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.removerResponsavelDaGRDToolStripMenuItem.Text = "Remover Responsavel da GRD";
            this.removerResponsavelDaGRDToolStripMenuItem.Click += new System.EventHandler(this.removerResponsavelDaGRDToolStripMenuItem_Click);
            // 
            // FormAlterar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 629);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.listResp);
            this.Controls.Add(this.listDoc);
            this.Controls.Add(this.txtGRD);
            this.Name = "FormAlterar";
            this.Text = "FormReceber";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGRD;
        private System.Windows.Forms.ListView listDoc;
        private System.Windows.Forms.ListView listResp;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removerDocumentoDaGRDToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem removerResponsavelDaGRDToolStripMenuItem;
    }
}