namespace LibreriaApp2026.Windows.Helpers
{
    public class ErrorHelper
    {
        public static void MostrarErrores(List<string> listaErrores)
        {
            string errores = string.Join("\n", listaErrores);
            MessageBox.Show(errores, "Errores",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
