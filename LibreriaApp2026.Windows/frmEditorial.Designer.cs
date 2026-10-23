namespace LibreriaApp2026.Windows
{
    partial class frmEditorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditorial));
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colPaisOrigen = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
            panel3 = new Panel();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas2 = new Label();
            lblPaginas = new Label();
            lblCantidad = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbSalir = new ToolStripButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatos);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 450);
            panel1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.BackgroundColor = Color.PaleTurquoise;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colPaisOrigen, colActivo });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 69);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(772, 282);
            dgvDatos.TabIndex = 2;
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
            // colPaisOrigen
            // 
            colPaisOrigen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPaisOrigen.DataPropertyName = "PaisOrigen";
            colPaisOrigen.HeaderText = "Pais Origen";
            colPaisOrigen.Name = "colPaisOrigen";
            // 
            // colActivo
            // 
            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo";
            colActivo.Name = "colActivo";
            colActivo.Resizable = DataGridViewTriState.True;
            colActivo.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(btnUltimo);
            panel3.Controls.Add(btnSiguiente);
            panel3.Controls.Add(btnAnterior);
            panel3.Controls.Add(btnPrimero);
            panel3.Controls.Add(lblPaginas2);
            panel3.Controls.Add(lblPaginas);
            panel3.Controls.Add(lblCantidad);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 351);
            panel3.Name = "panel3";
            panel3.Size = new Size(772, 99);
            panel3.TabIndex = 1;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(569, 18);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(49, 44);
            btnUltimo.TabIndex = 8;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Right_Button;
            btnSiguiente.Location = new Point(514, 21);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(49, 41);
            btnSiguiente.TabIndex = 7;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(432, 21);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(49, 41);
            btnAnterior.TabIndex = 6;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(377, 21);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(49, 41);
            btnPrimero.TabIndex = 5;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // lblPaginas2
            // 
            lblPaginas2.AutoSize = true;
            lblPaginas2.Location = new Point(159, 50);
            lblPaginas2.Name = "lblPaginas2";
            lblPaginas2.Size = new Size(13, 15);
            lblPaginas2.TabIndex = 4;
            lblPaginas2.Text = "0";
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(896, 0);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(38, 15);
            lblPaginas.TabIndex = 3;
            lblPaginas.Text = "label3";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(159, 21);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(13, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 50);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad de Paginas:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 21);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de Registros:";
            // 
            // panel2
            // 
            panel2.Controls.Add(toolStrip1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 69);
            panel2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, toolStripSeparator1, tsbFiltrar, tsbActualizar, toolStripSeparator2, tsbSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(772, 70);
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
            // frmEditorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 450);
            Controls.Add(panel1);
            Name = "frmEditorial";
            Text = "frmEditorial";
            Load += frmEditorial_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvDatos;
        private Panel panel3;
        private Panel panel2;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbFiltrar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbSalir;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas2;
        private Label lblPaginas;
        private Label lblCantidad;
        private Label label2;
        private Label label1;
        private Button btnUltimo;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colPaisOrigen;
        private DataGridViewCheckBoxColumn colActivo;
    }
}