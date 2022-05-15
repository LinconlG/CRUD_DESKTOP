
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
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnRelat = new System.Windows.Forms.Button();
            this.checkPend = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listaGRD
            // 
            this.listaGRD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listaGRD.HideSelection = false;
            this.listaGRD.Location = new System.Drawing.Point(12, 189);
            this.listaGRD.Name = "listaGRD";
            this.listaGRD.Size = new System.Drawing.Size(595, 329);
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
            this.btnAtualizar.Location = new System.Drawing.Point(486, 160);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnRelat
            // 
            this.btnRelat.Location = new System.Drawing.Point(273, 160);
            this.btnRelat.Name = "btnRelat";
            this.btnRelat.Size = new System.Drawing.Size(85, 23);
            this.btnRelat.TabIndex = 8;
            this.btnRelat.Text = "Salvar relatório";
            this.btnRelat.UseVisualStyleBackColor = true;
            this.btnRelat.Click += new System.EventHandler(this.btnRelat_Click);
            // 
            // checkPend
            // 
            this.checkPend.AutoSize = true;
            this.checkPend.Location = new System.Drawing.Point(12, 166);
            this.checkPend.Name = "checkPend";
            this.checkPend.Size = new System.Drawing.Size(77, 17);
            this.checkPend.TabIndex = 9;
            this.checkPend.Text = "Pendentes";
            this.checkPend.UseVisualStyleBackColor = true;
            this.checkPend.CheckedChanged += new System.EventHandler(this.checkPend_CheckedChanged);
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(629, 629);
            this.Controls.Add(this.checkPend);
            this.Controls.Add(this.btnRelat);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox);
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
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnRelat;
        private System.Windows.Forms.CheckBox checkPend;
    }
}