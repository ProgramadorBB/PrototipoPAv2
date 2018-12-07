﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
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

                return Instancia;
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
                    throw new Exception("Email inválido");
                else if (string.IsNullOrEmpty(contraseña))
                    throw new Exception("Contraseña inválida");
                else if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre inválido");
                else if (string.IsNullOrEmpty(apellido))
                    throw new Exception("Apellido inválido");
                else if (string.IsNullOrEmpty(color))
                    throw new Exception("Color selecionado inválido");
                else if (string.IsNullOrEmpty(tipo))
                    throw new Exception("Tipo de usuario inválido");
                else if (string.IsNullOrEmpty(estado))
                    throw new Exception("Error en el estado del Usuario");

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

    }
}
