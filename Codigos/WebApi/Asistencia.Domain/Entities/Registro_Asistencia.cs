namespace Asistencia.Domain.Entities;

public class Registro_Asistencia
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
