namespace LibreriaApp2026.Windows
{
    partial class frmVentasAe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasAe));
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblFormaDePago = new Label();
            cboFormaDePago = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblEstado = new Label();
            txtEstado = new TextBox();
            dgvDatos = new DataGridView();
            colLibroId = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            btnAgregarLibro = new Button();
            btnEditarCantidad = new Button();
            btnQuitarLibro = new Button();
            lblTotalVenta = new Label();
            txtTotalVenta = new TextBox();
            btnCancelar = new Button();
            btnOK = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(45, 23);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(112, 20);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(184, 23);
            cboCliente.TabIndex = 1;
            // 
            // lblFormaDePago
            // 
            lblFormaDePago.AutoSize = true;
            lblFormaDePago.Location = new Point(12, 57);
            lblFormaDePago.Name = "lblFormaDePago";
            lblFormaDePago.Size = new Size(91, 15);
            lblFormaDePago.TabIndex = 2;
            lblFormaDePago.Text = "Forma De Pago:";
            // 
            // cboFormaDePago
            // 
            cboFormaDePago.FormattingEnabled = true;
            cboFormaDePago.Location = new Point(112, 54);
            cboFormaDePago.Name = "cboFormaDePago";
            cboFormaDePago.Size = new Size(184, 23);
            cboFormaDePago.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(447, 23);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(494, 20);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(217, 23);
            dtpFecha.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(447, 57);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(498, 54);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(164, 23);
            txtEstado.TabIndex = 7;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.BackgroundColor = SystemColors.ActiveCaption;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colLibroId, colLibro, colPrecio, colCantidad, colSubTotal });
            dgvDatos.Location = new Point(12, 116);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(524, 250);
            dgvDatos.TabIndex = 8;
            // 
            // colLibroId
            // 
            colLibroId.DataPropertyName = "LibroId";
            colLibroId.HeaderText = "Id";
            colLibroId.Name = "colLibroId";
            colLibroId.Visible = false;
            // 
            // colLibro
            // 
            colLibro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLibro.DataPropertyName = "Libro";
            colLibro.HeaderText = "Libro";
            colLibro.Name = "colLibro";
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "Precio";
            colPrecio.HeaderText = "Precio Unit.";
            colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            // 
            // colSubTotal
            // 
            colSubTotal.DataPropertyName = "SubTotal";
            colSubTotal.HeaderText = "SubTotal";
            colSubTotal.Name = "colSubTotal";
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.BackColor = SystemColors.ActiveCaption;
            btnAgregarLibro.Image = (Image)resources.GetObject("btnAgregarLibro.Image");
            btnAgregarLibro.Location = new Point(571, 116);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(121, 47);
            btnAgregarLibro.TabIndex = 9;
            btnAgregarLibro.Text = "Agregar Libro";
            btnAgregarLibro.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarLibro.UseVisualStyleBackColor = false;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnEditarCantidad
            // 
            btnEditarCantidad.BackColor = SystemColors.ActiveCaption;
            btnEditarCantidad.Location = new Point(569, 200);
            btnEditarCantidad.Name = "btnEditarCantidad";
            btnEditarCantidad.Size = new Size(123, 47);
            btnEditarCantidad.TabIndex = 10;
            btnEditarCantidad.Text = "Editar Cantidad";
            btnEditarCantidad.UseVisualStyleBackColor = false;
            btnEditarCantidad.Click += btnEditarCantidad_Click;
            // 
            // btnQuitarLibro
            // 
            btnQuitarLibro.BackColor = SystemColors.ActiveCaption;
            btnQuitarLibro.Image = (Image)resources.GetObject("btnQuitarLibro.Image");
            btnQuitarLibro.Location = new Point(571, 294);
            btnQuitarLibro.Name = "btnQuitarLibro";
            btnQuitarLibro.Size = new Size(121, 47);
            btnQuitarLibro.TabIndex = 11;
            btnQuitarLibro.Text = "Quitar Libro";
            btnQuitarLibro.TextImageRelation = TextImageRelation.ImageAboveText;
            btnQuitarLibro.UseVisualStyleBackColor = false;
            btnQuitarLibro.Click += btnQuitarLibro_Click;
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Location = new Point(24, 397);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(68, 15);
            lblTotalVenta.TabIndex = 12;
            lblTotalVenta.Text = "Total Venta:";
            // 
            // txtTotalVenta
            // 
            txtTotalVenta.Location = new Point(98, 394);
            txtTotalVenta.Name = "txtTotalVenta";
            txtTotalVenta.Size = new Size(160, 23);
            txtTotalVenta.TabIndex = 13;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(494, 445);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 64);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaption;
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(76, 445);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 64);
            btnOK.TabIndex = 14;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmVentasAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(723, 521);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtTotalVenta);
            Controls.Add(lblTotalVenta);
            Controls.Add(btnQuitarLibro);
            Controls.Add(btnEditarCantidad);
            Controls.Add(btnAgregarLibro);
            Controls.Add(dgvDatos);
            Controls.Add(txtEstado);
            Controls.Add(lblEstado);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cboFormaDePago);
            Controls.Add(lblFormaDePago);
            Controls.Add(cboCliente);
            Controls.Add(lblCliente);
            Name = "frmVentasAe";
            Text = "frmVentasAe";
            Load += frmVentasAe_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblFormaDePago;
        private ComboBox cboFormaDePago;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblEstado;
        private TextBox txtEstado;
        private DataGridView dgvDatos;
        private Button btnAgregarLibro;
        private Button btnEditarCantidad;
        private Button btnQuitarLibro;
        private Label lblTotalVenta;
        private TextBox txtTotalVenta;
        private Button btnCancelar;
        private Button btnOK;
        private DataGridViewTextBoxColumn colLibroId;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubTotal;
        private ErrorProvider errorProvider1;
    }
}