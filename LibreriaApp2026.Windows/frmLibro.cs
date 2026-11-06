using LibreriaApp2026.Servicios.DTOs.Libro;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmLibro : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Titulo";
        private bool esAscendente = true;

        private int? filtroEditorialId = null;
        private int? filtroAutorId = null;
        private int? filtroTemaId = null;
        private string? textoBuscar = null;
        public frmLibro(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;


            tsbFiltrar.ButtonClick += (s, e) => tsbFiltrar.ShowDropDown();




        }

        private void frmLibro_Load(object sender, EventArgs e)
        {
            CargarMenusFiltro();
            RecargarGrilla();
        }

        private void CargarMenusFiltro()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var sp = scope.ServiceProvider;

                LlenarSubmenu(tsmEditorial,
                    CatalogosHelper.Editoriales(sp.GetRequiredService<IEditorialServicio>()),
                    id => filtroEditorialId = id);

                LlenarSubmenu(tsmAutor,
                    CatalogosHelper.Autores(sp.GetRequiredService<IAutorServicio>()),
                    id => filtroAutorId = id);

                LlenarSubmenu(tsmTema,
                    CatalogosHelper.Temas(sp.GetRequiredService<ITemaServicio>()),
                    id => filtroTemaId = id);
            }
        }

        private void LlenarSubmenu(ToolStripMenuItem menu, List<ItemCombo> items, Action<int?> asignarFiltro)
        {
            menu.DropDownItems.Clear();

            foreach (var item in items)
            {
                var menuItem = new ToolStripMenuItem(item.Texto) { Tag = item.Id };

                menuItem.Click += (s, e) =>
                {

                    foreach (ToolStripMenuItem otro in menu.DropDownItems)
                    {
                        otro.Checked = false;
                    }
                    menuItem.Checked = true;

                    asignarFiltro(item.Id);
                    AplicarFiltros();
                };

                menu.DropDownItems.Add(menuItem);
            }
        }

        private void AplicarFiltros()
        {
            ActualizarColorFiltro();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = libroServicio.ObtenerPagina(
                        paginaSolicitada,
                        _estado.RegistrosPorPagina,
                        campoOrdenar,
                        esAscendente,
                        filtroEditorialId,
                        filtroAutorId,
                        filtroTemaId,
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
                        resultadoConsulta = libroServicio.ObtenerPagina(
                            _estado.PaginaActual,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroEditorialId,
                            filtroAutorId,
                            filtroTemaId,
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

        private void ActualizarColorFiltro()
        {
            bool hayFiltros = filtroEditorialId != null || filtroAutorId != null
                             || filtroTemaId != null || textoBuscar != null;
            tsbFiltrar.BackColor = hayFiltros ? Color.LightGreen : SystemColors.Control;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroEditorialId = null;
            filtroAutorId = null;
            filtroTemaId = null;
            textoBuscar = null;

            DesmarcarSubmenu(tsmEditorial);
            DesmarcarSubmenu(tsmAutor);
            DesmarcarSubmenu(tsmTema);
            AplicarFiltros();
        }

        private void DesmarcarSubmenu(ToolStripMenuItem menu)
        {
            foreach (ToolStripMenuItem item in menu.DropDownItems)
            {
                item.Checked = false;
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmLibroAe>())
                {
                    frm.Text = "Nuevo Libro";
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

            var libroListDto = (LibroListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroServicio>();

                var resultado = libroServicio.ObtenerParaEditar(libroListDto.Id);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmLibroAe>())
                {
                    frm.Text = "Editar Libro";
                    frm.SetLibro(resultado.Value!);
                    frm.ShowDialog();

                    if (frm.ConcurrencyConflict)
                    {
                        RecargarGrilla();
                        return;
                    }

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, libroListDto.Id);
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

            var libroListDto = (LibroListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroServicio>();

                var resultadoConsulta = libroServicio.ObtenerParaBorrar(libroListDto.Id);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    RecargarGrilla();
                    return;
                }

                if (!_servicioMensajes.Confirmar(
                    $"¿Desea borrar el libro {libroListDto.Titulo}?")) return;

                try
                {
                    var resultadoEliminacion = libroServicio.Borrar(resultadoConsulta.Value!);

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
            var libroServicio = scope.ServiceProvider
                .GetRequiredService<ILibroServicio>();

            var resultado = libroServicio.ObtenerPaginaRegistro(
                id, _estado.RegistrosPorPagina,
                filtroEditorialId, filtroAutorId, filtroTemaId, textoBuscar);

            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            _estado.PaginaActual = resultado.Value;
            RecargarGrilla();

            var libro = _bindingSource.List
                .Cast<LibroListDto>()
                .FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                _bindingSource.Position = _bindingSource.IndexOf(libro);
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

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }

            var libroListDto = (LibroListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroServicio>();

                var resultado = libroServicio.ObtenerDetalle(libroListDto.Id);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmDetalleLibro>())
                {
                    frm.Text = "Detalles del libro";
                    frm.MostrarLibro(resultado.Value!);
                    frm.ShowDialog();
                }
            }
        }
    }
}
