using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.DetalleVenta;
using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Windows
{
    public partial class frmAgregarLibroDetalle : Form
    {
        private List<LibroVentaDto> _todosLosLibros = new();
        private BindingSource _bindingSource = new BindingSource();
        private LibroVentaDto? _libroSeleccionado;
        private DetalleVentaDto? _detalleVenta;
        public frmAgregarLibroDetalle()
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
            _bindingSource.CurrentChanged += (s, e) => SeleccionarActual();

            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 1;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;

            cboTipo.Items.AddRange(new object[] { "Todos", "Físico", "Digital" });
            cboTipo.SelectedIndex = 0;
        }

        private void SeleccionarActual()
        {
            _libroSeleccionado = _bindingSource.Current as LibroVentaDto;

            if (_libroSeleccionado is null)
            {
                LimpiarCampos();
                return;
            }

            MostrarDatos(_libroSeleccionado);
        }

        internal void SetDatos(List<LibroVentaDto>? libros)
        {
            _todosLosLibros = libros ?? new List<LibroVentaDto>();
            Filtrar();
        }

        public DetalleVentaDto? GetDetalleVenta() => _detalleVenta;
        private void Filtrar()
        {
            string texto = txtBuscar.Text.Trim();
            string? tipo = cboTipo.SelectedItem?.ToString();

            var filtrados = _todosLosLibros
                .Where(l =>
                    (string.IsNullOrEmpty(texto)
                        || l.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase)
                        || l.Codigo.Contains(texto, StringComparison.OrdinalIgnoreCase))
                    && (tipo is null || tipo == "Todos" || l.Tipo == tipo))
                .ToList();

            _bindingSource.DataSource = filtrados;
            SeleccionarActual();
        }
        private void LimpiarCampos()
        {
            txtLibro.Clear();
            txtPrecioUnitario.Clear();
            txtPrecioTotal.Clear();
            nudCantidad.Maximum = 1;
            nudCantidad.Value = 1;
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            Filtrar();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                _libroSeleccionado = null;
                return;
            }

            _libroSeleccionado = _bindingSource[e.RowIndex] as LibroVentaDto;
            if (_libroSeleccionado is null) return;

            MostrarDatos(_libroSeleccionado);
        }

        private void MostrarDatos(LibroVentaDto libro)
        {
            txtLibro.Text = libro.Titulo;
            txtPrecioUnitario.Text = libro.Precio.ToString("C2");

            
            
            int max = libro.Stock ?? 1000;
            if (max < 1)
            {
                nudCantidad.Maximum = 1;
                nudCantidad.Value = 1;
                errorProvider1.SetError(txtLibro, "Este libro no tiene stock");
                
            }
            else
            {
                errorProvider1.SetError(txtLibro, "");
                nudCantidad.Maximum = max;
                nudCantidad.Value = 1;
            }
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            if (_libroSeleccionado is null) return;
            txtPrecioTotal.Text = (_libroSeleccionado.Precio * nudCantidad.Value).ToString("C2");
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            _detalleVenta = new DetalleVentaDto
            {
                LibroId = _libroSeleccionado!.Id,
                Libro = _libroSeleccionado.Titulo,
                Precio = _libroSeleccionado.Precio,
                Cantidad = (int)nudCantidad.Value,
                Stock = _libroSeleccionado.Stock
            };
            DialogResult = DialogResult.OK;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();

            if (_libroSeleccionado.Stock is 0)
            {
                errorProvider1.SetError(txtLibro, "Este libro no tiene stock");
                return false;
            }
            return true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
