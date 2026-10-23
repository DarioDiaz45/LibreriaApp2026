namespace LibreriaApp2026.Windows
{
    partial class frmTemaAe
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
            lblDescripcion = new Label();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            btnCancelar = new Button();
            btnOK = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(54, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(36, 89);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(72, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripcion:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.InactiveCaption;
            txtNombre.Location = new Point(114, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = SystemColors.InactiveCaption;
            txtDescripcion.Location = new Point(114, 89);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(194, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Image = Properties.Resources.Cancel;
            btnCancelar.Location = new Point(262, 158);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 68);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaption;
            btnOK.Image = Properties.Resources.Check_Mark;
            btnOK.Location = new Point(54, 158);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 68);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmTemaAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(408, 262);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(lblNombre);
            Name = "frmTemaAe";
            Text = "frmTemaAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblDescripcion;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Button btnCancelar;
        private Button btnOK;
        private ErrorProvider errorProvider1;
    }
}