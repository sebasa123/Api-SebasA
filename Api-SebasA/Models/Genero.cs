using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Albums = new HashSet<Album>();
            Cancions = new HashSet<Cancion>();
        }

        public int Idgen { get; set; }
        public string NombreGen { get; set; } = null!;
        public string DescripcionGen { get; set; } = null!;
        public bool EstadoGen { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
