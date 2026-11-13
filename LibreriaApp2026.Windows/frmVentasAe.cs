using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Servicios.DTOs.DetalleVenta;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Servicios;
using LibreriaApp2026.Windows.Classes;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibreriaApp2026.Windows
{
    public partial class frmVentasAe : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IVentaServicio _ventaServicio;
        private ServicioMensajes _servicioMensajes = new();

        private VentaCreateDto _ventaDto = new();
        private EditorVenta _editorVenta = null!;
        private List<LibroVentaDto> _librosParaVenta = new();
        private BindingSource _bindingSource = new BindingSource();
        public frmVentasAe(IServiceProvider serviceProvider, IVentaServicio ventaServicio)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _ventaServicio = ventaServicio;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
        }
        internal VentaCreateDto GetVenta() => _ventaDto;

        private void frmVentasAe_Load(object sender, EventArgs e)
        {
            try
            {
                _ventaDto = new VentaCreateDto();
                _editorVenta = new EditorVenta(_ventaDto);

                var resultadoLibros = _ventaServicio.ObtenerLibrosParaVenta();
                if (resultadoLibros.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoLibros.Errors);
                    DialogResult = DialogResult.Cancel;
                    return;
                }
                _librosParaVenta = resultadoLibros.Value!;

                CargarComboClientes();
                CargarComboFormasDePago();

                dtpFecha.Value = DateTime.Today;
                txtEstado.Text = EstadoVenta.Pendiente.ToString();
                txtTotalVenta.Text = 0m.ToString("C2");
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message);
            }
        }

        private void CargarComboFormasDePago()
        {
            var resultado = _ventaServicio.ObtenerFormasDePago();
            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            var formas = resultado.Value!;
            formas.Insert(0, new FormaDePagoComboDto { Id = 0, Nombre = "(Seleccione)" });

            cboFormaDePago.DataSource = formas;
            cboFormaDePago.DisplayMember = "Nombre";
            cboFormaDePago.ValueMember = "Id";
            cboFormaDePago.SelectedIndex = 0;
        }

        private void CargarComboClientes()
        {
            var resultado = _ventaServicio.ObtenerClientes();
            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            var clientes = resultado.Value!;
            clientes.Insert(0, new ClienteComboDto { Id = 0, NombreCompleto = "(Seleccione)" });

            cboCliente.DataSource = clientes;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "Id";
            cboCliente.SelectedIndex = 0;
        }
        private void MostrarDetalles((IReadOnlyCollection<DetalleVentaDto> Detalles, decimal Total) resumen)
        {
            _bindingSource.DataSource = resumen.Detalles.ToList();
            _bindingSource.ResetBindings(false);
            txtTotalVenta.Text = resumen.Total.ToString("C2");
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmAgregarLibroDetalle>())
            {
                frm.Text = "Agregar libro";
                frm.SetDatos(_librosParaVenta);

                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var detalleDto = frm.GetDetalleVenta();
                if (detalleDto is null) return;

                try
                {
                    _editorVenta.AgregarLibro(detalleDto);
                    MostrarDetalles(_editorVenta.ObtenerResumen());
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Advertencia(ex.Message);
                }
            }
        }

        private void btnQuitarLibro_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not DetalleVentaDto detalle)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            if (!_servicioMensajes.Confirmar($"¿Desea quitar \"{detalle.Libro}\" de la venta?")) return;

            try
            {
                _editorVenta.EliminarLibro(detalle.LibroId);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message);
            }
        }

        private void btnEditarCantidad_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not DetalleVentaDto detalle)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            string stockTexto = detalle.Stock.HasValue
                ? $"(Stock disponible: {detalle.Stock})"
                : "(Libro digital, sin límite de stock)";

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Ingrese la nueva cantidad para \"{detalle.Libro}\":\n{stockTexto}",
                "Modificar cantidad",
                detalle.Cantidad.ToString());


            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int nuevaCantidad))
            {
                _servicioMensajes.Error("Debe ingresar un número entero válido.");
                return;
            }

            if (nuevaCantidad <= 0)
            {
                _servicioMensajes.Error("La cantidad debe ser mayor a cero.");
                return;
            }

            try
            {

                _editorVenta.ModificarCantidad(detalle.LibroId, nuevaCantidad);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {
                _servicioMensajes.Advertencia(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            _ventaDto.ClienteId = ((ClienteComboDto)cboCliente.SelectedItem!).Id;
            _ventaDto.FormaDePagoId = ((FormaDePagoComboDto)cboFormaDePago.SelectedItem!).Id;
            _ventaDto.Detalle = _editorVenta.ObtenerDetalles();
            _ventaDto.Total = _editorVenta.ObtenerResumen().Total;

            DialogResult = DialogResult.OK;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboCliente.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboCliente, "Debe seleccionar un cliente");
                valido = false;
            }

            if (cboFormaDePago.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboFormaDePago, "Debe seleccionar una forma de pago");
                valido = false;
            }

            if (_editorVenta.ObtenerDetalles().Count == 0)
            {
                errorProvider1.SetError(dgvDatos, "Debe agregar al menos un libro");
                valido = false;
            }

            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
