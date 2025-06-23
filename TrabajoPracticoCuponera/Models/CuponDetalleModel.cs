using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoPracticoCuponera.Models
{
    [Table("Cupones_Detalle")]
    public class CuponDetalleModel
    {
        public string NroCupon { get; set; }
        public int id_Articulo { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("NroCupon")]
        public virtual CuponModel Cupon { get; set; }

        [ForeignKey("id_Articulo")]
        public virtual ArticuloModel Articulo { get; set; }
    }
}
