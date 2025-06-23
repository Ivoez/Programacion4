using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajoPracticoCuponera.Models
{
    [Table("Cupones")]
    public class CuponModel
    {
        [Key]
        public string NroCupon { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? PorcentajeDto { get; set; }
        public decimal? ImportePromo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Id_Tipo_Cupon { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Id_Tipo_Cupon")]
        public virtual TipoCuponModel TipoCupon { get; set; }

        public virtual ICollection<CuponDetalleModel> Detalles { get; set; }
    }
}