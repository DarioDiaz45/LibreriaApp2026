using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Windows
{
    public partial class frmDetalleVenta : Form
    {
        private VentaDetailDto _ventaDto = null!;
        private BindingSource _bindingSource = new BindingSource();

        public frmDetalleVenta()
        {
            InitializeComponent();
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
        }
        internal void SetVenta(VentaDetailDto ventaDetailDto)
        {
            _ventaDto = ventaDetailDto;
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            txtVentaId.Text = _ventaDto.VentaId.ToString();
            txtFecha.Text = _ventaDto.FechaVenta.ToShortDateString();
            txtCliente.Text = _ventaDto.Cliente;
            txtFormaDePago.Text = _ventaDto.FormaDePago;
            txtEstado.Text = _ventaDto.EstadoVenta.ToString();
            txtTotal.Text = _ventaDto.Total.ToString("C2");

            _bindingSource.DataSource = _ventaDto.DetalleVentas;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
