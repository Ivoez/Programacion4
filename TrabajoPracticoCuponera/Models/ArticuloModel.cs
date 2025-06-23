using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoCuponera.Models
{
    [Table("Articulos")]
    public class ArticuloModel
    {
        [Key]
        public int Id_Articulo { get; set; }

        public string Nombre_Articulo { get; set; }

        public string Descripcion_Articulo { get; set; }

        public bool Activo { get; set; }

        public decimal Precio { get; set; }
    }
}