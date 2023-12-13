using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial1Sube.Modelo;
using Parcial1Sube.Vista;
using Parcial1Sube._Repositorios;
using System.Windows.Forms;
using System.Configuration;

namespace Parcial1Sube.Presentador
{
    public class PresentadorPrincipal
    {
        private IMenuPrincipal menuVista;
        private readonly string sqlConexionString;

        public PresentadorPrincipal(IMenuPrincipal menuVista)
        {
            this.menuVista = menuVista;
            this.sqlConexionString = ConfigurationManager.ConnectionStrings["SqlConexion"].ConnectionString; ;
            this.menuVista.MostrarVistaDeUsuarios += MostrarVistaDeUsuarios;
        }

        private void MostrarVistaDeUsuarios(object sender, EventArgs e)
        {
            IUsuarioVista vista = VistaUsuario.GetInstancia((VistaMenu)menuVista);
            IUsuarioRepositorio repositorio = new RepositorioUsuario(sqlConexionString);
            new UsuarioPresentador(vista, repositorio);
        }
    }
}
