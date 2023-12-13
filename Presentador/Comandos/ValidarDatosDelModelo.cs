using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Parcial1Sube.Presentador.Comandos
{
    public class ValidarDatosDelModelo
    {
        //Metodo para validar un objeto
        public void Validar(object modelo)
        {
            string mensajeDeError = "";//Campo para el mensaje de error.
            List<ValidationResult> resultado = new List<ValidationResult>();//Lista para el Resultado de la Validaciones
            ValidationContext contexto = new ValidationContext(modelo);//Contexto para la Validacion de Modelo
            bool esValido = Validator.TryValidateObject(modelo, contexto, resultado, true);//Determinar si el objeto es valido segun los parametros sean todos true.
            if (esValido == false)
            { 
                //Reccorer la lista de resultado y extraer mensajes de error para asignar al campo mensajeDeError.
                foreach(var item in resultado)
                {
                    mensajeDeError += "- " + item.ErrorMessage + "\n";
                    //Generamos una excepcion con los mensajes y los capturamos en el bloque try Cath del presentador.
                    throw new Exception(mensajeDeError);
                }
            }
        }
    }
}
