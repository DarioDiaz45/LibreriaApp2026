namespace LibreriaApp2026.Windows
{
    partial class frmDetalleLibro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalleLibro));
            lstTemas = new ListBox();
            label7 = new Label();
            lstAutores = new ListBox();
            label6 = new Label();
            chkActivo = new CheckBox();
            label5 = new Label();
            nudPrecio = new NumericUpDown();
            label4 = new Label();
            nudAnio = new NumericUpDown();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            txtTitulo = new TextBox();
            label1 = new Label();
            grpTipo = new GroupBox();
            rdoDigital = new RadioButton();
            rdoFisico = new RadioButton();
            btnCerrar = new Button();
            txtEditorial = new TextBox();
            txtURL = new TextBox();
            lblURL = new Label();
            nudTamano = new NumericUpDown();
            lblTamano = new Label();
            txtFormato = new TextBox();
            lblFormato = new Label();
            txtIdentificador = new TextBox();
            lblIdentificador = new Label();
            nudStock = new NumericUpDown();
            lblStock = new Label();
            txtISBN = new TextBox();
            lblISBN = new Label();
            grpFisico = new GroupBox();
            grpDigital = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            grpTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamano).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            grpFisico.SuspendLayout();
            grpDigital.SuspendLayout();
            SuspendLayout();
            // 
            // lstTemas
            // 
            lstTemas.FormattingEnabled = true;
            lstTemas.Location = new Point(343, 341);
            lstTemas.Name = "lstTemas";
            lstTemas.Size = new Size(242, 109);
            lstTemas.TabIndex = 43;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(347, 317);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 40;
            label7.Text = "Temas:";
            // 
            // lstAutores
            // 
            lstAutores.FormattingEnabled = true;
            lstAutores.Location = new Point(38, 337);
            lstAutores.Name = "lstAutores";
            lstAutores.Size = new Size(224, 109);
            lstAutores.TabIndex = 39;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 317);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 35;
            label6.Text = "Autores:";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(543, 71);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 34;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 250);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 32;
            label5.Text = "Editorial:";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(85, 213);
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(110, 23);
            nudPrecio.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 215);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 30;
            label4.Text = "Precio:";
            // 
            // nudAnio
            // 
            nudAnio.Location = new Point(85, 176);
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(80, 23);
            nudAnio.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 178);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 28;
            label3.Text = "Año:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(116, 102);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(360, 23);
            txtDescripcion.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 105);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 26;
            label2.Text = "Descripcion:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(116, 67);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(360, 23);
            txtTitulo.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 70);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 24;
            label1.Text = "Titulo:";
            // 
            // grpTipo
            // 
            grpTipo.Controls.Add(rdoDigital);
            grpTipo.Controls.Add(rdoFisico);
            grpTipo.Location = new Point(30, 4);
            grpTipo.Name = "grpTipo";
            grpTipo.Size = new Size(600, 50);
            grpTipo.TabIndex = 23;
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
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = SystemColors.ActiveCaption;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(268, 636);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 66);
            btnCerrar.TabIndex = 45;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextAlign = ContentAlignment.BottomCenter;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(85, 247);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.Size = new Size(177, 23);
            txtEditorial.TabIndex = 46;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(81, 106);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(201, 23);
            txtURL.TabIndex = 54;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(6, 109);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(31, 15);
            lblURL.TabIndex = 53;
            lblURL.Text = "URL:";
            // 
            // nudTamano
            // 
            nudTamano.Location = new Point(81, 80);
            nudTamano.Name = "nudTamano";
            nudTamano.Size = new Size(61, 23);
            nudTamano.TabIndex = 52;
            // 
            // lblTamano
            // 
            lblTamano.AutoSize = true;
            lblTamano.Location = new Point(0, 82);
            lblTamano.Name = "lblTamano";
            lblTamano.Size = new Size(53, 15);
            lblTamano.TabIndex = 51;
            lblTamano.Text = "Tamaño:";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(81, 55);
            txtFormato.Name = "txtFormato";
            txtFormato.Size = new Size(155, 23);
            txtFormato.TabIndex = 50;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(0, 56);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(55, 15);
            lblFormato.TabIndex = 49;
            lblFormato.Text = "Formato:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.Location = new Point(81, 27);
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(155, 23);
            txtIdentificador.TabIndex = 48;
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Location = new Point(0, 30);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(77, 15);
            lblIdentificador.TabIndex = 47;
            lblIdentificador.Text = "Identificador:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(43, 56);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(171, 23);
            nudStock.TabIndex = 55;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(2, 60);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 58;
            lblStock.Text = "Stock:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(43, 27);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(171, 23);
            txtISBN.TabIndex = 56;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(2, 30);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(35, 15);
            lblISBN.TabIndex = 57;
            lblISBN.Text = "ISBN:";
            // 
            // grpFisico
            // 
            grpFisico.Controls.Add(lblISBN);
            grpFisico.Controls.Add(nudStock);
            grpFisico.Controls.Add(txtISBN);
            grpFisico.Controls.Add(lblStock);
            grpFisico.Location = new Point(38, 468);
            grpFisico.Name = "grpFisico";
            grpFisico.Size = new Size(224, 136);
            grpFisico.TabIndex = 59;
            grpFisico.TabStop = false;
            grpFisico.Text = "Libro Fisico";
            // 
            // grpDigital
            // 
            grpDigital.Controls.Add(lblIdentificador);
            grpDigital.Controls.Add(txtIdentificador);
            grpDigital.Controls.Add(txtURL);
            grpDigital.Controls.Add(lblFormato);
            grpDigital.Controls.Add(lblURL);
            grpDigital.Controls.Add(txtFormato);
            grpDigital.Controls.Add(nudTamano);
            grpDigital.Controls.Add(lblTamano);
            grpDigital.Location = new Point(343, 468);
            grpDigital.Name = "grpDigital";
            grpDigital.Size = new Size(297, 136);
            grpDigital.TabIndex = 60;
            grpDigital.TabStop = false;
            grpDigital.Text = "Libro Digital";
            // 
            // frmDetalleLibro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(656, 714);
            Controls.Add(grpDigital);
            Controls.Add(grpFisico);
            Controls.Add(txtEditorial);
            Controls.Add(btnCerrar);
            Controls.Add(lstTemas);
            Controls.Add(label7);
            Controls.Add(lstAutores);
            Controls.Add(label6);
            Controls.Add(chkActivo);
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
            Name = "frmDetalleLibro";
            Text = "frmDetalleLibro";
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            grpTipo.ResumeLayout(false);
            grpTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTamano).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            grpFisico.ResumeLayout(false);
            grpFisico.PerformLayout();
            grpDigital.ResumeLayout(false);
            grpDigital.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private ListBox lstTemas;
       
        
        private Label label7;
        private ListBox lstAutores;
        
        
        
        private Label label6;
        private CheckBox chkActivo;
        
        private Label label5;
        private NumericUpDown nudPrecio;
        private Label label4;
        private NumericUpDown nudAnio;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label2;
        private TextBox txtTitulo;
        private Label label1;
        private GroupBox grpTipo;
        private RadioButton rdoDigital;
        private RadioButton rdoFisico;
        private Button btnCerrar;
        private TextBox txtEditorial;
        private TextBox txtURL;
        private Label lblURL;
        private NumericUpDown nudTamano;
        private Label lblTamano;
        private TextBox txtFormato;
        private Label lblFormato;
        private TextBox txtIdentificador;
        private Label lblIdentificador;
        private NumericUpDown nudStock;
        private Label lblStock;
        private TextBox txtISBN;
        private Label lblISBN;
        private GroupBox grpFisico;
        private GroupBox grpDigital;
    }
}