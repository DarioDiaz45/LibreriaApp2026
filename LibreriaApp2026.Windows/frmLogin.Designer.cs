namespace LibreriaApp2026.Windows
{
    partial class frmLogin
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblUsuario = new Label();
            lblClave = new Label();
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnLogin = new Button();
            btnCerrar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(100, 77);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(100, 117);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(39, 15);
            lblClave.TabIndex = 1;
            lblClave.Text = "Clave:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(156, 74);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(198, 23);
            txtUsuario.TabIndex = 2;
            txtUsuario.Text = "admin";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(156, 117);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(198, 23);
            txtClave.TabIndex = 3;
            txtClave.Text = "123456";
            txtClave.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ButtonShadow;
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.Location = new Point(100, 195);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 58);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.TextAlign = ContentAlignment.BottomCenter;
            btnLogin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.ControlDark;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(279, 195);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 57);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnSalir_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(490, 286);
            Controls.Add(btnCerrar);
            Controls.Add(btnLogin);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Name = "frmLogin";
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnLogin;
        private Button btnCerrar;
        private ErrorProvider errorProvider1;
    }
}