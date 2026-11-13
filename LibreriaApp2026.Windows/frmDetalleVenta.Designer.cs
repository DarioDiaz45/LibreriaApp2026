namespace LibreriaApp2026.Windows
{
    partial class frmDetalleVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleVenta));
            lblIdVenta = new Label();
            txtVentaId = new TextBox();
            lblFecha = new Label();
            txtFecha = new TextBox();
            lblCliente = new Label();
            txtCliente = new TextBox();
            lblFormaDePago = new Label();
            txtFormaDePago = new TextBox();
            txtEstado = new TextBox();
            lblEstado = new Label();
            dgvDatos = new DataGridView();
            colLibro = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubTotal = new DataGridViewTextBoxColumn();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // lblIdVenta
            // 
            lblIdVenta.AutoSize = true;
            lblIdVenta.Location = new Point(37, 27);
            lblIdVenta.Name = "lblIdVenta";
            lblIdVenta.Size = new Size(52, 15);
            lblIdVenta.TabIndex = 0;
            lblIdVenta.Text = "Id Venta:";
            // 
            // txtVentaId
            // 
            txtVentaId.Location = new Point(95, 24);
            txtVentaId.Name = "txtVentaId";
            txtVentaId.ReadOnly = true;
            txtVentaId.Size = new Size(165, 23);
            txtVentaId.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(37, 67);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(95, 64);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(165, 23);
            txtFecha.TabIndex = 3;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(361, 27);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(414, 24);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(161, 23);
            txtCliente.TabIndex = 5;
            // 
            // lblFormaDePago
            // 
            lblFormaDePago.AutoSize = true;
            lblFormaDePago.Location = new Point(317, 64);
            lblFormaDePago.Name = "lblFormaDePago";
            lblFormaDePago.Size = new Size(91, 15);
            lblFormaDePago.TabIndex = 6;
            lblFormaDePago.Text = "Forma De Pago:";
            // 
            // txtFormaDePago
            // 
            txtFormaDePago.Location = new Point(414, 61);
            txtFormaDePago.Name = "txtFormaDePago";
            txtFormaDePago.ReadOnly = true;
            txtFormaDePago.Size = new Size(161, 23);
            txtFormaDePago.TabIndex = 7;
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(95, 114);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(165, 23);
            txtEstado.TabIndex = 8;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(37, 117);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 9;
            lblEstado.Text = "Estado:";
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.BackgroundColor = SystemColors.ActiveCaption;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colLibro, colPrecio, colCantidad, colSubTotal });
            dgvDatos.Location = new Point(37, 165);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(538, 175);
            dgvDatos.TabIndex = 10;
            // 
            // colLibro
            // 
            colLibro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLibro.DataPropertyName = "Libro";
            colLibro.HeaderText = "Libro";
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "Precio";
            colPrecio.HeaderText = "Precio Unit.";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colSubTotal
            // 
            colSubTotal.DataPropertyName = "SubTotal";
            colSubTotal.HeaderText = "SubTotal";
            colSubTotal.Name = "colSubTotal";
            colSubTotal.ReadOnly = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(40, 380);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 15);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(82, 377);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(140, 23);
            txtTotal.TabIndex = 12;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.ActiveCaption;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(434, 362);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 56);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(654, 450);
            Controls.Add(btnCerrar);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(dgvDatos);
            Controls.Add(lblEstado);
            Controls.Add(txtEstado);
            Controls.Add(txtFormaDePago);
            Controls.Add(lblFormaDePago);
            Controls.Add(txtCliente);
            Controls.Add(lblCliente);
            Controls.Add(txtFecha);
            Controls.Add(lblFecha);
            Controls.Add(txtVentaId);
            Controls.Add(lblIdVenta);
            Name = "frmDetalleVenta";
            Text = "frmDetalleVenta";
            Load += frmDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdVenta;
        private TextBox txtVentaId;
        private Label lblFecha;
        private TextBox txtFecha;
        private Label lblCliente;
        private TextBox txtCliente;
        private Label lblFormaDePago;
        private TextBox txtFormaDePago;
        private TextBox txtEstado;
        private Label lblEstado;
        private DataGridView dgvDatos;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnCerrar;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubTotal;
    }
}