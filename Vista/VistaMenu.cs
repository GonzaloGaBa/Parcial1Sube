using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Sube.Vista
{
    public partial class VistaMenu : Form, IMenuPrincipal
    {
        public VistaMenu()
        {
            InitializeComponent();
            btnUsuarios.Click += delegate { MostrarVistaDeUsuarios?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler MostrarVistaDeUsuarios;
        public event EventHandler MostrarVistaDePropietario;
        public event EventHandler MostrarVistaDeAdministrador;
    }
}
