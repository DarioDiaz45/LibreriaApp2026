namespace LibreriaApp2026.Windows
{
    partial class frmAutor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutor));
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbSalir = new ToolStripButton();
            panel2 = new Panel();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas = new Label();
            label2 = new Label();
            lblRegistros = new Label();
            label1 = new Label();
            panel3 = new Panel();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colNacionalidad = new DataGridViewTextBoxColumn();
            colFNacimiento = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(790, 72);
            panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, toolStripSeparator1, tsbFiltrar, tsbActualizar, toolStripSeparator2, tsbSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(790, 70);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(52, 67);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = (Image)resources.GetObject("tsbBorrar.Image");
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(52, 67);
            tsbBorrar.Text = "Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(52, 67);
            tsbEditar.Text = "Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(52, 67);
            tsbFiltrar.Text = "Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = (Image)resources.GetObject("tsbActualizar.Image");
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(63, 67);
            tsbActualizar.Text = "Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 70);
            // 
            // tsbSalir
            // 
            tsbSalir.Image = (Image)resources.GetObject("tsbSalir.Image");
            tsbSalir.ImageScaling = ToolStripItemImageScaling.None;
            tsbSalir.ImageTransparentColor = Color.Magenta;
            tsbSalir.Name = "tsbSalir";
            tsbSalir.Size = new Size(52, 67);
            tsbSalir.Text = "Salir";
            tsbSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbSalir.Click += tsbSalir_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(btnUltimo);
            panel2.Controls.Add(btnSiguiente);
            panel2.Controls.Add(btnAnterior);
            panel2.Controls.Add(btnPrimero);
            panel2.Controls.Add(lblPaginas);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblRegistros);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 389);
            panel2.Name = "panel2";
            panel2.Size = new Size(790, 61);
            panel2.TabIndex = 1;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(577, 9);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(49, 44);
            btnUltimo.TabIndex = 12;
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Right_Button;
            btnSiguiente.Location = new Point(522, 12);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(49, 41);
            btnSiguiente.TabIndex = 11;
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(440, 12);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(49, 41);
            btnAnterior.TabIndex = 10;
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(385, 12);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(49, 41);
            btnPrimero.TabIndex = 9;
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(139, 38);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 3;
            lblPaginas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 38);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 2;
            label2.Text = "Cantidad de Paginas:";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(141, 16);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(13, 15);
            lblRegistros.TabIndex = 1;
            lblRegistros.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 16);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de Registros:";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvDatos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 72);
            panel3.Name = "panel3";
            panel3.Size = new Size(790, 317);
            panel3.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.BackgroundColor = Color.FromArgb(192, 255, 255);
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colApellido, colNacionalidad, colFNacimiento });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(790, 317);
            dgvDatos.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            // 
            // colApellido
            // 
            colApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colApellido.DataPropertyName = "Apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            // 
            // colNacionalidad
            // 
            colNacionalidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNacionalidad.DataPropertyName = "Nacionalidad";
            colNacionalidad.HeaderText = "Nacionalidad";
            colNacionalidad.Name = "colNacionalidad";
            // 
            // colFNacimiento
            // 
            colFNacimiento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFNacimiento.DataPropertyName = "FechaNacimiento";
            colFNacimiento.HeaderText = "F.Nacimiento";
            colFNacimiento.Name = "colFNacimiento";
            // 
            // frmAutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmAutor";
            Text = "frmAutor";
            Load += frmAutor_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbFiltrar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbSalir;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvDatos;
        private Label label1;
        private Label label2;
        private Label lblRegistros;
        private Label lblPaginas;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colNacionalidad;
        private DataGridViewTextBoxColumn colFNacimiento;
    }
}