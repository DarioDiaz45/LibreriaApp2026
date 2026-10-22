using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmEditorialAe : Form
    {
        public int UltimoId { get; private set; }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        private EditorialUpdateDto? _editorialUpdateDto;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;
        public frmEditorialAe(IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _editorialServicio = editorialServicio;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_editorialUpdateDto is not null)
            {
                txtNombre.Text = _editorialUpdateDto.Nombre;
                txtPaisOrigen.Text = _editorialUpdateDto.PaisOrigen;
                chkActivo.Checked = _editorialUpdateDto.Activo;
                _esEdicion = true;
            }

        }
        public void SetEditorial(EditorialUpdateDto editorialDto)
        {
            _editorialUpdateDto = editorialDto;
            txtNombre.Text = editorialDto.Nombre;
            txtPaisOrigen.Text = editorialDto.PaisOrigen;
            chkActivo.Checked = _editorialUpdateDto.Activo;
        }
        public EditorialUpdateDto GetEditorial()
        {
            return _editorialUpdateDto!;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var _tipoCreateDto = new EditorialCreateDto();
                        _tipoCreateDto.Nombre = txtNombre.Text;
                        _tipoCreateDto.PaisOrigen = txtPaisOrigen.Text;
                        _tipoCreateDto.Activo = chkActivo.Checked;
                        var resultadoAgregar = _editorialServicio.Agregar(_tipoCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_editorialUpdateDto is null)
                        {
                            _editorialUpdateDto = new EditorialUpdateDto();
                        }
                        _editorialUpdateDto.Nombre = txtNombre.Text;
                        _editorialUpdateDto.PaisOrigen = txtPaisOrigen.Text;
                        _editorialUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _editorialServicio
                            .Editar(_editorialUpdateDto);
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
                        MessageBox.Show("Registro editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            txtNombre.Clear();
            txtPaisOrigen.Clear();
            txtNombre.Focus();
            chkActivo.Checked = true;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");

            }
            return valido;
        }
    }
}
