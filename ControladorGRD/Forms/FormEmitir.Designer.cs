
namespace ControladorGRD.Forms
{
    partial class FormEmitir
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
            this.txtData = new System.Windows.Forms.TextBox();
            this.labelData = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.listDoc = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.comboResp = new System.Windows.Forms.ComboBox();
            this.listResp = new System.Windows.Forms.ListView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelResp = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelqtd = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(321, 66);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 0;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(318, 50);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(33, 13);
            this.labelData.TabIndex = 1;
            this.labelData.Text = "Data:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(13, 108);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(230, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(10, 92);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(118, 13);
            this.labelNumero.TabIndex = 4;
            this.labelNumero.Text = "Numero do documento:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(249, 106);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // listDoc
            // 
            this.listDoc.ContextMenuStrip = this.contextMenuStrip1;
            this.listDoc.HideSelection = false;
            this.listDoc.Location = new System.Drawing.Point(13, 151);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(375, 285);
            this.listDoc.TabIndex = 7;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 26);
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // btnEmitir
            // 
            this.btnEmitir.Location = new System.Drawing.Point(297, 456);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(91, 26);
            this.btnEmitir.TabIndex = 4;
            this.btnEmitir.Text = "Emitir";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // comboResp
            // 
            this.comboResp.FormattingEnabled = true;
            this.comboResp.Location = new System.Drawing.Point(433, 108);
            this.comboResp.Name = "comboResp";
            this.comboResp.Size = new System.Drawing.Size(161, 21);
            this.comboResp.TabIndex = 2;
            this.comboResp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboResp_KeyPress);
            // 
            // listResp
            // 
            this.listResp.ContextMenuStrip = this.contextMenuStrip2;
            this.listResp.HideSelection = false;
            this.listResp.Location = new System.Drawing.Point(433, 151);
            this.listResp.Name = "listResp";
            this.listResp.Size = new System.Drawing.Size(161, 180);
            this.listResp.TabIndex = 10;
            this.listResp.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(122, 26);
            // 
            // removerToolStripMenuItem1
            // 
            this.removerToolStripMenuItem1.Name = "removerToolStripMenuItem1";
            this.removerToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.removerToolStripMenuItem1.Text = "Remover";
            this.removerToolStripMenuItem1.Click += new System.EventHandler(this.removerToolStripMenuItem1_Click);
            // 
            // labelResp
            // 
            this.labelResp.AutoSize = true;
            this.labelResp.Location = new System.Drawing.Point(433, 92);
            this.labelResp.Name = "labelResp";
            this.labelResp.Size = new System.Drawing.Size(74, 13);
            this.labelResp.TabIndex = 11;
            this.labelResp.Text = "Responsáveis";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(95, 462);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(100, 20);
            this.txtObs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Observação";
            // 
            // labelqtd
            // 
            this.labelqtd.AutoSize = true;
            this.labelqtd.Location = new System.Drawing.Point(217, 443);
            this.labelqtd.Name = "labelqtd";
            this.labelqtd.Size = new System.Drawing.Size(35, 13);
            this.labelqtd.TabIndex = 14;
            this.labelqtd.Text = "label2";
            // 
            // FormEmitir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(610, 629);
            this.Controls.Add(this.labelqtd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.labelResp);
            this.Controls.Add(this.listResp);
            this.Controls.Add(this.comboResp);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.listDoc);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.txtData);
            this.Name = "FormEmitir";
            this.Text = "FormEmitir";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListView listDoc;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.ComboBox comboResp;
        private System.Windows.Forms.ListView listResp;
        private System.Windows.Forms.Label labelResp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem1;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelqtd;
    }
}