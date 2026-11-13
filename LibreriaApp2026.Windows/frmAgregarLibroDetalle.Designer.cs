namespace LibreriaApp2026.Windows
{
    partial class frmAgregarLibroDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarLibroDetalle));
            dgvDatos = new DataGridView();
            colTipo = new DataGridViewTextBoxColumn();
            colCodigo = new DataGridViewTextBoxColumn();
            colTitulo = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            lblLibro = new Label();
            txtLibro = new TextBox();
            lblPrecioUnitario = new Label();
            txtPrecioUnitario = new TextBox();
            nudCantidad = new NumericUpDown();
            lblCantidad = new Label();
            lblTotal = new Label();
            txtPrecioTotal = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            btnBuscar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToOrderColumns = true;
            dgvDatos.BackgroundColor = SystemColors.ActiveCaption;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colTipo, colCodigo, colTitulo, colPrecio, colStock });
            dgvDatos.Location = new Point(11, 83);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(620, 250);
            dgvDatos.TabIndex = 0;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            // 
            // colCodigo
            // 
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCodigo.DataPropertyName = "Codigo";
            colCodigo.HeaderText = "Codigo";
            colCodigo.Name = "colCodigo";
            // 
            // colTitulo
            // 
            colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitulo.DataPropertyName = "Titulo";
            colTitulo.HeaderText = "Titulo";
            colTitulo.Name = "colTitulo";
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrecio.DataPropertyName = "Precio";
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";
            // 
            // colStock
            // 
            colStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Name = "colStock";
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Location = new Point(63, 355);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(37, 15);
            lblLibro.TabIndex = 1;
            lblLibro.Text = "Libro:";
            // 
            // txtLibro
            // 
            txtLibro.Location = new Point(106, 352);
            txtLibro.Name = "txtLibro";
            txtLibro.Size = new Size(179, 23);
            txtLibro.TabIndex = 2;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(12, 384);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(88, 15);
            lblPrecioUnitario.TabIndex = 3;
            lblPrecioUnitario.Text = "Precio Unitario:";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(106, 381);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(179, 23);
            txtPrecioUnitario.TabIndex = 4;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(427, 352);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(120, 23);
            nudCantidad.TabIndex = 5;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(352, 355);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(352, 384);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 15);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total:";
            // 
            // txtPrecioTotal
            // 
            txtPrecioTotal.Location = new Point(426, 381);
            txtPrecioTotal.Name = "txtPrecioTotal";
            txtPrecioTotal.Size = new Size(121, 23);
            txtPrecioTotal.TabIndex = 8;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaption;
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(106, 420);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 64);
            btnOK.TabIndex = 9;
            btnOK.Text = "OK";
            btnOK.TextAlign = ContentAlignment.BottomCenter;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(384, 420);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 64);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.BottomCenter;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(25, 20);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(37, 15);
            lblBuscar.TabIndex = 11;
            lblBuscar.Text = "Libro:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(68, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(160, 23);
            txtBuscar.TabIndex = 12;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(24, 54);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 13;
            lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(68, 51);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(160, 23);
            cboTipo.TabIndex = 14;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.ActiveCaption;
            btnBuscar.Location = new Point(437, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 28);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAgregarLibroDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(643, 504);
            Controls.Add(btnBuscar);
            Controls.Add(cboTipo);
            Controls.Add(lblTipo);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtPrecioTotal);
            Controls.Add(lblTotal);
            Controls.Add(lblCantidad);
            Controls.Add(nudCantidad);
            Controls.Add(txtPrecioUnitario);
            Controls.Add(lblPrecioUnitario);
            Controls.Add(txtLibro);
            Controls.Add(lblLibro);
            Controls.Add(dgvDatos);
            Name = "frmAgregarLibroDetalle";
            Text = "frmAgregarLibroDetalle";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;
        private Label lblLibro;
        private TextBox txtLibro;
        private Label lblPrecioUnitario;
        private TextBox txtPrecioUnitario;
        private NumericUpDown nudCantidad;
        private Label lblCantidad;
        private Label lblTotal;
        private TextBox txtPrecioTotal;
        private Button btnOK;
        private Button btnCancelar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Button btnBuscar;
        private ErrorProvider errorProvider1;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colStock;
    }
}