using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1Sube.Modelo;
using Parcial1Sube.Vista;

namespace Parcial1Sube.Presentador
{
    public class UsuarioPresentador
    {

        private IUsuarioVista vista;
        private IUsuarioRepositorio repositorio;
        private BindingSource usuariosBindingSource;
        private IEnumerable<UsuarioModelo> listaDeUsuarios;

        public UsuarioPresentador(IUsuarioVista vista, IUsuarioRepositorio repositorio)
        {
            this.usuariosBindingSource = new BindingSource();
            this.vista = vista;
            this.repositorio = repositorio;
            //Suscribir métodos de control de eventos a los eventos de la vista
            this.vista.EventoBuscar += BuscarUsuario;
            this.vista.EventoAgregarUsuario += AgregarUsuarioNuevo;
            this.vista.EventoEditar += CargarUsuarioSelecionadoEditado;
            this.vista.EventoBorrar += BorrarUsuarioSelecionado;
            this.vista.EventoGuardar += GuardarUsuario;
            this.vista.EventoCancelar += CancelarAccion;
            //Configurar la fuente de enlace del los usuarios
            this.vista.SetUsuarioListaBindingSource(usuariosBindingSource);
            //Cargar Lista de Usuarios
            CargarTodaLaListaDeUsuario();
            //Show vista
            this.vista.Show();
        }
        #region Metodos
        private void CargarTodaLaListaDeUsuario()
        {
            listaDeUsuarios = repositorio.GetAll();
            usuariosBindingSource.DataSource = listaDeUsuarios;
        }
        private void BuscarUsuario(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.vista.BuscarValor);
            if (emptyValue == false)
                listaDeUsuarios = repositorio.GetByValue(this.vista.BuscarValor);
            else listaDeUsuarios = repositorio.GetAll();
            usuariosBindingSource.DataSource = listaDeUsuarios;

        }
        private void AgregarUsuarioNuevo(object sender, EventArgs e)
        {
            vista.EstadoEditar = false;
        }
        private void CargarUsuarioSelecionadoEditado(object sender, EventArgs e)
        {
            var usuario = (UsuarioModelo)usuariosBindingSource.Current;
            vista.UsuarioID = usuario.Id.ToString();
            vista.UsuarioNombre = usuario.Nombre;
            vista.UsuarioApellido = usuario.Apellido;
            vista.UsuarioEmail = usuario.Email;
            vista.EstadoEditar = true;
        }
        private void GuardarUsuario(object sender, EventArgs e)
        {
            var modelo = new UsuarioModelo();
            modelo.Id = Convert.ToInt32(vista.UsuarioID);
            modelo.Nombre = vista.UsuarioNombre;
            modelo.Apellido = vista.UsuarioApellido;
            modelo.Email = vista.UsuarioEmail;
            try 
            {
                new Comandos.ValidarDatosDelModelo().Validar(modelo);
                if (vista.EstadoEditar)//Editar modelo
                {
                    repositorio.Editar(modelo);
                    vista.Mensaje = "Usuario editado Satifactoriamente";
                }
                else //Agregar nuevo Modelo
                {
                    repositorio.Agregar(modelo);
                    vista.Mensaje = "Usuario agregado Satifactoriamente";
                }
                vista.EstadoSatisfactorio = true;
                CargarTodaLaListaDeUsuario();
                LimparCuadrosDeTextoVista();
            }
            catch (Exception ex)
            {
                vista.EstadoSatisfactorio = false;
                vista.Mensaje = ex.Message;

            }
        }

        private void LimparCuadrosDeTextoVista()
        {
            vista.UsuarioID = "0";
            vista.UsuarioNombre = "";
            vista.UsuarioApellido = "";
            vista.UsuarioEmail = "";
            
        }

        private void CancelarAccion(object sender, EventArgs e)
        {
            LimparCuadrosDeTextoVista();
        }
        
        private void BorrarUsuarioSelecionado(object sender, EventArgs e)
        {
            try
            {
                var usuario = (UsuarioModelo)usuariosBindingSource.Current;
                repositorio.Borrar(usuario.Id);
                vista.EstadoSatisfactorio = true;
                vista.Mensaje = "Usuario borrado Satifactoriamente";
                CargarTodaLaListaDeUsuario();
            }
            catch (Exception ex)
            {
                vista.EstadoSatisfactorio = false;
                vista.Mensaje = "Se ha producido un error, no se ha podido eliminar al Usuario";
            }
        }
        

        #endregion
    }
}
