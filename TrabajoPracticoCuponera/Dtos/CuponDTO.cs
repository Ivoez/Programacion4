namespace TrabajoPracticoCuponera.Dtos
{
    public class CuponDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PorcentajeDto { get; set; }
        public decimal? ImportePromo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Id_Tipo_Cupon { get; set; }
        public bool Activo { get; set; }


        public List<CuponDetalleDTO> Detalles { get; set; } = new List<CuponDetalleDTO>();

    }
}
