using System;
using System.Collections.Generic;

namespace coderush.Models
{
    public partial class TipoDocumento
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
       
    }
}
