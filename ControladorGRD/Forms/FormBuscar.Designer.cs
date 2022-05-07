
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
            this.components = new System.ComponentModel.Container();
            this.listaGRD = new System.Windows.Forms.ListView();
            this.txtBuscarDocGrd = new System.Windows.Forms.TextBox();
            this.btnBuscarDocGrd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.salvarGRDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaGRD
            // 
            this.listaGRD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listaGRD.HideSelection = false;
            this.listaGRD.Location = new System.Drawing.Point(12, 189);
            this.listaGRD.Name = "listaGRD";
            this.listaGRD.Size = new System.Drawing.Size(699, 329);
            this.listaGRD.TabIndex = 0;
            this.listaGRD.UseCompatibleStateImageBehavior = false;
            this.listaGRD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listaGRD_MouseDoubleClick);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar documento/GRD";
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "GRD",
            "Documentos"});
            this.comboBox.Location = new System.Drawing.Point(440, 125);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 4;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exibição";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(13, 149);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(115, 17);
            this.checkBox.TabIndex = 6;
            this.checkBox.Text = "Buscar por número";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(605, 160);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarGRDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // salvarGRDToolStripMenuItem
            // 
            this.salvarGRDToolStripMenuItem.Name = "salvarGRDToolStripMenuItem";
            this.salvarGRDToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salvarGRDToolStripMenuItem.Text = "Salvar GRD";
            this.salvarGRDToolStripMenuItem.Click += new System.EventHandler(this.salvarGRDToolStripMenuItem_Click);
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 629);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarDocGrd);
            this.Controls.Add(this.txtBuscarDocGrd);
            this.Controls.Add(this.listaGRD);
            this.Name = "FormBuscar";
            this.Text = "FormBuscar";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listaGRD;
        private System.Windows.Forms.TextBox txtBuscarDocGrd;
        private System.Windows.Forms.Button btnBuscarDocGrd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salvarGRDToolStripMenuItem;
    }
}