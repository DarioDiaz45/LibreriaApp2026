using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.Interfaces;
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
    public partial class frmFormaDePago : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();

        private EstadoNavegacion _estado = new(10);

        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;
        public frmFormaDePago(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;


            tsbFiltrar.ButtonClick += (s, e) => tsbFiltrar.ShowDropDown();

            tstBuscar.TextBox.PlaceholderText = "Nombre + Enter";
            tstBuscar.KeyDown += tstBuscar_KeyDown;
        }

        private void frmFormaDePago_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var formaServicio = scope.ServiceProvider
                    .GetRequiredService<IFormaDePagoServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = formaServicio.ObtenerPagina(
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


                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = formaServicio.ObtenerPagina(
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



        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarFiltroActivo(true);
        }

        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarFiltroActivo(false);
        }
        private void AplicarFiltroActivo(bool activo)
        {
            filtroActivo = filtroActivo == activo ? null : activo;

            activoToolStripMenuItem.Checked = filtroActivo == true;
            noActivoToolStripMenuItem.Checked = filtroActivo == false;

            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            ActualizarColorFiltro();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void ActualizarColorFiltro()
        {
            bool hayFiltros = filtroActivo != null || textoBuscar != null;
            tsbFiltrar.BackColor = hayFiltros ? Color.LightGreen : SystemColors.Control;
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

            activoToolStripMenuItem.Checked = false;
            noActivoToolStripMenuItem.Checked = false;
            tstBuscar.Clear();

            ActualizarColorFiltro();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var frm = scope.ServiceProvider.GetRequiredService<frmFormaDePagoAe>())
                {
                    frm.Text = "Nueva Forma de Pago";
                    frm.ShowDialog();

                    if (frm.DataChanged)
                    {

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

            var formaListDto = (FormaDePagoListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var formaServicio = scope.ServiceProvider
                    .GetRequiredService<IFormaDePagoServicio>();

                var resultado = formaServicio.ObtenerParaEditar(formaListDto.FormaDePagoId);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    RecargarGrilla();
                    return;
                }

                using (var frm = scope.ServiceProvider.GetRequiredService<frmFormaDePagoAe>())
                {
                    frm.Text = "Editar Forma de Pago";
                    frm.SetFormaDePago(resultado.Value!);
                    frm.ShowDialog();

                    if (frm.ConcurrencyConflict)
                    {
                        RecargarGrilla();
                        return;
                    }

                    if (frm.DataChanged)
                    {
                        IrAlRegistro(scope, formaListDto.FormaDePagoId);
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

            var formaListDto = (FormaDePagoListDto)_bindingSource.Current;

            using (var scope = _serviceProvider.CreateScope())
            {
                var formaServicio = scope.ServiceProvider
                    .GetRequiredService<IFormaDePagoServicio>();

                var resultadoConsulta = formaServicio.ObtenerParaBorrar(formaListDto.FormaDePagoId);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    RecargarGrilla();
                    return;
                }

                if (!_servicioMensajes.Confirmar(
                    $"¿Desea borrar la forma de pago {formaListDto.Nombre}?")) return;

                try
                {
                    var resultadoEliminacion = formaServicio.Borrar(resultadoConsulta.Value!);

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
            var formaServicio = scope.ServiceProvider
                .GetRequiredService<IFormaDePagoServicio>();

            var resultado = formaServicio.ObtenerPaginaRegistro(
                id, _estado.RegistrosPorPagina,
                filtroActivo: filtroActivo, textoBuscar: textoBuscar);

            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }

            _estado.PaginaActual = resultado.Value;
            RecargarGrilla();

            var forma = _bindingSource.List
                .Cast<FormaDePagoListDto>()
                .FirstOrDefault(f => f.FormaDePagoId == id);

            if (forma != null)
            {
                _bindingSource.Position = _bindingSource.IndexOf(forma);
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
