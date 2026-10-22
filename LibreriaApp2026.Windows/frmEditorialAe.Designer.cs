namespace LibreriaApp2026.Windows
{
    partial class frmEditorialAe
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
            lblNombre = new Label();
            lblPais = new Label();
            txtNombre = new TextBox();
            txtPaisOrigen = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(68, 46);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblPais
            // 
            lblPais.AutoSize = true;
            lblPais.Location = new Point(52, 85);
            lblPais.Name = "lblPais";
            lblPais.Size = new Size(70, 15);
            lblPais.TabIndex = 1;
            lblPais.Text = "Pais Origen:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(128, 43);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(197, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtPaisOrigen
            // 
            txtPaisOrigen.Location = new Point(128, 82);
            txtPaisOrigen.Name = "txtPaisOrigen";
            txtPaisOrigen.Size = new Size(197, 23);
            txtPaisOrigen.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ControlDark;
            btnOK.Image = Properties.Resources.Check_Mark;
            btnOK.Location = new Point(52, 152);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 68);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(295, 152);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 68);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmEditorialAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(475, 232);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtPaisOrigen);
            Controls.Add(txtNombre);
            Controls.Add(lblPais);
            Controls.Add(lblNombre);
            Name = "frmEditorialAe";
            Text = "frmEditorialAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblPais;
        private TextBox txtNombre;
        private TextBox txtPaisOrigen;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}