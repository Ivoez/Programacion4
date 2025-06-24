namespace TrabajoPracticoCuponera.Dtos
{
    public class ArticuloDTO
    {
        public int Id_Articulo { get; set; }
        public string Nombre_Articulo { get; set; }
        public string Descripcion_Articulo { get; set; }
        public bool Activo { get; set; }
        public decimal Precio { get; set; }
    }
}