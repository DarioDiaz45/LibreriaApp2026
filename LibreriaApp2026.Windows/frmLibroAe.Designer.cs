namespace LibreriaApp2026.Windows
{
    partial class frmLibroAe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibroAe));
            grpTipo = new GroupBox();
            rdoDigital = new RadioButton();
            rdoFisico = new RadioButton();
            label1 = new Label();
            txtTitulo = new TextBox();
            label2 = new Label();
            txtDescripcion = new TextBox();
            label3 = new Label();
            nudAnio = new NumericUpDown();
            label4 = new Label();
            nudPrecio = new NumericUpDown();
            label5 = new Label();
            cboEditorial = new ComboBox();
            chkActivo = new CheckBox();
            label6 = new Label();
            cboAutor = new ComboBox();
            btnAgregarAutor = new Button();
            btnQuitarAutor = new Button();
            lstAutores = new ListBox();
            label7 = new Label();
            cboTema = new ComboBox();
            btnAgregarTema = new Button();
            lstTemas = new ListBox();
            btnQuitarTema = new Button();
            btnOK = new Button();
            btnCancelar = new Button();
            pnlDatosEspecificos = new Panel();
            panel1 = new Panel();
            grpLibroDigital = new GroupBox();
            txtURL = new TextBox();
            lblURL = new Label();
            nudTamano = new NumericUpDown();
            lblTamano = new Label();
            txtFormato = new TextBox();
            lblFormato = new Label();
            txtIdentificador = new TextBox();
            lblIdentificador = new Label();
            grpLibroFisico = new GroupBox();
            nudStock = new NumericUpDown();
            lblStock = new Label();
            txtISBN = new TextBox();
            lblISBN = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel2 = new Panel();
            grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            pnlDatosEspecificos.SuspendLayout();
            grpLibroDigital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamano).BeginInit();
            grpLibroFisico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // grpTipo
            // 
            grpTipo.Controls.Add(rdoDigital);
            grpTipo.Controls.Add(rdoFisico);
            grpTipo.Location = new Point(12, 12);
            grpTipo.Name = "grpTipo";
            grpTipo.Size = new Size(600, 50);
            grpTipo.TabIndex = 0;
            grpTipo.TabStop = false;
            grpTipo.Text = "Tipo de Libro";
            // 
            // rdoDigital
            // 
            rdoDigital.AutoSize = true;
            rdoDigital.Location = new Point(150, 20);
            rdoDigital.Name = "rdoDigital";
            rdoDigital.Size = new Size(59, 19);
            rdoDigital.TabIndex = 1;
            rdoDigital.TabStop = true;
            rdoDigital.Text = "Digital";
            rdoDigital.UseVisualStyleBackColor = true;
            rdoDigital.CheckedChanged += rdoTipo_CheckedChanged;
            // 
            // rdoFisico
            // 
            rdoFisico.AutoSize = true;
            rdoFisico.Checked = true;
            rdoFisico.Location = new Point(20, 20);
            rdoFisico.Name = "rdoFisico";
            rdoFisico.Size = new Size(55, 19);
            rdoFisico.TabIndex = 0;
            rdoFisico.TabStop = true;
            rdoFisico.Text = "Fisico";
            rdoFisico.UseVisualStyleBackColor = true;
            rdoFisico.CheckedChanged += rdoTipo_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 78);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "Titulo:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(98, 75);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(360, 23);
            txtTitulo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 113);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(98, 110);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(360, 23);
            txtDescripcion.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 186);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 5;
            label3.Text = "Año:";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(67, 184);
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(80, 23);
            nudAnio.TabIndex = 6;
            nudAnio.ValueChanged += nudAnio_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 186);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Precio:";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(250, 184);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(110, 23);
            nudPrecio.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 226);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 9;
            label5.Text = "Editorial:";
            // 
            // cboEditorial
            // 
            cboEditorial.FormattingEnabled = true;
            cboEditorial.Location = new Point(67, 223);
            cboEditorial.Name = "cboEditorial";
            cboEditorial.Size = new Size(187, 23);
            cboEditorial.TabIndex = 10;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(525, 79);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 12;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 303);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 13;
            label6.Text = "Autores:";
            // 
            // cboAutor
            // 
            cboAutor.FormattingEnabled = true;
            cboAutor.Location = new Point(14, 325);
            cboAutor.Name = "cboAutor";
            cboAutor.Size = new Size(190, 23);
            cboAutor.TabIndex = 14;
            // 
            // btnAgregarAutor
            // 
            btnAgregarAutor.Location = new Point(215, 323);
            btnAgregarAutor.Name = "btnAgregarAutor";
            btnAgregarAutor.Size = new Size(80, 25);
            btnAgregarAutor.TabIndex = 15;
            btnAgregarAutor.Text = "Agregar";
            btnAgregarAutor.UseVisualStyleBackColor = true;
            btnAgregarAutor.Click += btnAgregarAutor_Click_1;
            // 
            // btnQuitarAutor
            // 
            btnQuitarAutor.Location = new Point(215, 354);
            btnQuitarAutor.Name = "btnQuitarAutor";
            btnQuitarAutor.Size = new Size(67, 40);
            btnQuitarAutor.TabIndex = 16;
            btnQuitarAutor.Text = "Quitar";
            btnQuitarAutor.UseVisualStyleBackColor = true;
            btnQuitarAutor.Click += btnQuitarAutor_Click_1;
            // 
            // lstAutores
            // 
            lstAutores.FormattingEnabled = true;
            lstAutores.Location = new Point(14, 354);
            lstAutores.Name = "lstAutores";
            lstAutores.Size = new Size(190, 79);
            lstAutores.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(330, 303);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 18;
            label7.Text = "Temas:";
            // 
            // cboTema
            // 
            cboTema.FormattingEnabled = true;
            cboTema.Location = new Point(329, 325);
            cboTema.Name = "cboTema";
            cboTema.Size = new Size(190, 23);
            cboTema.TabIndex = 19;
            // 
            // btnAgregarTema
            // 
            btnAgregarTema.Location = new Point(525, 323);
            btnAgregarTema.Name = "btnAgregarTema";
            btnAgregarTema.Size = new Size(80, 25);
            btnAgregarTema.TabIndex = 20;
            btnAgregarTema.Text = "Agregar";
            btnAgregarTema.UseVisualStyleBackColor = true;
            btnAgregarTema.Click += btnAgregarTema_Click_1;
            // 
            // lstTemas
            // 
            lstTemas.FormattingEnabled = true;
            lstTemas.Location = new Point(327, 354);
            lstTemas.Name = "lstTemas";
            lstTemas.Size = new Size(190, 79);
            lstTemas.TabIndex = 21;
            // 
            // btnQuitarTema
            // 
            btnQuitarTema.Location = new Point(525, 354);
            btnQuitarTema.Name = "btnQuitarTema";
            btnQuitarTema.Size = new Size(67, 40);
            btnQuitarTema.TabIndex = 22;
            btnQuitarTema.Text = "Quitar";
            btnQuitarTema.UseVisualStyleBackColor = true;
            btnQuitarTema.Click += btnQuitarTema_Click_1;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaption;
            btnOK.Image = (Image)resources.GetObject("btnOK.Image");
            btnOK.Location = new Point(181, 17);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(83, 66);
            btnOK.TabIndex = 23;
            btnOK.Text = "OK";
            btnOK.TextAlign = ContentAlignment.BottomCenter;
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ActiveCaption;
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.Location = new Point(333, 17);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 66);
            btnCancelar.TabIndex = 24;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.BottomCenter;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlDatosEspecificos
            // 
            pnlDatosEspecificos.Controls.Add(panel1);
            pnlDatosEspecificos.Controls.Add(grpLibroDigital);
            pnlDatosEspecificos.Controls.Add(grpLibroFisico);
            pnlDatosEspecificos.Location = new Point(14, 452);
            pnlDatosEspecificos.Name = "pnlDatosEspecificos";
            pnlDatosEspecificos.Size = new Size(592, 186);
            pnlDatosEspecificos.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(331, 100);
            panel1.TabIndex = 26;
            // 
            // grpLibroDigital
            // 
            grpLibroDigital.Controls.Add(txtURL);
            grpLibroDigital.Controls.Add(lblURL);
            grpLibroDigital.Controls.Add(nudTamano);
            grpLibroDigital.Controls.Add(lblTamano);
            grpLibroDigital.Controls.Add(txtFormato);
            grpLibroDigital.Controls.Add(lblFormato);
            grpLibroDigital.Controls.Add(txtIdentificador);
            grpLibroDigital.Controls.Add(lblIdentificador);
            grpLibroDigital.Location = new Point(331, 19);
            grpLibroDigital.Name = "grpLibroDigital";
            grpLibroDigital.Size = new Size(250, 164);
            grpLibroDigital.TabIndex = 1;
            grpLibroDigital.TabStop = false;
            grpLibroDigital.Text = "Libro Digital";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(43, 124);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(201, 23);
            txtURL.TabIndex = 9;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(6, 127);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(31, 15);
            lblURL.TabIndex = 8;
            lblURL.Text = "URL:";
            // 
            // nudTamano
            // 
            nudTamano.Location = new Point(89, 85);
            nudTamano.Name = "nudTamano";
            nudTamano.Size = new Size(61, 23);
            nudTamano.TabIndex = 7;
            // 
            // lblTamano
            // 
            lblTamano.AutoSize = true;
            lblTamano.Location = new Point(6, 87);
            lblTamano.Name = "lblTamano";
            lblTamano.Size = new Size(53, 15);
            lblTamano.TabIndex = 6;
            lblTamano.Text = "Tamaño:";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(89, 55);
            txtFormato.Name = "txtFormato";
            txtFormato.Size = new Size(155, 23);
            txtFormato.TabIndex = 5;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(6, 57);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(55, 15);
            lblFormato.TabIndex = 4;
            lblFormato.Text = "Formato:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.Location = new Point(89, 26);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(155, 23);
            txtIdentificador.TabIndex = 3;
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Location = new Point(6, 29);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(77, 15);
            lblIdentificador.TabIndex = 2;
            lblIdentificador.Text = "Identificador:";
            // 
            // grpLibroFisico
            // 
            grpLibroFisico.Controls.Add(nudStock);
            grpLibroFisico.Controls.Add(lblStock);
            grpLibroFisico.Controls.Add(txtISBN);
            grpLibroFisico.Controls.Add(lblISBN);
            grpLibroFisico.Location = new Point(12, 19);
            grpLibroFisico.Name = "grpLibroFisico";
            grpLibroFisico.Size = new Size(250, 164);
            grpLibroFisico.TabIndex = 0;
            grpLibroFisico.TabStop = false;
            grpLibroFisico.Text = "Libro Fisico";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(51, 63);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(171, 23);
            nudStock.TabIndex = 2;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(1, 65);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 26;
            lblStock.Text = "Stock:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(51, 26);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(171, 23);
            txtISBN.TabIndex = 2;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(5, 29);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(35, 15);
            lblISBN.TabIndex = 2;
            lblISBN.Text = "ISBN:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(btnCancelar);
            panel2.Controls.Add(btnOK);
            panel2.Location = new Point(12, 644);
            panel2.Name = "panel2";
            panel2.Size = new Size(593, 100);
            panel2.TabIndex = 26;
            // 
            // frmLibroAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(625, 458);
            Controls.Add(panel2);
            Controls.Add(pnlDatosEspecificos);
            Controls.Add(btnQuitarTema);
            Controls.Add(lstTemas);
            Controls.Add(btnAgregarTema);
            Controls.Add(cboTema);
            Controls.Add(label7);
            Controls.Add(lstAutores);
            Controls.Add(btnQuitarAutor);
            Controls.Add(btnAgregarAutor);
            Controls.Add(cboAutor);
            Controls.Add(label6);
            Controls.Add(chkActivo);
            Controls.Add(cboEditorial);
            Controls.Add(label5);
            Controls.Add(nudPrecio);
            Controls.Add(label4);
            Controls.Add(nudAnio);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(label1);
            Controls.Add(grpTipo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLibroAe";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmLibro";
            grpTipo.ResumeLayout(false);
            grpTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            pnlDatosEspecificos.ResumeLayout(false);
            grpLibroDigital.ResumeLayout(false);
            grpLibroDigital.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamano).EndInit();
            grpLibroFisico.ResumeLayout(false);
            grpLibroFisico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpTipo;
        private RadioButton rdoDigital;
        private RadioButton rdoFisico;
        private Label label1;
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtDescripcion;
        private Label label3;
        private NumericUpDown nudAnio;
        private Label label4;
        private NumericUpDown nudPrecio;
        private Label label5;
        private ComboBox cboEditorial;
        private CheckBox chkActivo;
        private Label label6;
        private ComboBox cboAutor;
        private Button btnAgregarAutor;
        private Button btnQuitarAutor;
        private ListBox lstAutores;
        private Label label7;
        private ComboBox cboTema;
        private Button btnAgregarTema;
        private ListBox lstTemas;
        private Button btnQuitarTema;
        private Button btnOK;
        private Button btnCancelar;
        private Panel pnlDatosEspecificos;
        private GroupBox grpLibroDigital;
        private GroupBox grpLibroFisico;
        private TextBox txtIdentificador;
        private Label lblIdentificador;
        private NumericUpDown nudStock;
        private Label lblStock;
        private TextBox txtISBN;
        private Label lblISBN;
        private TextBox txtURL;
        private Label lblURL;
        private NumericUpDown nudTamano;
        private Label lblTamano;
        private TextBox txtFormato;
        private Label lblFormato;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private Panel panel2;
    }
}