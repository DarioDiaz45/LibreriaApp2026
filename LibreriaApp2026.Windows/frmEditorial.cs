using LibreriaApp2026.Servicios.Common;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;

namespace LibreriaApp2026.Windows
{
    public partial class frmEditorial : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;

        private string? filtroPais = null;
        public frmEditorial(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEditorial_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            _lista = _servicio.ObtenerTodas();
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = _lista;
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var editorialServicio = scope.ServiceProvider
                    .GetRequiredService<IEditorialServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;


                    var resultadoConsulta = editorialServicio
                        .ObtenerPagina(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroPais);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = editorialServicio
                            .ObtenerPagina(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroPais);

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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroPais = null;
            tsbFiltrar.BackColor = SystemColors.Control;
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            EditorialListDto editorialListDto = (EditorialListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var editorialServicio = scope.ServiceProvider
                        .GetRequiredService<IEditorialServicio>();

                var resultadoConsulta = editorialServicio.ObtenerParaBorrar(editorialListDto.Id);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    return;
                }

                var editorialDeleteDto = resultadoConsulta.Value;

                if (!_servicioMensajes.Confirmar($"¿Desea borrar la editorial {editorialListDto.Nombre}?")) return;

                try
                {

                    var resultadoEliminacion = editorialServicio.Borrar(editorialDeleteDto!);

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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {

                using (var frm = scope.ServiceProvider.GetRequiredService<frmEditorialAe>())
                {
                    frm.Text = "Nueva Editorial";
                    frm.ShowDialog();

                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;


                        bool sePuedeVer = true;

                        if (sePuedeVer)
                        {
                            var editorialServicio = scope.ServiceProvider
                                .GetRequiredService<IEditorialServicio>();

                            var resultado = editorialServicio.ObtenerPaginaRegistro(nuevoId, _estado.RegistrosPorPagina);

                            if (resultado.IsFailure)
                            {
                                ErrorHelper.MostrarErrores(resultado.Errors);
                                return;
                            }

                            _estado.PaginaActual = resultado.Value;
                        }

                        RecargarGrilla();

                        if (sePuedeVer)
                        {
                            var nuevaEditorial = _bindingSource.List
                                .Cast<EditorialListDto>()
                                .FirstOrDefault(ed => ed.Id == nuevoId);

                            if (nuevaEditorial == null) return;

                            _bindingSource.Position = _bindingSource.IndexOf(nuevaEditorial);
                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se pueden mostrar\npor condición de filtro o búsqueda");
                        }
                    }

                }

            }

        }
        private void MostrarEnGrilla(ResultadoPaginacionDto<EditorialListDto> resultado)
        {
            _bindingSource.DataSource = resultado.Items;
        }
    }
}

