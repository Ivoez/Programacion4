using System;

namespace TrabajoPracticoCuponera.Dtos
{
    public class CuponHistorialDTO
    {
        public int Id_Historial { get; set; }
        public string NroCupon { get; set; }
        public DateTime FechaUso { get; set; }
        public int Id_Usuario { get; set; }
        public string UsuarioNombre { get; set; }
    }
}
