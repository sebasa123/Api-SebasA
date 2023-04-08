using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Album
    {
        public Album()
        {
            Cancions = new HashSet<Cancion>();
        }

        public int Idalb { get; set; }
        public int AlbXgenFk { get; set; }
        public int AlbXartFk { get; set; }
        public int? AlbXbanFk { get; set; }
        public string NombreAlb { get; set; } = null!;
        public int DuracionAlb { get; set; }
        public DateTime FechaAlb { get; set; }
        public bool EstadoAlb { get; set; }
        public int CalificacionAlb { get; set; }

        public virtual Artista AlbXartFkNavigation { get; set; } = null!;
        public virtual Banda? AlbXbanFkNavigation { get; set; }
        public virtual Genero AlbXgenFkNavigation { get; set; } = null!;
        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
