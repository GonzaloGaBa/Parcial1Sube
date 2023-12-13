using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1Sube.Modelo;
using Parcial1Sube.Presentador;
using Parcial1Sube._Repositorios;
using Parcial1Sube.Vista;
using System.Configuration;

namespace Parcial1Sube
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConexionString = ConfigurationManager.ConnectionStrings["SqlConexion"].ConnectionString;
            IMenuPrincipal vista = new VistaMenu();
            
            new PresentadorPrincipal(vista);

            Application.Run((Form)vista);

        }
    }
}
