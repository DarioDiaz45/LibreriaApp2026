using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmClienteAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        private ClienteUpdateDto? _clienteUpdateDto;
        private readonly IClienteServicio _clienteServicio;
        private bool _esEdicion = false;
        public frmClienteAe(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_clienteUpdateDto is not null)
            {
                txtNombre.Text = _clienteUpdateDto.Nombre;
                txtApellido.Text = _clienteUpdateDto.Apellido;
                txtTelefono.Text = _clienteUpdateDto.Telefono;
                txtEmail.Text = _clienteUpdateDto.Email;
                chkActivo.Checked = _clienteUpdateDto.Activo;
                _esEdicion = true;
            }
        }

        public void SetCliente(ClienteUpdateDto clienteDto)
        {
            _clienteUpdateDto = clienteDto;
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
                    var createDto = new ClienteCreateDto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        Activo = chkActivo.Checked
                    };

                    var resultadoAgregar = _clienteServicio.Agregar(createDto);
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
                    _clienteUpdateDto!.Nombre = txtNombre.Text.Trim();
                    _clienteUpdateDto.Apellido = txtApellido.Text.Trim();
                    _clienteUpdateDto.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();
                    _clienteUpdateDto.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                    _clienteUpdateDto.Activo = chkActivo.Checked;

                    var resultadoEditar = _clienteServicio.Editar(_clienteUpdateDto);

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
            return valido;
        }

        private void InicializarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            chkActivo.Checked = true;
            txtNombre.Focus();
        }
    }
}
