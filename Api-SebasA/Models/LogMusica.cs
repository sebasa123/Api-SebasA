using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class LogMusica
    {
        public int Idlog { get; set; }
        public string DescLog { get; set; } = null!;
        public DateTime FechaLog { get; set; }
        public int IdalbFk { get; set; }
        public int IdartFk { get; set; }
        public int IdbanFk { get; set; }
        public int IdcanFk { get; set; }
        public int IdgenFk { get; set; }
        public int IdusFk { get; set; }

        public virtual Album IdalbFkNavigation { get; set; } = null!;
        public virtual Artista IdartFkNavigation { get; set; } = null!;
        public virtual Banda IdbanFkNavigation { get; set; } = null!;
        public virtual Cancion IdcanFkNavigation { get; set; } = null!;
        public virtual Genero IdgenFkNavigation { get; set; } = null!;
        public virtual Usuario IdusFkNavigation { get; set; } = null!;
    }
}
