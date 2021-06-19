using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App02SQLite.Model
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        [MaxLength(250)]
        public string Nombres { get; set; }

        [MaxLength(250)]
        public string Apellidos { get; set; }

        public string Fechanac { get; set; }
        
        public int Edad { get; set; }

        [MaxLength(100), Unique]
        public string Correo { get; set; }

        [MaxLength(300)]
        public string Direccion { get; set; }
    }
}
