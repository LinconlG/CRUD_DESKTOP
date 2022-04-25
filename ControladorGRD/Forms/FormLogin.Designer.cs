
namespace ControladorGRD.Forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.labelUsuario = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.labelSenha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDS = new System.Windows.Forms.TextBox();
            this.txtUN = new System.Windows.Forms.TextBox();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.labelDS = new System.Windows.Forms.Label();
            this.labelDB = new System.Windows.Forms.Label();
            this.labelUN = new System.Windows.Forms.Label();
            this.labelPW = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            resources.ApplyResources(this.labelUsuario, "labelUsuario");
            this.labelUsuario.Name = "labelUsuario";
            // 
            // txtSenha
            // 
            resources.ApplyResources(this.txtSenha, "txtSenha");
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUsuario
            // 
            resources.ApplyResources(this.txtUsuario, "txtUsuario");
            this.txtUsuario.Name = "txtUsuario";
            // 
            // labelSenha
            // 
            resources.ApplyResources(this.labelSenha, "labelSenha");
            this.labelSenha.Name = "labelSenha";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::ControladorGRD.Properties.Resources.Picture4;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // txtDS
            // 
            resources.ApplyResources(this.txtDS, "txtDS");
            this.txtDS.Name = "txtDS";
            // 
            // txtUN
            // 
            resources.ApplyResources(this.txtUN, "txtUN");
            this.txtUN.Name = "txtUN";
            // 
            // txtDB
            // 
            resources.ApplyResources(this.txtDB, "txtDB");
            this.txtDB.Name = "txtDB";
            // 
            // txtPW
            // 
            resources.ApplyResources(this.txtPW, "txtPW");
            this.txtPW.Name = "txtPW";
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // labelDS
            // 
            resources.ApplyResources(this.labelDS, "labelDS");
            this.labelDS.Name = "labelDS";
            // 
            // labelDB
            // 
            resources.ApplyResources(this.labelDB, "labelDB");
            this.labelDB.Name = "labelDB";
            // 
            // labelUN
            // 
            resources.ApplyResources(this.labelUN, "labelUN");
            this.labelUN.Name = "labelUN";
            // 
            // labelPW
            // 
            resources.ApplyResources(this.labelPW, "labelPW");
            this.labelPW.Name = "labelPW";
            // 
            // FormLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.labelUN);
            this.Controls.Add(this.labelDB);
            this.Controls.Add(this.labelDS);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.txtUN);
            this.Controls.Add(this.txtDS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.labelUsuario);
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDS;
        private System.Windows.Forms.TextBox txtUN;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.Label labelDS;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.Label labelUN;
        private System.Windows.Forms.Label labelPW;
    }
}