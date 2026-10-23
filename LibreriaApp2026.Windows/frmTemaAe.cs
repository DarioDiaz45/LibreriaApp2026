using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibreriaApp2026.Windows
{
    public partial class frmTemaAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        private TemaUpdateDto? _temaUpdateDto;
        private readonly ITemaServicio _temaServicio;
        private bool _esEdicion = false;

        public frmTemaAe(ITemaServicio temaServicio)
        {
            InitializeComponent();
            _temaServicio = temaServicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_temaUpdateDto is not null)
            {
                txtNombre.Text = _temaUpdateDto.Nombre;
                txtDescripcion.Text = _temaUpdateDto.Descripcion;
                _esEdicion = true;
            }
        }

        public void SetTema(TemaUpdateDto temaDto)
        {
            _temaUpdateDto = temaDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string? DescripcionONull()
        {
            return string.IsNullOrWhiteSpace(txtDescripcion.Text)
                ? null
                : txtDescripcion.Text.Trim();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            try
            {
                if (!_esEdicion)
                {
                    var createDto = new TemaCreateDto
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Descripcion = DescripcionONull()
                    };

                    var resultadoAgregar = _temaServicio.Agregar(createDto);
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
                    _temaUpdateDto!.Nombre = txtNombre.Text.Trim();
                    _temaUpdateDto.Descripcion = DescripcionONull();

                    var resultadoEditar = _temaServicio.Editar(_temaUpdateDto);

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
            txtDescripcion.Clear();
            txtNombre.Focus();
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
            return valido;
        }
    }
}
