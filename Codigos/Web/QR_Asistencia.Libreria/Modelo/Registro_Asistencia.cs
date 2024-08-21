using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QR_Asistencia.Libreria.Modelo;
[Table("registro_asistencia")]
public class Registro_Asistencia
{
    [Key]
    [Column("registro_id")]
    public int Id_Registro {get; set; }
    [ForeignKey("alumno")]
    [Column("dni")]
    public int DNI {get; set; }
    public Alumno AlumnoRegistro_Asistencia {get; set;}
    [Column("fecha")]
    public DateTime Fecha {get; set;}
}
