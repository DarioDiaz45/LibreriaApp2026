using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmVenta : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);
        private string? textoBuscar = null;
        public frmVenta(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;

            tstBuscar.TextBox.PlaceholderText = "Cliente + Enter";
            tstBuscar.KeyDown += tstBuscar_KeyDown;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ventaServicio = scope.ServiceProvider
                    .GetRequiredService<IVentaServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = ventaServicio.ObtenerPaginado(
                        paginaSolicitada, _estado.RegistrosPorPagina, textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;
                    _estado.Actualizar(resultado.CantidadRegistros);


                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = ventaServicio.ObtenerPaginado(
                            _estado.PaginaActual, _estado.RegistrosPorPagina, textoBuscar);

                        if (resultadoConsulta.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;
                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblRegistros.Text = _estado.TextoRegistros();
                    lblPaginas.Text = _estado.TextoPaginas();

                    btnPrimero.Enabled = _estado.PuedeIrAnterior();
                    btnAnterior.Enabled = _estado.PuedeIrAnterior();
                    btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
                    btnUltimo.Enabled = _estado.PuedeIrSiguiente();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }
        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvDatos.Rows[e.RowIndex].DataBoundItem is VentaListDto venta)
            {
                var fila = dgvDatos.Rows[e.RowIndex];
                fila.DefaultCellStyle.ForeColor = venta.EstadoVenta switch
                {
                    EstadoVenta.Anulada => Color.Gray,
                    EstadoVenta.Facturada => Color.DarkGreen,
                    _ => dgvDatos.DefaultCellStyle.ForeColor
                };
            }
        }

        private void tstBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            textoBuscar = string.IsNullOrWhiteSpace(tstBuscar.Text) ? null : tstBuscar.Text.Trim();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            textoBuscar = null;
            tstBuscar.Clear();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmVentasAe>())
                {
                    frm.Text = "Nueva Venta";

                    if (frm.ShowDialog(this) != DialogResult.OK) return;

                    var ventaDto = frm.GetVenta();

                    try
                    {
                        var ventaServicio = scope.ServiceProvider
                            .GetRequiredService<IVentaServicio>();

                        var resultado = ventaServicio.Agregar(ventaDto);

                        if (resultado.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultado.Errors);
                            return;
                        }

                        _servicioMensajes.Informacion(
                            $"Venta N° {resultado.Value} registrada correctamente.",
                            "Nueva Venta");
                    }
                    catch (Exception ex)
                    {
                        _servicioMensajes.Error($"No se pudo registrar la venta: {ex.Message}");
                        return;
                    }
                }
            }


            textoBuscar = null;
            tstBuscar.Clear();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not VentaListDto ventaListDto)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var ventaServicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();

                    var resultado = ventaServicio.ObtenerPorId(ventaListDto.VentaId);
                    if (resultado.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        return;
                    }

                    using (var frm = scope.ServiceProvider.GetRequiredService<frmDetalleVenta>())
                    {
                        frm.Text = "Detalle de la venta";
                        frm.SetVenta(resultado.Value!);
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void tsbFacturar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not VentaListDto venta)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            if (!_servicioMensajes.Confirmar(
                $"¿Confirma la facturación de la venta N° {venta.VentaId}?",
                "Confirmar facturación")) return;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var ventaServicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();

                    var resultado = ventaServicio.Facturar(venta.VentaId);

                    if (resultado.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        RecargarGrilla();
                        return;
                    }

                    if (resultado.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        return;
                    }

                    _servicioMensajes.Informacion(
                        $"La venta N° {venta.VentaId} fue facturada correctamente.",
                        "Facturación");
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                    return;
                }
            }

            RecargarGrilla();
        }

        private void tsbAnular_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not VentaListDto venta)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            if (!_servicioMensajes.Confirmar(
                $"¿Confirma la anulación de la venta N° {venta.VentaId}?\n" +
                "Se devolverá el stock de los libros físicos.",
                "Confirmar anulación")) return;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var ventaServicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();

                    var resultado = ventaServicio.AnularVenta(venta.VentaId);

                    if (resultado.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        RecargarGrilla();
                        return;
                    }

                    if (resultado.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        return;
                    }

                    _servicioMensajes.Informacion(
                        $"La venta N° {venta.VentaId} fue anulada correctamente.",
                        "Anulación");
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                    return;
                }
            }

            RecargarGrilla();
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estado.PrimeraPagina();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estado.PaginaAnterior();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estado.PaginaSiguiente();
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estado.UltimaPagina();
            RecargarGrilla();
        }
    }
}
