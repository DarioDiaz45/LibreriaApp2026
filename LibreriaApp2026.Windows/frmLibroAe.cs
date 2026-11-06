using LibreriaApp2026.Servicios.DTOs.Libro;
using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using System.Data;

namespace LibreriaApp2026.Windows
{
    public partial class frmLibroAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        private LibroUpdateDto? _libroUpdateDto;
        private bool _esEdicion = false;

        private readonly ILibroServicio _libroServicio;
        private readonly IEditorialServicio _editorialServicio;
        private readonly IAutorServicio _autorServicio;
        private readonly ITemaServicio _temaServicio;
        public frmLibroAe(ILibroServicio libroServicio,
            IEditorialServicio editorialServicio,
            IAutorServicio autorServicio,
            ITemaServicio temaServicio)
        {
            InitializeComponent();
            _libroServicio = libroServicio;
            _editorialServicio = editorialServicio;
            _autorServicio = autorServicio;
            _temaServicio = temaServicio;

            nudAnio.Minimum = 1000;
            nudAnio.Maximum = DateTime.Today.Year;
            nudAnio.Value = DateTime.Today.Year;

            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Maximum = 9999999999M;

            nudStock.Maximum = 1000000;

            nudTamano.Minimum = 1;
            nudTamano.Maximum = 1000000;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CatalogosHelper.CargarCombo(cboEditorial,
                CatalogosHelper.Editoriales(_editorialServicio, "(Seleccione)"));
            CatalogosHelper.CargarCombo(cboAutor,
                CatalogosHelper.Autores(_autorServicio, "(Seleccione)"));
            CatalogosHelper.CargarCombo(cboTema,
                CatalogosHelper.Temas(_temaServicio, "(Seleccione)"));

            if (_libroUpdateDto is not null)
            {
                MostrarLibro(_libroUpdateDto);
                _esEdicion = true;
            }

            ActualizarPanelTipo();
        }

        private void ActualizarPanelTipo()
        {
            grpLibroFisico.Enabled = rdoFisico.Checked;
            grpLibroDigital.Enabled = rdoDigital.Checked;
        }

        private void MostrarLibro(LibroUpdateDto dto)
        {
            rdoFisico.Checked = dto.Tipo == TipoLibro.Fisico;
            rdoDigital.Checked = dto.Tipo == TipoLibro.Digital;
            rdoFisico.Enabled = false;
            rdoDigital.Enabled = false;

            txtTitulo.Text = dto.Titulo;
            txtDescripcion.Text = dto.Descripcion;
            nudAnio.Value = Math.Clamp(dto.AnioPublicacion, (int)nudAnio.Minimum, (int)nudAnio.Maximum);
            nudPrecio.Value = dto.Precio;
            chkActivo.Checked = dto.Activo;
            cboEditorial.SelectedValue = dto.EditorialId;

            CargarSeleccionados(cboAutor, lstAutores, dto.AutoresIds);
            CargarSeleccionados(cboTema, lstTemas, dto.TemasIds);

            if (dto.Tipo == TipoLibro.Fisico)
            {
                txtISBN.Text = dto.ISBN;
                nudStock.Value = Math.Clamp(dto.Stock, 0, (int)nudStock.Maximum);
            }
            else
            {
                txtIdentificador.Text = dto.Identificador;
                txtFormato.Text = dto.Formato;
                nudTamano.Value = Math.Clamp(dto.TamanoArchivo, (long)nudTamano.Minimum, (long)nudTamano.Maximum);
                txtURL.Text = dto.UrlDescarga;
            }
        }

        private void CargarSeleccionados(ComboBox cbo, ListBox lst, List<int> ids)
        {
            lst.Items.Clear();
            if (cbo.DataSource is List<ItemCombo> items)
            {
                foreach (var item in items.Where(i => i.Id > 0 && ids.Contains(i.Id)))
                {
                    lst.Items.Add(item);
                }
            }
        }

        private void btnAgregarAutor_Click(object sender, EventArgs e) => AgregarSeleccion(cboAutor, lstAutores);
        private void btnQuitarAutor_Click(object sender, EventArgs e) => QuitarSeleccion(lstAutores);
        private void btnAgregarTema_Click(object sender, EventArgs e) => AgregarSeleccion(cboTema, lstTemas);
        private void btnQuitarTema_Click(object sender, EventArgs e) => QuitarSeleccion(lstTemas);


        private static void QuitarSeleccion(ListBox lst)
        {
            if (lst.SelectedItem != null)
            {
                lst.Items.Remove(lst.SelectedItem);
            }
        }

