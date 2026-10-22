using LibreriaApp2026.Windows.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btnLogaut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"{Sesion.UsuarioActual!.UserName}";
        }

        private void btnEditorial_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmEditorial>())
            {
                frm.Text = "Lista de Editoriales";
                frm.ShowDialog();
            }
        }
    }
}
