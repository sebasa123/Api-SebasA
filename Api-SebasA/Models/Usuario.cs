﻿using System;
using System.Collections.Generic;

namespace Api_SebasA.Models
{
    public partial class Usuario
    {
        public int Idus { get; set; }
        public string NombreUs { get; set; } = null!;
        public string ContraUs { get; set; } = null!;
        public bool EstadoUs { get; set; }
        public virtual TipoUsuario? TipoUsuario { get; set; }
    }
}
