

using LibreriaApp2026.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

           
            services.AddApplicationServices();

            
            var formularios = typeof(Program).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Form)) && !t.IsAbstract).ToList();

            foreach (var frm in formularios)
            {
                services.AddTransient(frm);
            }

            var provider = services.BuildServiceProvider();

           
            ApplicationConfiguration.Initialize();

           
            Application.Run(provider.GetRequiredService<frmEditorial>());
        }
    }
}