using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Artista
    {
        public Artista()
        {
            Albums = new HashSet<Album>();
            Banda = new HashSet<Banda>();
            Cancions = new HashSet<Cancion>();
            LogMusicas = new HashSet<LogMusica>();
        }

        public int Idart { get; set; }
        public string NombreArt { get; set; } = null!;
        public string DescripcionArt { get; set; } = null!;
        public bool EstadoArt { get; set; }
        public bool TipoArt { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Banda> Banda { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
        public virtual ICollection<LogMusica> LogMusicas { get; set; }
    }
}
