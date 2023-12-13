using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1Sube.Vista
{
    public interface IUsuarioVista
    {
        #region Atributos
        string UsuarioID { get; set; }
        string UsuarioNombre { get; set; }
        string UsuarioApellido { get; set; }
        string UsuarioEmail { get; set; }

        string BuscarValor { get; set; }
        bool EstadoEditar { get; set; }
        bool EstadoSatisfactorio { get; set; }
        string Mensaje { get; set; }
        #endregion
        #region Eventos
        event EventHandler EventoBuscar;
        event EventHandler EventoAgregarUsuario;
        event EventHandler EventoEditar;
        event EventHandler EventoBorrar;
        event EventHandler EventoGuardar;
        event EventHandler EventoCancelar;
        #endregion
        #region Metodos
        void SetUsuarioListaBindingSource(BindingSource listaDeUsuarios);
        void Show();
        #endregion
    }
}