        private static void AgregarSeleccion(ComboBox cbo, ListBox lst)
        {
            if (cbo.SelectedItem is ItemCombo item && item.Id > 0
                && !lst.Items.Cast<ItemCombo>().Any(i => i.Id == item.Id))
            {
                lst.Items.Add(item);
            }
        }
        private static List<int> ObtenerIds(ListBox lst)
        {
            return lst.Items.Cast<ItemCombo>().Select(i => i.Id).ToList();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            if (!ValidarDatos()) return;

            try
            {
                if (!_esEdicion)
                {
                    var createDto = new LibroCreateDto();
                    CompletarDto(createDto);

                    var resultadoAgregar = _libroServicio.Agregar(createDto);
                    if (resultadoAgregar.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                        return;
                    }

                    DataChanged = true;
                    UltimoId = resultadoAgregar.Value;

                    var respuesta = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                        "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (respuesta == DialogResult.No)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    InicializarControles();
                }
                else
                {
                    CompletarDto(_libroUpdateDto!);

                    var resultadoEditar = _libroServicio.Editar(_libroUpdateDto!);

                    if (resultadoEditar.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                        ConcurrencyConflict = true;
                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }

                    if (resultadoEditar.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                        return;
                    }

                    DataChanged = true;
                    MessageBox.Show("Registro editado satisfactoriamente", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTitulo, "El título es requerido");
            }

            if (!(cboEditorial.SelectedValue is int editorialId && editorialId > 0))
            {
                valido = false;
                errorProvider1.SetError(cboEditorial, "Debe seleccionar una editorial");
            }

            if (lstAutores.Items.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lstAutores, "Agregue al menos un autor");
            }

            if (lstTemas.Items.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lstTemas, "Agregue al menos un tema");
            }

            if (rdoFisico.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    valido = false;
                    errorProvider1.SetError(txtISBN, "El ISBN es requerido");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtIdentificador.Text))
                {
                    valido = false;
                    errorProvider1.SetError(txtIdentificador, "El identificador es requerido");
                }
                if (string.IsNullOrWhiteSpace(txtFormato.Text))
                {
                    valido = false;
                    errorProvider1.SetError(txtFormato, "El formato es requerido");
                }
                if (string.IsNullOrWhiteSpace(txtURL.Text))
                {
                    valido = false;
                    errorProvider1.SetError(txtURL, "La URL de descarga es requerida");
                }
            }

            return valido;
        }

        private void CompletarDto(LibroCreateDto dto)
        {
            dto.Tipo = rdoFisico.Checked ? TipoLibro.Fisico : TipoLibro.Digital;
            dto.Titulo = txtTitulo.Text.Trim();
            dto.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                ? null
                : txtDescripcion.Text.Trim();
            dto.AnioPublicacion = (int)nudAnio.Value;
            dto.Precio = nudPrecio.Value;
            dto.Activo = chkActivo.Checked;
            dto.EditorialId = cboEditorial.SelectedValue is int id ? id : 0;
            dto.AutoresIds = ObtenerIds(lstAutores);
            dto.TemasIds = ObtenerIds(lstTemas);

            if (dto.Tipo == TipoLibro.Fisico)
            {
                dto.ISBN = txtISBN.Text.Trim();
                dto.Stock = (int)nudStock.Value;
                dto.Identificador = null;
                dto.Formato = null;
                dto.TamanoArchivo = 0;
                dto.UrlDescarga = null;
            }
            else
            {
                dto.ISBN = null;
                dto.Stock = 0;
                dto.Identificador = txtIdentificador.Text.Trim();
                dto.Formato = txtFormato.Text.Trim();
                dto.TamanoArchivo = (long)nudTamano.Value;
                dto.UrlDescarga = txtURL.Text.Trim();
            }
        }

        private void InicializarControles()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            nudAnio.Value = DateTime.Today.Year;
            nudPrecio.Value = 0;
            chkActivo.Checked = true;
            if (cboEditorial.Items.Count > 0) cboEditorial.SelectedIndex = 0;

            lstAutores.Items.Clear();
            lstTemas.Items.Clear();
            if (cboAutor.Items.Count > 0) cboAutor.SelectedIndex = 0;
            if (cboTema.Items.Count > 0) cboTema.SelectedIndex = 0;

            txtISBN.Clear();
            nudStock.Value = 0;
            txtIdentificador.Clear();
            txtFormato.Clear();
            nudTamano.Value = nudTamano.Minimum;
            txtURL.Clear();

            txtTitulo.Focus();
        }

        public void SetLibro(LibroUpdateDto libroDto)
        {
            _libroUpdateDto = libroDto;
        }

        private void rdoTipo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarPanelTipo();
        }

        private void btnAgregarAutor_Click_1(object sender, EventArgs e)
        {
            if (cboAutor.SelectedItem is not ItemCombo autor)
            {
                MessageBox.Show("Seleccioná un autor.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstAutores.Items.Cast<ItemCombo>().Any(a => a.Id == autor.Id))
            {
                MessageBox.Show("Ese autor ya está agregado.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstAutores.Items.Add(autor);
            cboAutor.SelectedIndex = -1;
        }

        private void btnQuitarAutor_Click_1(object sender, EventArgs e)
        {
            if (lstAutores.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un autor de la lista para quitarlo.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstAutores.Items.Remove(lstAutores.SelectedItem);
        }

        private void btnAgregarTema_Click_1(object sender, EventArgs e)
        {
            if (cboTema.SelectedItem is not ItemCombo tema)
            {
                MessageBox.Show("Seleccioná un tema.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstTemas.Items.Cast<ItemCombo>().Any(t => t.Id == tema.Id))
            {
                MessageBox.Show("Ese tema ya está agregado.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTemas.Items.Add(tema);
            cboTema.SelectedIndex = -1;
        }

        private void btnQuitarTema_Click_1(object sender, EventArgs e)
        {
            if (lstTemas.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un tema de la lista para quitarlo.", "Atención",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTemas.Items.Remove(lstTemas.SelectedItem);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nudAnio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
