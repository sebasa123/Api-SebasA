using Api_SebasA.Models;

namespace Api_SebasA.ModelsDTO
{
    public class UsuarioDTO
    {
        public int Idus { get; set; }
        public string NombreUs { get; set; } = null!;
        public string ContraUs { get; set; } = null!;
        public bool EstadoUs { get; set; }
        public string DescTipoUs { get; set; } = null!;
    }
}

