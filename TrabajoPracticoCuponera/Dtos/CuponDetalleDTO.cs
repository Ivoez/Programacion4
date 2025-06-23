namespace TrabajoPracticoCuponera.Dtos
{
    public class CuponDetalleDTO
    {
        public CuponDTO Cupon { get; set; }
        public List<DetalleItemDTO> Detalles { get; set; }
    }

    public class DetalleItemDTO
    {
        public int Id_Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
