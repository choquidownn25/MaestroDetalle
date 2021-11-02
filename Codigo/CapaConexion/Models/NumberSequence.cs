using System;
using System.Collections.Generic;

namespace CapaConexion.Models
{
    public partial class NumberSequence
    {
        public int NumberSequenceId { get; set; }
        public int LastNumber { get; set; }
        public string Module { get; set; }
        public string NumberSequenceName { get; set; }
        public string Prefix { get; set; }
    }
}
