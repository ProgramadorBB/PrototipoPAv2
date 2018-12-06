using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PrototipoPAv2.Modelo
{
    [Table("Usuarios")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(100),Unique]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Contraseña { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        //nose si va algo acá para el int de EDAD
        // public int Edad { get; set; } no sabemos si es relevante
        [MaxLength(25)]
        public string Color { get; set; }
        [MaxLength(25)]
        public string Tipo { get; set; }
        [MaxLength(25)]
        public string Estado { get; set; }


    }
}
