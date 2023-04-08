using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Banda
    {
        public Banda()
        {
            Albums = new HashSet<Album>();
            Cancions = new HashSet<Cancion>();
        }

        public int Idban { get; set; }
        public int BanXartFk { get; set; }
        public string NombreBan { get; set; } = null!;
        public string DescripcionBan { get; set; } = null!;
        public bool EstadoBan { get; set; }

        public virtual Artista BanXartFkNavigation { get; set; } = null!;
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
