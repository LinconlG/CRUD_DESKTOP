
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
            this.components = new System.ComponentModel.Container();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtRev = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.labelRev = new System.Windows.Forms.Label();
            this.labelOS = new System.Windows.Forms.Label();
            this.labelObservacao = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.RichTextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.labelCod = new System.Windows.Forms.Label();
            this.comboOS = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnProcurar = new System.Windows.Forms.Button();
            this.btnMultiplos = new System.Windows.Forms.Button();
            this.labelMultiplo = new System.Windows.Forms.Label();
            this.checkRev = new System.Windows.Forms.CheckBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.db_documentosDataSet = new ControladorGRD.db_documentosDataSet();
            this.osBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.osTableAdapter = new ControladorGRD.db_documentosDataSetTableAdapters.osTableAdapter();
            this.txtNovaOS = new System.Windows.Forms.TextBox();
            this.labelOS2 = new System.Windows.Forms.Label();
            this.btnRegistrarOS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.db_documentosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.osBindingSource)).BeginInit();
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
            // labelObservacao
            // 
            this.labelObservacao.AutoSize = true;
            this.labelObservacao.Location = new System.Drawing.Point(16, 194);
            this.labelObservacao.Name = "labelObservacao";
            this.labelObservacao.Size = new System.Drawing.Size(112, 13);
            this.labelObservacao.TabIndex = 10;
            this.labelObservacao.Text = "Observação/Legenda";
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
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnProcurar
            // 
            this.btnProcurar.Location = new System.Drawing.Point(233, 46);
            this.btnProcurar.Name = "btnProcurar";
            this.btnProcurar.Size = new System.Drawing.Size(75, 23);
            this.btnProcurar.TabIndex = 17;
            this.btnProcurar.Text = "Procurar";
            this.btnProcurar.UseVisualStyleBackColor = true;
            this.btnProcurar.Click += new System.EventHandler(this.btnProcurar_Click);
            // 
            // btnMultiplos
            // 
            this.btnMultiplos.Location = new System.Drawing.Point(16, 377);
            this.btnMultiplos.Name = "btnMultiplos";
            this.btnMultiplos.Size = new System.Drawing.Size(110, 30);
            this.btnMultiplos.TabIndex = 18;
            this.btnMultiplos.Text = "Multiplos";
            this.btnMultiplos.UseVisualStyleBackColor = true;
            this.btnMultiplos.Click += new System.EventHandler(this.btnMultiplos_Click);
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
            // db_documentosDataSet
            // 
            this.db_documentosDataSet.DataSetName = "db_documentosDataSet";
            this.db_documentosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // osBindingSource
            // 
            this.osBindingSource.DataMember = "os";
            this.osBindingSource.DataSource = this.db_documentosDataSet;
            // 
            // osTableAdapter
            // 
            this.osTableAdapter.ClearBeforeFill = true;
            // 
            // txtNovaOS
            // 
            this.txtNovaOS.Location = new System.Drawing.Point(13, 501);
            this.txtNovaOS.Name = "txtNovaOS";
            this.txtNovaOS.Size = new System.Drawing.Size(116, 20);
            this.txtNovaOS.TabIndex = 22;
            // 
            // labelOS2
            // 
            this.labelOS2.AutoSize = true;
            this.labelOS2.Location = new System.Drawing.Point(13, 482);
            this.labelOS2.Name = "labelOS2";
            this.labelOS2.Size = new System.Drawing.Size(97, 13);
            this.labelOS2.TabIndex = 23;
            this.labelOS2.Text = "Registrar nova OS:";
            // 
            // btnRegistrarOS
            // 
            this.btnRegistrarOS.Location = new System.Drawing.Point(135, 499);
            this.btnRegistrarOS.Name = "btnRegistrarOS";
            this.btnRegistrarOS.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrarOS.TabIndex = 24;
            this.btnRegistrarOS.Text = "Registrar";
            this.btnRegistrarOS.UseVisualStyleBackColor = true;
            this.btnRegistrarOS.Click += new System.EventHandler(this.btnRegistrarOS_Click);
            // 
            // FormCadastroDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(569, 629);
            this.Controls.Add(this.btnRegistrarOS);
            this.Controls.Add(this.labelOS2);
            this.Controls.Add(this.txtNovaOS);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.checkRev);
            this.Controls.Add(this.labelMultiplo);
            this.Controls.Add(this.btnMultiplos);
            this.Controls.Add(this.btnProcurar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.comboOS);
            this.Controls.Add(this.labelCod);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelObservacao);
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
            ((System.ComponentModel.ISupportInitialize)(this.db_documentosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.osBindingSource)).EndInit();
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
        private System.Windows.Forms.Label labelObservacao;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.RichTextBox txtObs;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label labelCod;
        private System.Windows.Forms.ComboBox comboOS;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnProcurar;
        private System.Windows.Forms.Button btnMultiplos;
        private System.Windows.Forms.Label labelMultiplo;
        private System.Windows.Forms.CheckBox checkRev;
        private System.Windows.Forms.Button btnExcluir;
        private db_documentosDataSet db_documentosDataSet;
        private System.Windows.Forms.BindingSource osBindingSource;
        private db_documentosDataSetTableAdapters.osTableAdapter osTableAdapter;
        private System.Windows.Forms.TextBox txtNovaOS;
        private System.Windows.Forms.Label labelOS2;
        private System.Windows.Forms.Button btnRegistrarOS;
    }
}