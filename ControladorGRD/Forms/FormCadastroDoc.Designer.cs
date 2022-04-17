
namespace ControladorGRD.Forms
{
    partial class FormCadastroDoc
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
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtRev = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelRev = new System.Windows.Forms.Label();
            this.labelOS = new System.Windows.Forms.Label();
            this.labelTipo = new System.Windows.Forms.Label();
            this.labelObservacao = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.RichTextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.labelCod = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.comboOS = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelMultiplo = new System.Windows.Forms.Label();
            this.checkRev = new System.Windows.Forms.CheckBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(13, 91);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(266, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // txtRev
            // 
            this.txtRev.Location = new System.Drawing.Point(298, 91);
            this.txtRev.Name = "txtRev";
            this.txtRev.Size = new System.Drawing.Size(68, 20);
            this.txtRev.TabIndex = 1;
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(457, 91);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 5;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(13, 75);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(47, 13);
            this.labelNumero.TabIndex = 6;
            this.labelNumero.Text = "Numero:";
            // 
            // labelRev
            // 
            this.labelRev.AutoSize = true;
            this.labelRev.Location = new System.Drawing.Point(295, 75);
            this.labelRev.Name = "labelRev";
            this.labelRev.Size = new System.Drawing.Size(49, 13);
            this.labelRev.TabIndex = 7;
            this.labelRev.Text = "Revisao:";
            // 
            // labelOS
            // 
            this.labelOS.AutoSize = true;
            this.labelOS.Location = new System.Drawing.Point(13, 123);
            this.labelOS.Name = "labelOS";
            this.labelOS.Size = new System.Drawing.Size(25, 13);
            this.labelOS.TabIndex = 8;
            this.labelOS.Text = "OS:";
            // 
            // labelTipo
            // 
            this.labelTipo.AutoSize = true;
            this.labelTipo.Location = new System.Drawing.Point(160, 123);
            this.labelTipo.Name = "labelTipo";
            this.labelTipo.Size = new System.Drawing.Size(91, 13);
            this.labelTipo.TabIndex = 9;
            this.labelTipo.Text = "Tipo de Estrutura:";
            // 
            // labelObservacao
            // 
            this.labelObservacao.AutoSize = true;
            this.labelObservacao.Location = new System.Drawing.Point(16, 194);
            this.labelObservacao.Name = "labelObservacao";
            this.labelObservacao.Size = new System.Drawing.Size(65, 13);
            this.labelObservacao.TabIndex = 10;
            this.labelObservacao.Text = "Observação";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(457, 72);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(90, 13);
            this.labelData.TabIndex = 11;
            this.labelData.Text = "Data de Registro:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(19, 210);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(441, 84);
            this.txtObs.TabIndex = 4;
            this.txtObs.Text = "";
            // 
            // txtCod
            // 
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(13, 49);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(100, 20);
            this.txtCod.TabIndex = 13;
            // 
            // labelCod
            // 
            this.labelCod.AutoSize = true;
            this.labelCod.Location = new System.Drawing.Point(13, 30);
            this.labelCod.Name = "labelCod";
            this.labelCod.Size = new System.Drawing.Size(29, 13);
            this.labelCod.TabIndex = 14;
            this.labelCod.Text = "Cod:";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(163, 142);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(121, 21);
            this.comboTipo.TabIndex = 3;
            // 
            // comboOS
            // 
            this.comboOS.FormattingEnabled = true;
            this.comboOS.Location = new System.Drawing.Point(16, 141);
            this.comboOS.Name = "comboOS";
            this.comboOS.Size = new System.Drawing.Size(121, 21);
            this.comboOS.TabIndex = 2;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(189, 320);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 27);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(152, 46);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 16;
            this.btnNovo.Text = "Limpar";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(233, 46);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Procurar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 18;
            this.button1.Text = "Multiplos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelMultiplo
            // 
            this.labelMultiplo.AutoSize = true;
            this.labelMultiplo.Location = new System.Drawing.Point(132, 386);
            this.labelMultiplo.Name = "labelMultiplo";
            this.labelMultiplo.Size = new System.Drawing.Size(145, 13);
            this.labelMultiplo.TabIndex = 19;
            this.labelMultiplo.Text = "Nenhum arquivo selecionado";
            // 
            // checkRev
            // 
            this.checkRev.AutoSize = true;
            this.checkRev.Location = new System.Drawing.Point(16, 414);
            this.checkRev.Name = "checkRev";
            this.checkRev.Size = new System.Drawing.Size(70, 17);
            this.checkRev.TabIndex = 20;
            this.checkRev.Text = "Revisões";
            this.checkRev.UseVisualStyleBackColor = true;
            this.checkRev.CheckedChanged += new System.EventHandler(this.checkRev_CheckedChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(314, 46);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // FormCadastroDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(569, 629);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.checkRev);
            this.Controls.Add(this.labelMultiplo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.comboOS);
            this.Controls.Add(this.comboTipo);
            this.Controls.Add(this.labelCod);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelObservacao);
            this.Controls.Add(this.labelTipo);
            this.Controls.Add(this.labelOS);
            this.Controls.Add(this.labelRev);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtRev);
            this.Controls.Add(this.txtNumero);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastroDoc";
            this.Text = "FormCadastroDoc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtRev;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Label labelRev;
        private System.Windows.Forms.Label labelOS;
        private System.Windows.Forms.Label labelTipo;
        private System.Windows.Forms.Label labelObservacao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.RichTextBox txtObs;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label labelCod;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.ComboBox comboOS;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMultiplo;
        private System.Windows.Forms.CheckBox checkRev;
        private System.Windows.Forms.Button btnExcluir;
    }
}