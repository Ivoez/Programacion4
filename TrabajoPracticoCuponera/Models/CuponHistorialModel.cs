using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoPracticoCuponera.Models;

[Table("Cupones_Historial")]
public class CuponHistorialModel
{
    [Key]
    public int Id_Historial { get; set; }

    public string NroCupon { get; set; }

    public DateTime FechaUso { get; set; }

    public int Id_Usuario { get; set; }

    [ForeignKey("Id_Usuario")]
    public UserModel Usuario { get; set; }
}