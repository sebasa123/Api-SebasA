using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }
        public int IdtipoUs { get; set; }
        public string DescTipoUs { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
