namespace LibreriaApp2026.Windows
{
    partial class frmFormaDePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormaDePago));
            panel1 = new Panel();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripSplitButton();
            activoToolStripMenuItem = new ToolStripMenuItem();
            noActivoToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton5 = new ToolStripButton();
            tstBuscar = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbActualizar = new ToolStripButton();
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
            colFormaDePagoId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
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
            panel1.Size = new Size(732, 69);
            panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbBorrar, toolStripSeparator1, tsbFiltrar, toolStripButton5, tstBuscar, toolStripSeparator2, tsbActualizar, tsbSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(732, 70);
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { activoToolStripMenuItem, noActivoToolStripMenuItem });
            tsbFiltrar.Image = (Image)resources.GetObject("tsbFiltrar.Image");
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(64, 67);
            tsbFiltrar.Text = "Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // activoToolStripMenuItem
            // 
            activoToolStripMenuItem.Name = "activoToolStripMenuItem";
            activoToolStripMenuItem.Size = new Size(127, 22);
            activoToolStripMenuItem.Text = "Activo";
            activoToolStripMenuItem.Click += activoToolStripMenuItem_Click;
            // 
            // noActivoToolStripMenuItem
            // 
            noActivoToolStripMenuItem.Name = "noActivoToolStripMenuItem";
            noActivoToolStripMenuItem.Size = new Size(127, 22);
            noActivoToolStripMenuItem.Text = "No Activo";
            noActivoToolStripMenuItem.Click += noActivoToolStripMenuItem_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(52, 67);
            toolStripButton5.Text = "Buscar";
            toolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tstBuscar
            // 
            tstBuscar.Name = "tstBuscar";
            tstBuscar.Size = new Size(120, 70);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 70);
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
            panel2.Location = new Point(0, 371);
            panel2.Name = "panel2";
            panel2.Size = new Size(732, 79);
            panel2.TabIndex = 1;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(608, 16);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(49, 44);
            btnUltimo.TabIndex = 20;
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Right_Button;
            btnSiguiente.Location = new Point(553, 19);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(49, 41);
            btnSiguiente.TabIndex = 19;
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(471, 19);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(49, 41);
            btnAnterior.TabIndex = 18;
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(416, 19);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(49, 41);
            btnPrimero.TabIndex = 17;
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(170, 45);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 16;
            lblPaginas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 45);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 15;
            label2.Text = "Cantidad de Paginas:";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(172, 23);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(13, 15);
            lblRegistros.TabIndex = 14;
            lblRegistros.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 23);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 13;
            label1.Text = "Cantidad de Registros:";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvDatos);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(732, 302);
            panel3.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.BackgroundColor = Color.FromArgb(192, 255, 255);
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colFormaDePagoId, colNombre, colActivo });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(732, 302);
            dgvDatos.TabIndex = 0;
            // 
            // colFormaDePagoId
            // 
            colFormaDePagoId.DataPropertyName = "IdFormaDePago";
            colFormaDePagoId.HeaderText = "Id";
            colFormaDePagoId.Name = "colFormaDePagoId";
            colFormaDePagoId.Visible = false;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            // 
            // colActivo
            // 
            colActivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo";
            colActivo.Name = "colActivo";
            // 
            // frmFormaDePago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmFormaDePago";
            Text = "frmFormaDePago";
            Load += frmFormaDePago_Load;
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
        private Panel panel2;
        private Panel panel3;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbBorrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton5;
        private ToolStripTextBox tstBuscar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbActualizar;
        private ToolStripButton tsbSalir;
        private DataGridView dgvDatos;
        private ToolStripSplitButton tsbFiltrar;
        private ToolStripMenuItem activoToolStripMenuItem;
        private ToolStripMenuItem noActivoToolStripMenuItem;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas;
        private Label label2;
        private Label lblRegistros;
        private Label label1;
        private DataGridViewTextBoxColumn colFormaDePagoId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewCheckBoxColumn colActivo;
    }
}