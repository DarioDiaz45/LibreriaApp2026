namespace LibreriaApp2026.Windows
{
    partial class frmVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenta));
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbDetalles = new ToolStripButton();
            tsbFacturar = new ToolStripButton();
            tsbAnular = new ToolStripButton();
            tstBuscar2 = new ToolStripButton();
            tstBuscar = new ToolStripTextBox();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbSalir = new ToolStripButton();
            panel1 = new Panel();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas = new Label();
            label2 = new Label();
            lblRegistros = new Label();
            label1 = new Label();
            panel2 = new Panel();
            dgvDatos = new DataGridView();
            colVentaId = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            conEstado = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbDetalles, tsbFacturar, tsbAnular, tstBuscar2, tstBuscar, tsbActualizar, toolStripSeparator1, tsbSalir });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 70);
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
            // tsbDetalles
            // 
            tsbDetalles.Image = (Image)resources.GetObject("tsbDetalles.Image");
            tsbDetalles.ImageScaling = ToolStripItemImageScaling.None;
            tsbDetalles.ImageTransparentColor = Color.Magenta;
            tsbDetalles.Name = "tsbDetalles";
            tsbDetalles.Size = new Size(52, 67);
            tsbDetalles.Text = "Detalles";
            tsbDetalles.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDetalles.Click += tsbDetalles_Click;
            // 
            // tsbFacturar
            // 
            tsbFacturar.Image = (Image)resources.GetObject("tsbFacturar.Image");
            tsbFacturar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFacturar.ImageTransparentColor = Color.Magenta;
            tsbFacturar.Name = "tsbFacturar";
            tsbFacturar.Size = new Size(54, 67);
            tsbFacturar.Text = "Facturar";
            tsbFacturar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFacturar.Click += tsbFacturar_Click;
            // 
            // tsbAnular
            // 
            tsbAnular.Image = (Image)resources.GetObject("tsbAnular.Image");
            tsbAnular.ImageScaling = ToolStripItemImageScaling.None;
            tsbAnular.ImageTransparentColor = Color.Magenta;
            tsbAnular.Name = "tsbAnular";
            tsbAnular.Size = new Size(52, 67);
            tsbAnular.Text = "Anular";
            tsbAnular.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAnular.Click += tsbAnular_Click;
            // 
            // tstBuscar2
            // 
            tstBuscar2.Image = (Image)resources.GetObject("tstBuscar2.Image");
            tstBuscar2.ImageScaling = ToolStripItemImageScaling.None;
            tstBuscar2.ImageTransparentColor = Color.Magenta;
            tstBuscar2.Name = "tstBuscar2";
            tstBuscar2.Size = new Size(52, 67);
            tstBuscar2.Text = "Buscar";
            tstBuscar2.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tstBuscar
            // 
            tstBuscar.Name = "tstBuscar";
            tstBuscar.Size = new Size(120, 70);
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
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
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnUltimo);
            panel1.Controls.Add(btnSiguiente);
            panel1.Controls.Add(btnAnterior);
            panel1.Controls.Add(btnPrimero);
            panel1.Controls.Add(lblPaginas);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblRegistros);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 367);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 83);
            panel1.TabIndex = 1;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.Last;
            btnUltimo.Location = new Point(618, 21);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(49, 44);
            btnUltimo.TabIndex = 28;
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.Right_Button;
            btnSiguiente.Location = new Point(563, 24);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(49, 41);
            btnSiguiente.TabIndex = 27;
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(481, 24);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(49, 41);
            btnAnterior.TabIndex = 26;
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(426, 24);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(49, 41);
            btnPrimero.TabIndex = 25;
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(180, 50);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(13, 15);
            lblPaginas.TabIndex = 24;
            lblPaginas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 50);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 23;
            label2.Text = "Cantidad de Paginas:";
            // 
            // lblRegistros
            // 
            lblRegistros.AutoSize = true;
            lblRegistros.Location = new Point(182, 28);
            lblRegistros.Name = "lblRegistros";
            lblRegistros.Size = new Size(13, 15);
            lblRegistros.TabIndex = 22;
            lblRegistros.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 28);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 21;
            label1.Text = "Cantidad de Registros:";
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvDatos);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 297);
            panel2.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.BackgroundColor = Color.FromArgb(192, 255, 255);
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colVentaId, colFecha, colCliente, colTotal, conEstado });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 297);
            dgvDatos.TabIndex = 0;
            // 
            // colVentaId
            // 
            colVentaId.DataPropertyName = "VentaId";
            colVentaId.HeaderText = "Venta Id";
            colVentaId.Name = "colVentaId";
            colVentaId.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaVenta";
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "Total";
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // conEstado
            // 
            conEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            conEstado.DataPropertyName = "EstadoVenta";
            conEstado.HeaderText = "Estado";
            conEstado.Name = "conEstado";
            conEstado.ReadOnly = true;
            // 
            // frmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "frmVenta";
            Text = "frmVenta";
            Load += frmVenta_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbDetalles;
        private ToolStripButton tsbFacturar;
        private ToolStripButton tsbAnular;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbSalir;
        private Panel panel1;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas;
        private Label label2;
        private Label lblRegistros;
        private Label label1;
        private Panel panel2;
        private DataGridView dgvDatos;
        private ToolStripButton tstBuscar2;
        private ToolStripTextBox tstBuscar;
        private DataGridViewTextBoxColumn colVentaId;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn conEstado;
    }
}