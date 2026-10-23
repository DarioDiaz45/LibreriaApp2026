using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmTema : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private string? textoBuscar = null;
        public frmTema(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
        }

        private void frmTema_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var temaServicio = scope.ServiceProvider
                    .GetRequiredService<ITemaServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = temaServicio.ObtenerPagina(
                        paginaSolicitada,
                        _estado.RegistrosPorPagina,
                        campoOrdenar,
                        esAscendente,
                        textoBuscar);

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
                        resultadoConsulta = temaServicio.ObtenerPagina(
                            _estado.PaginaActual,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            textoBuscar);

                        if (resultadoConsulta.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;
                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblCantidad.Text = _estado.TextoRegistros();
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            textoBuscar = null;
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmTemaAe>())
                {
                    frm.Text = "Nuevo Tema";
                    frm.ShowDialog();

                    if (frm.DataChanged)
                    {
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

            var temaListDto = (TemaListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var temaServicio = scope.ServiceProvider
                    .GetRequiredService<ITemaServicio>();

                var resultado = temaServicio.ObtenerParaEditar(temaListDto.Id);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmTemaAe>())
                {
                    frm.Text = "Editar Tema";
                    frm.SetTema(resultado.Value!);
                    frm.ShowDialog();

                    if (frm.ConcurrencyConflict)
                    {
                        RecargarGrilla();
                        return;
                    }

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, temaListDto.Id);
                    }
                }
            }
        }

        private void IrAlRegistro(IServiceScope scope, int id)
        {
            var temaServicio = scope.ServiceProvider
                 .GetRequiredService<ITemaServicio>();

            var resultado = temaServicio.ObtenerPaginaRegistro(
                id, _estado.RegistrosPorPagina, textoBuscar);

            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            _estado.PaginaActual = resultado.Value;
            RecargarGrilla();

            var tema = _bindingSource.List
                .Cast<TemaListDto>()
                .FirstOrDefault(t => t.Id == id);

            if (tema != null)
            {
                _bindingSource.Position = _bindingSource.IndexOf(tema);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var temaListDto = (TemaListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var temaServicio = scope.ServiceProvider
                    .GetRequiredService<ITemaServicio>();

                var resultadoConsulta = temaServicio.ObtenerParaBorrar(temaListDto.Id);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    RecargarGrilla();
                    return;
                }

                if (!_servicioMensajes.Confirmar(
                    $"¿Desea borrar el tema {temaListDto.Nombre}?")) return;

                try
                {
                    var resultadoEliminacion = temaServicio.Borrar(resultadoConsulta.Value!);

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
