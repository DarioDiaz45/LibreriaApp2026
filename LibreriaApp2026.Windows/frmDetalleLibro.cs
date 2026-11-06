using LibreriaApp2026.Servicios.DTOs.Libro;

namespace LibreriaApp2026.Windows
{
    public partial class frmDetalleLibro : Form
    {
        public frmDetalleLibro()
        {
            InitializeComponent();
            nudAnio.Minimum = 0;
            nudAnio.Maximum = 9999;
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Maximum = 9999999999M;


            Deshabilitar(this);
        }

        private void Deshabilitar(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is Button || c is ListBox || c is Label || c is DataGridView) continue;

                c.Enabled = false;
                Deshabilitar(c);
            }
        }


        public void MostrarLibro(LibroDetailDto d)
        {
            bool esFisico = d.Tipo == "Físico";
            rdoFisico.Checked = esFisico;
            rdoDigital.Checked = !esFisico;
            ActualizarPanelTipo();

            txtTitulo.Text = d.Titulo;
            txtDescripcion.Text = d.Descripcion;
            nudAnio.Value = d.AnioPublicacion;
            nudPrecio.Value = d.Precio;
            txtEditorial.Text = d.Editorial;
            chkActivo.Checked = d.Activo;

            lstAutores.Items.Clear();
            foreach (var autor in d.Autores)
            {
                lstAutores.Items.Add(autor);
            }

            lstTemas.Items.Clear();
            foreach (var tema in d.Temas)
            {
                lstTemas.Items.Add(tema);
            }

            if (esFisico)
            {
                txtISBN.Text = d.ISBN;
                nudStock.Value = d.Stock ?? 0;
            }
            else
            {
                txtIdentificador.Text = d.Identificador;
                txtFormato.Text = d.Formato;
                nudTamano.Value = d.TamanoArchivo ?? 0;
                txtURL.Text = d.UrlDescarga;
            }
        }

        private void ActualizarPanelTipo()
        {
            grpFisico.Visible = rdoFisico.Checked;
            grpDigital.Visible = rdoDigital.Checked;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
