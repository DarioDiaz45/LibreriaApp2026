using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmCliente : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Apellido";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;

        public frmCliente(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
            tsbFiltrar.ButtonClick += (s, e) => tsbFiltrar.ShowDropDown();

            tstBuscar.TextBox.PlaceholderText = "Nombre o apellido + Enter";
            tstBuscar.KeyDown += tstBuscar_KeyDown;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                    .GetRequiredService<IClienteServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = clienteServicio.ObtenerPagina(
                        paginaSolicitada,
                        _estado.RegistrosPorPagina,
                        campoOrdenar,
                        esAscendente,
                        filtroActivo: filtroActivo,
                        textoBuscar: textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;
                    _estado.Actualizar(resultado.CantidadRegistros);

                    // Si la página pedida ya no existe (por ej. se borró el último registro de la última página)
                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = clienteServicio.ObtenerPagina(
                            _estado.PaginaActual,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo: filtroActivo,
                            textoBuscar: textoBuscar);

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
        private void tstBuscar_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.SuppressKeyPress = true;
            textoBuscar = string.IsNullOrWhiteSpace(tstBuscar.Text) ? null : tstBuscar.Text.Trim();
            AplicarFiltros();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            AplicarFiltros();
        }

        private void LimpiarFiltros()
        {
            filtroActivo = null;
            textoBuscar = null;

            tsmActivos.Checked = false;
            tsmNoActivos.Checked = false;
            tstBuscar.Clear();

            ActualizarColorFiltro();
        }

        private void ActualizarColorFiltro()
        {
            bool hayFiltros = filtroActivo != null || textoBuscar != null;
            tsbFiltrar.BackColor = hayFiltros ? Color.LightGreen : SystemColors.Control;
        }

        private void tsmActivos_Click(object sender, EventArgs e)
        {
            AplicarFiltroActivo(true);
        }

        private void AplicarFiltroActivo(bool activo)
        {
            filtroActivo = filtroActivo == activo ? null : activo;

            tsmActivos.Checked = filtroActivo == true;
            tsmNoActivos.Checked = filtroActivo == false;

            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            ActualizarColorFiltro();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }


        private void tsmNoActivos_Click(object sender, EventArgs e)
        {
            AplicarFiltroActivo(false);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmClienteAe>())
                {
                    frm.Text = "Nuevo Cliente";
                    frm.ShowDialog();

                    if (frm.DataChanged)
                    {
                        // Se quitan los filtros para que el cliente nuevo siempre se vea
                        LimpiarFiltros();
                        IrAlRegistro(scope, frm.UltimoId);
                    }
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var clienteListDto = (ClienteListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                    .GetRequiredService<IClienteServicio>();

                var resultado = clienteServicio.ObtenerParaEditar(clienteListDto.ClienteId);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmClienteAe>())
                {
                    frm.Text = "Editar Cliente";
                    frm.SetCliente(resultado.Value!);
                    frm.ShowDialog();

                    if (frm.ConcurrencyConflict)
                    {
                        RecargarGrilla();
                        return;
                    }

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, clienteListDto.ClienteId);
                    }
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var clienteListDto = (ClienteListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                    .GetRequiredService<IClienteServicio>();

                var resultadoConsulta = clienteServicio.ObtenerParaBorrar(clienteListDto.ClienteId);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    RecargarGrilla();
                    return;
                }

                if (!_servicioMensajes.Confirmar(
                    $"¿Desea borrar al cliente {clienteListDto.Apellido}, {clienteListDto.Nombre}?")) return;

                try
                {
                    var resultadoEliminacion = clienteServicio.Borrar(resultadoConsulta.Value!);

                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        RecargarGrilla();
                        return;
                    }

                    if (resultadoEliminacion.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        return;
                    }

                    _servicioMensajes.Informacion("Registro eliminado satisfactoriamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }
        private void IrAlRegistro(IServiceScope scope, int id)
        {
            var clienteServicio = scope.ServiceProvider
                .GetRequiredService<IClienteServicio>();

            var resultado = clienteServicio.ObtenerPaginaRegistro(
                id, _estado.RegistrosPorPagina,
                filtroActivo: filtroActivo, textoBuscar: textoBuscar);

            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            _estado.PaginaActual = resultado.Value;
            RecargarGrilla();

            var cliente = _bindingSource.List
                .Cast<ClienteListDto>()
                .FirstOrDefault(c => c.ClienteId == id);

            if (cliente != null)
            {
                _bindingSource.Position = _bindingSource.IndexOf(cliente);
            }
        }
        #region Paginación

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

        #endregion
    }
}
