using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Parcial1Sube.Modelo;

namespace Parcial1Sube._Repositorios
{

    public class RepositorioUsuario : BaseRepositorio, IUsuarioRepositorio
    {
        //Constructor
        public RepositorioUsuario(string conexionString)
        {
            this.conexionString = conexionString;
        }



        //Metodos
        public void Agregar(UsuarioModelo usuarioModelo)
        {
            using (var conexion = new SqlConnection(conexionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "insert into Usuario values ( @nombre , @apellido , @email)";
                comando.Parameters.Add("@nombre", SqlDbType.NChar).Value = usuarioModelo.Nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NChar).Value = usuarioModelo.Apellido;
                comando.Parameters.Add("@email", SqlDbType.NChar).Value = usuarioModelo.Email;
                comando.ExecuteNonQuery();

            }
        }
        public void Borrar(int id)
        {
            using (var conexion = new SqlConnection(conexionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "delete from Usuario where Usuario_Id=@id";
                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();

            }
        }
        public void Editar(UsuarioModelo usuarioModelo)
        {
            using (var conexion = new SqlConnection(conexionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = @"update Usuario set
                                        Usuario_nombre=@nombre ,Usuario_apellido=@apellido , Usuario_email=@email 
                                        where Usuario_Id=@id";
                comando.Parameters.Add("@nombre", SqlDbType.NChar).Value = usuarioModelo.Nombre;
                comando.Parameters.Add("@apellido", SqlDbType.NChar).Value = usuarioModelo.Apellido;
                comando.Parameters.Add("@email", SqlDbType.NChar).Value = usuarioModelo.Email;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = usuarioModelo.Id;
                comando.ExecuteNonQuery();

            }
        }


        public IEnumerable<UsuarioModelo> GetAll()
        {
            var listaDeUsuarios = new List<UsuarioModelo>();
            using (var conexion = new SqlConnection(conexionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "select *from Usuario order by Usuario_Id desc";
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuarioModelo = new UsuarioModelo();
                        usuarioModelo.Id = (int)reader[0];
                        usuarioModelo.Nombre = reader[1].ToString();
                        usuarioModelo.Apellido = reader[2].ToString();
                        usuarioModelo.Email = reader[3].ToString();
                        listaDeUsuarios.Add(usuarioModelo);

                    }
                }
            }
            return listaDeUsuarios;
        }

        public IEnumerable<UsuarioModelo> GetByValue(string value)
        {
            var listaDeUsuarios = new List<UsuarioModelo>();
            int usuarioId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string usuarioNombre = value;
            using (var conexion = new SqlConnection(conexionString))
            using (var comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = @"select *from Usuario
                                        where Usuario_Id=@id or Usuario_nombre like @nombre+'%'
                                        order by Usuario_Id desc";
                comando.Parameters.Add("@id", SqlDbType.Int).Value = usuarioId;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = usuarioNombre;
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuarioModelo = new UsuarioModelo();
                        usuarioModelo.Id = (int)reader[0];
                        usuarioModelo.Nombre = reader[1].ToString();
                        usuarioModelo.Apellido = reader[2].ToString();
                        usuarioModelo.Email = reader[3].ToString();
                        listaDeUsuarios.Add(usuarioModelo);

                    }
                }
            }
            return listaDeUsuarios;
        }
    }
}
