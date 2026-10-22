namespace LibreriaApp2026.Windows
{
    partial class frmAutorAe
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
            lblApellido = new Label();
            lblNac = new Label();
            lblFecNacimiento = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtNacionalidad = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnCancelar = new Button();
            btnOK = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(30, 62);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(54, 15);
            lblApellido.TabIndex = 1;
            lblApellido.Text = "Apellido:";
            // 
            // lblNac
            // 
            lblNac.AutoSize = true;
            lblNac.Location = new Point(310, 28);
            lblNac.Name = "lblNac";
            lblNac.Size = new Size(80, 15);
            lblNac.TabIndex = 2;
            lblNac.Text = "Nacionalidad:";
            // 
            // lblFecNacimiento
            // 
            lblFecNacimiento.AutoSize = true;
            lblFecNacimiento.Location = new Point(309, 67);
            lblFecNacimiento.Name = "lblFecNacimiento";
            lblFecNacimiento.Size = new Size(81, 15);
            lblFecNacimiento.TabIndex = 3;
            lblFecNacimiento.Text = "F.Nacimiento:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(90, 25);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(187, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(90, 59);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(189, 23);
            txtApellido.TabIndex = 5;
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(396, 25);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(187, 23);
            txtNacionalidad.TabIndex = 6;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(396, 67);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(187, 23);
            dtpFechaNacimiento.TabIndex = 7;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(391, 162);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 68);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ControlDark;
            btnOK.Image = Properties.Resources.Check_Mark;
            btnOK.Location = new Point(148, 162);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 68);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAutorAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(638, 259);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtNacionalidad);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblFecNacimiento);
            Controls.Add(lblNac);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Name = "frmAutorAe";
            Text = "frmAutorAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblApellido;
        private Label lblNac;
        private Label lblFecNacimiento;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNacionalidad;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnCancelar;
        private Button btnOK;
        private ErrorProvider errorProvider1;
    }
}