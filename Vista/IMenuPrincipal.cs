using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Sube.Vista
{
    public interface IMenuPrincipal
    {
        event EventHandler MostrarVistaDeUsuarios;
        event EventHandler MostrarVistaDePropietario;
        event EventHandler MostrarVistaDeAdministrador;
    }
}
