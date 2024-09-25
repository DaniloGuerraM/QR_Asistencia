using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QR_Asistencia.Libreria.Modelo;
[Table("alumno")]
public class Alumno
{
    [Key]
    [Column("dni")]
    public int DNI {get; set; }
     [Column("nombre")]
    public string Nombre {get; set; }
     [Column("apellido")]
    public string Apellido {get; set; }
     [Column("mac")]
    public string? MAC {get; set; }
}
