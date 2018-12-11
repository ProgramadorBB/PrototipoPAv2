using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using PrototipoPAv2.Modelo;// llamamos a la carpeta modelo para poder usar la clase usuario

namespace PrototipoPAv2.Conexiones
{
    public class UsuarioRepository
    {
        private SQLiteConnection con;
        private static UsuarioRepository instancia;
        public static UsuarioRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al Inicializador");

                return instancia;
            }
                
        }

        public static void Inicializador(String filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            if (instancia != null)
                instancia.con.Close();

            instancia = new UsuarioRepository(filename);
        }
        private UsuarioRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);

            con.CreateTable<Usuario>();
        }

        public string EstadoMensaje;

        public void AddNuevoUsuario(string email, string contraseña, 
                                    string nombre, string apellido,
                                    string color, string tipo,
                                    string estado)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new Exception("email inválido");
                if (string.IsNullOrEmpty(contraseña))
                    throw new Exception("contraseña inválida");
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("nombre inválido");
                if (string.IsNullOrEmpty(apellido))
                    throw new Exception("apellido inválido");
                if (string.IsNullOrEmpty(color))
                    throw new Exception("color inválido");
                if (string.IsNullOrEmpty(tipo))
                    throw new Exception("tipo inválido");
                if (string.IsNullOrEmpty(estado))
                    throw new Exception("estado inválido");


                result = con.Insert(new Usuario() {
                                     Email = email,
                                     Contraseña = contraseña,
                                     Nombre = nombre,
                                     Apellido = apellido,
                                     Color = color,
                                     Tipo = tipo,
                                     Estado = estado
                                    });
                EstadoMensaje = string.Format("{0} Nuevo usuario añadido", result);
            } catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            try
            {
                return con.Table<Usuario>();
            } catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }

        public Boolean AttempLogin(string email, string contraseña)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Ingrese un email válido");
                if (string.IsNullOrEmpty(contraseña))
                    throw new Exception("Ingrese una Contraseña válida");
                var usuario = from u in con.Table<Usuario>()
                              where u.Email == email && u.Contraseña == contraseña 
                              select u;

                Usuario user = usuario.SingleOrDefault();

                if (user != null)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
                return false;
            }
            
            EstadoMensaje = "Usuario no registrado";
            return false;
        }

        public Usuario userType (string email, string contraseña)
        {
            var usuario = from u in con.Table<Usuario>()
                          where u.Email == email && u.Contraseña == contraseña
                          select u;

            Usuario uTipo = usuario.SingleOrDefault();

            return uTipo;

        }

        public int UpdateUser(Usuario u)
        {
            int result = 0;

            try
            {
                result = con.Update(u);

                if(result > 0)
                {
                    EstadoMensaje = string.Format("Actualizando [Id: {0}]", u.Id);
                }

            }catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            try
            {
                result = con.Delete<Usuario>(id);

                if(result > 0)
                {
                    EstadoMensaje = string.Format("Eliminado [id: {0}]", id);
                }


            }catch(Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return result;
        }

    }
}
