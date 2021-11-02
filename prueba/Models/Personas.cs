using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Models
{
    public class Personas
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
