using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmAutorAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        private AutorUpdateDto? _autorUpdateDto;
        private readonly IAutorServicio _autorServicio;
        private bool _esEdicion = false;

        public frmAutorAe(IAutorServicio autorServicio)
        {
            InitializeComponent();
            _autorServicio = autorServicio;
            dtpFechaNacimiento.MaxDate = DateTime.Today;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_autorUpdateDto is not null)
            {
                txtNombre.Text = _autorUpdateDto.Nombre;
                txtApellido.Text = _autorUpdateDto.Apellido;
                txtNacionalidad.Text = _autorUpdateDto.Nacionalidad;
                dtpFechaNacimiento.Value = _autorUpdateDto.FechaNacimiento;
                _esEdicion = true;
            }
        }
        public void SetAutor(AutorUpdateDto autorDto)
        {
            _autorUpdateDto = autorDto;
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
                    var createDto = new AutorCreateDto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Nacionalidad = txtNacionalidad.Text.Trim(),
                        FechaNacimiento = dtpFechaNacimiento.Value.Date
                    };

                    var resultadoAgregar = _autorServicio.Agregar(createDto);
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
                    _autorUpdateDto!.Nombre = txtNombre.Text.Trim();
                    _autorUpdateDto.Apellido = txtApellido.Text.Trim();
                    _autorUpdateDto.Nacionalidad = txtNacionalidad.Text.Trim();
                    _autorUpdateDto.FechaNacimiento = dtpFechaNacimiento.Value.Date;

                    var resultadoEditar = _autorServicio.Editar(_autorUpdateDto);

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

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El apellido es requerido");
            }
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNacionalidad, "La nacionalidad es requerida");
            }
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha no puede ser futura");
            }
            return valido;
        }


        private void InicializarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNacionalidad.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtNombre.Focus();
        }
    }
}
