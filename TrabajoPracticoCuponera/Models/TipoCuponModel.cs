using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoCuponera.Models
{
    [Table("Tipo_Cupon")]
    public class TipoCuponModel
    {
        [Key]
        public int Id_Tipo_Cupon { get; set; }

        public string Nombre { get; set; }

        public ICollection<CuponModel> Cupones { get; set; }
    }
}
