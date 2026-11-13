using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmFormaDePagoAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        private FormaDePagoUpdateDto? _formaUpdateDto;
        private readonly IFormaDePagoServicio _formaServicio;
        private bool _esEdicion = false;
        public frmFormaDePagoAe(IFormaDePagoServicio formaServicio)
        {
            InitializeComponent();
            _formaServicio = formaServicio;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_formaUpdateDto is not null)
            {
                txtNombre.Text = _formaUpdateDto.Nombre;
                chkActivo.Checked = _formaUpdateDto.Activo;
                _esEdicion = true;
            }
        }

        public void SetFormaDePago(FormaDePagoUpdateDto formaDto)
        {
            _formaUpdateDto = formaDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                if (!_esEdicion)
                {
                    var createDto = new FormaDePagoCreateDto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Activo = chkActivo.Checked
                    };

                    var resultadoAgregar = _formaServicio.Agregar(createDto);
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
                    _formaUpdateDto!.Nombre = txtNombre.Text.Trim();
                    _formaUpdateDto.Activo = chkActivo.Checked;

                    var resultadoEditar = _formaServicio.Editar(_formaUpdateDto);

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

        private void InicializarControles()
        {
            txtNombre.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre es requerido");
                return false;
            }
            return true;
        }
    }
}
