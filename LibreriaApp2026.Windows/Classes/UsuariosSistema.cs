using LibreriaApp2026.Entidades;

namespace LibreriaApp2026.Windows.Classes
{
    public static class UsuariosSistema
    {
        public static List<Usuario> Usuarios { get; } =
                [
                    new Usuario
            {
                UserName = "admin",
                Password = "123456" 
            },
            new Usuario
            {
                UserName = "empleado",
                Password = "123456" 
            }
                ];
    }
}
