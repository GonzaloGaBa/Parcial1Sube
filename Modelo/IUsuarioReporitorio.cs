using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1Sube.Modelo
{
    public interface IUsuarioRepositorio
    {
        void Agregar(UsuarioModelo usuarioModelo);
        void Editar(UsuarioModelo usuarioModelo);
        void Borrar(int id);
        IEnumerable<UsuarioModelo> GetAll();
        IEnumerable<UsuarioModelo> GetByValue(string value);//Searchs

    }
}
