using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace LibreriaApp2026.Windows
{
    public partial class frmAutor : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Apellido";
        private bool esAscendente = true;
        private string? textoBuscar = null;
        public frmAutor(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmAutorAe>())
                {
                    frm.Text = "Nuevo Autor";
                    frm.ShowDialog();

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, frm.UltimoId);
                    }
                }
            }
        }

        private void frmAutor_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var autorServicio = scope.ServiceProvider
                    .GetRequiredService<IAutorServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = autorServicio.ObtenerPagina(
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


                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = autorServicio.ObtenerPagina(
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var autorListDto = (AutorListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var autorServicio = scope.ServiceProvider
                    .GetRequiredService<IAutorServicio>();

                var resultado = autorServicio.ObtenerParaEditar(autorListDto.Id);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmAutorAe>())
                {
                    frm.Text = "Editar Autor";
                    frm.SetAutor(resultado.Value!);
                    frm.ShowDialog();

                    if (frm.ConcurrencyConflict)
                    {
                        RecargarGrilla();
                        return;
                    }

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, autorListDto.Id);
                    }
                }
            }
        }

        private void IrAlRegistro(IServiceScope scope, int id)
        {
            var autorServicio = scope.ServiceProvider
               .GetRequiredService<IAutorServicio>();

            var resultado = autorServicio.ObtenerPaginaRegistro(
                id, _estado.RegistrosPorPagina, textoBuscar);

            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            _estado.PaginaActual = resultado.Value;
            RecargarGrilla();

            var autor = _bindingSource.List
                .Cast<AutorListDto>()
                .FirstOrDefault(a => a.Id == id);

            if (autor != null)
            {
                _bindingSource.Position = _bindingSource.IndexOf(autor);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var autorListDto = (AutorListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var autorServicio = scope.ServiceProvider
                    .GetRequiredService<IAutorServicio>();

                var resultadoConsulta = autorServicio.ObtenerParaBorrar(autorListDto.Id);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    RecargarGrilla();
                    return;
                }

                if (!_servicioMensajes.Confirmar(
                    $"¿Desea borrar al autor {autorListDto.Apellido}, {autorListDto.Nombre}?")) return;

                try
                {
                    var resultadoEliminacion = autorServicio.Borrar(resultadoConsulta.Value!);

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
