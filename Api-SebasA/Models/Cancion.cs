using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Cancion
    {
        public int Idcan { get; set; }
        public int? CanXalbFk { get; set; }
        public int CanXgenFk { get; set; }
        public int CanXartFk { get; set; }
        public int? CanXbanFk { get; set; }
        public string NombreCan { get; set; } = null!;
        public int DuracionCan { get; set; }
        public bool EstadoCan { get; set; }
        public int CalificacionCan { get; set; }

        public virtual Album? CanXalbFkNavigation { get; set; }
        public virtual Artista CanXartFkNavigation { get; set; } = null!;
        public virtual Banda? CanXbanFkNavigation { get; set; }
        public virtual Genero CanXgenFkNavigation { get; set; } = null!;
    }
}
