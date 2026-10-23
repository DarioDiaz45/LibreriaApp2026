namespace LibreriaApp2026.Windows
{
    partial class frmPrincipal
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
            panel1 = new Panel();
            panel4 = new Panel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblUsuario = new ToolStripStatusLabel();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            btnAutores = new Button();
            btnLibros = new Button();
            btnTemas = new Button();
            btnEditorial = new Button();
            panel2 = new Panel();
            btnLogaut = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(807, 450);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(statusStrip1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(232, 427);
            panel4.Name = "panel4";
            panel4.Size = new Size(575, 23);
            panel4.TabIndex = 4;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.ActiveCaption;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblUsuario });
            statusStrip1.Location = new Point(0, 1);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(575, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(50, 17);
            toolStripStatusLabel1.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(108, 17);
            lblUsuario.Text = "Usuario Conectado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(358, 158);
            label3.Name = "label3";
            label3.Size = new Size(263, 15);
            label3.TabIndex = 3;
            label3.Text = "Seleccione una opción del menú para comenzar.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 128);
            label2.Name = "label2";
            label2.Size = new Size(165, 15);
            label2.TabIndex = 2;
            label2.Text = "Sistema de Gestión de Libreria";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(btnAutores);
            panel3.Controls.Add(btnLibros);
            panel3.Controls.Add(btnTemas);
            panel3.Controls.Add(btnEditorial);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(232, 374);
            panel3.TabIndex = 1;
            // 
            // btnAutores
            // 
            btnAutores.BackColor = Color.FromArgb(192, 255, 255);
            btnAutores.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAutores.Location = new Point(35, 228);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(139, 44);
            btnAutores.TabIndex = 2;
            btnAutores.Text = "Autores";
            btnAutores.UseVisualStyleBackColor = false;
            btnAutores.Click += btnAutores_Click;
            // 
            // btnLibros
            // 
            btnLibros.BackColor = Color.FromArgb(192, 255, 255);
            btnLibros.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLibros.Location = new Point(35, 167);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(139, 44);
            btnLibros.TabIndex = 2;
            btnLibros.Text = "Libros";
            btnLibros.UseVisualStyleBackColor = false;
            // 
            // btnTemas
            // 
            btnTemas.BackColor = Color.FromArgb(192, 255, 255);
            btnTemas.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTemas.Location = new Point(35, 100);
            btnTemas.Name = "btnTemas";
            btnTemas.Size = new Size(139, 44);
            btnTemas.TabIndex = 2;
            btnTemas.Text = "Temas";
            btnTemas.UseVisualStyleBackColor = false;
            btnTemas.Click += btnTemas_Click;
            // 
            // btnEditorial
            // 
            btnEditorial.BackColor = Color.FromArgb(192, 255, 255);
            btnEditorial.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditorial.Location = new Point(35, 37);
            btnEditorial.Name = "btnEditorial";
            btnEditorial.Size = new Size(139, 43);
            btnEditorial.TabIndex = 2;
            btnEditorial.Text = "Editoriales";
            btnEditorial.UseVisualStyleBackColor = false;
            btnEditorial.Click += btnEditorial_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(btnLogaut);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(807, 76);
            panel2.TabIndex = 0;
            // 
            // btnLogaut
            // 
            btnLogaut.BackColor = Color.Red;
            btnLogaut.Location = new Point(657, 32);
            btnLogaut.Name = "btnLogaut";
            btnLogaut.Size = new Size(75, 28);
            btnLogaut.TabIndex = 1;
            btnLogaut.Text = "Logaut";
            btnLogaut.UseVisualStyleBackColor = false;
            btnLogaut.Click += btnLogaut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 21);
            label1.Margin = new Padding(3, 2, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(210, 37);
            label1.TabIndex = 0;
            label1.Text = "LIBRERIA 2026";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 450);
            Controls.Add(panel1);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnLogaut;
        private Label label1;
        private Panel panel3;
        private Button btnAutores;
        private Button btnLibros;
        private Button btnTemas;
        private Button btnEditorial;
        private Panel panel4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblUsuario;
        private Label label3;
        private Label label2;
    }
}