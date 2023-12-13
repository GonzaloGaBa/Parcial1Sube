using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1Sube.Vista;

namespace Parcial1Sube.Vista
{
    public partial class VistaUsuario : Form, IUsuarioVista
    {
        #region Atributos
        private string mensaje;
        private bool estadoSatisfactorio;
        private bool estadoEditar;
        #endregion

        #region Constructor
        public VistaUsuario()
        {
            InitializeComponent();
            AsociarYGenerarEventosDeVista();
            tabControl1.TabPages.Remove(tbpDetallesDelUsuario);
            btnCerrar.Click += delegate { this.Close(); };

        }

        private void AsociarYGenerarEventosDeVista()
        {
            btnBuscar.Click += delegate { EventoBuscar?.Invoke(this, EventArgs.Empty); };
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    EventoBuscar?.Invoke(this, EventArgs.Empty);
            };
            //Agregar Usuario
            btnAgregar.Click += delegate 
            { 
                EventoAgregarUsuario?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tbpListaDeUsuarios);
                tabControl1.TabPages.Add(tbpDetallesDelUsuario);
                tbpDetallesDelUsuario.Text = "Agregar Nuevo Usuario";
            };
            //Editar Usuario
            btnEditar.Click += delegate 
            { 
                EventoEditar?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tbpListaDeUsuarios);
                tabControl1.TabPages.Add(tbpDetallesDelUsuario);
                tbpDetallesDelUsuario.Text = "Editar Usuario";
            };          
            //Guardar Usuario
            btnGuardar.Click += delegate 
            {
                EventoGuardar?.Invoke(this, EventArgs.Empty);
                if(EstadoSatisfactorio)
                {
                    tabControl1.TabPages.Remove(tbpDetallesDelUsuario);
                    tabControl1.TabPages.Add(tbpListaDeUsuarios);
                }
                MessageBox.Show(Mensaje);
            };
            //Cancelar Usuario
            btnCancelar.Click += delegate
            { 
                EventoCancelar?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tbpDetallesDelUsuario);
                tabControl1.TabPages.Add(tbpListaDeUsuarios);
            };
            //Borrar Usuario
            btnBorrar.Click += delegate
            {               
                var resultado = MessageBox.Show("¿ESTÁS SEGURO QUE QUIERES BORRAR AL USUARIO?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    // Realiza la acción de borrado solo si se selecciona "Yes"
                    EventoBorrar?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show("Usuario borrado exitosamente.");

                }
                else
                {
                    // No hagas nada o realiza alguna acción adicional si se selecciona "No"
                    MessageBox.Show("Operación de borrado cancelada.");
                }
            };

        }
        #endregion

        #region Propiedades
        public string UsuarioID
        {
            get { return txtUsuarioId.Text; }
            set { txtUsuarioId.Text = value; }
        }
        public string UsuarioNombre
        {
            get { return txtNombreUsuario.Text; }
            set { txtNombreUsuario.Text = value; }
        }
        public string UsuarioApellido
        {
            get { return txtApellidoUsuario.Text; }
            set { txtApellidoUsuario.Text = value; }
        }
        public string UsuarioEmail
        {
            get { return txtEmailUsuario.Text; }
            set { txtEmailUsuario.Text = value; }
        }
        public string BuscarValor
        {
            get { return txtBuscar.Text; }
            set { txtBuscar.Text = value; }
        }
        public bool EstadoEditar
        {
            get { return estadoEditar; }
            set { estadoEditar = value; }
        }
        public bool EstadoSatisfactorio
        {
            get { return estadoSatisfactorio; }
            set { estadoSatisfactorio = value; }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        #endregion

        #region Eventos
        public event EventHandler EventoBuscar;
        public event EventHandler EventoAgregarUsuario;
        public event EventHandler EventoEditar;
        public event EventHandler EventoBorrar;
        public event EventHandler EventoGuardar;
        public event EventHandler EventoCancelar;
        #endregion

        #region Metodos
        public void SetUsuarioListaBindingSource(BindingSource listaDeUsuarios)
        {
            dgvListaUsuarios.DataSource = listaDeUsuarios;
        }
        #endregion

        //Singleton Pattern ()
        private static VistaUsuario instancia;
        public static VistaUsuario GetInstancia(Form parentContainer)
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new VistaUsuario();
                instancia.MdiParent = parentContainer;
                instancia.FormBorderStyle = FormBorderStyle.None;
                instancia.Dock = DockStyle.Fill;
            }
                

            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;
                    instancia.BringToFront();
            }
                return instancia;
        } 
    }
}
