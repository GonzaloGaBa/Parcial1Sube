using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Parcial1Sube.Modelo
{
    public class UsuarioModelo
    {
        //Fields
        private int id;
        private string nombre;
        private string apellido;
        private string email;

        public UsuarioModelo()
        {

        }
        public UsuarioModelo(int id, string nombre, string apellido, string email)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
        }


        #region Propiedades 
        //Validadores de anotacion de datos
        [DisplayName("Usuario ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Usuario Nombre")]
        [Required(ErrorMessage = "Se requiere un nombre para el Usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 3 hasta 50 caracteres")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        [DisplayName("Usuario Apellido")]
        [Required(ErrorMessage = "Se requiere un apellido para el Usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido debe contener entre 3 hasta 50 caracteres")]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        [DisplayName("Usuario Email")]
        [Required(ErrorMessage = "Se requiere un email para el Usuario")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El email debe contener entre 3 hasta 50 caracteres")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion
    }
}
