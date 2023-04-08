using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class CodigoRecuperacion
    {
        public int Idcod { get; set; }
        public string Codigo { get; set; } = null!;
        public DateTime FechaCod { get; set; }
        public bool EstadoCod { get; set; }
        public string CorreoElec { get; set; } = null!;
    }
}
