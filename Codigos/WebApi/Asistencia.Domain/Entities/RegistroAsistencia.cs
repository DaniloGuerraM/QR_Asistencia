using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Asistencia.Domain.Entities;

public class RegistroAsistencia
{
    [Key]
    [Column("registro_id")]
    public int IdRegistro {get; set; }
    
    [Column("fecha")]
    public long Fecha {get; set;}

    [ForeignKey("AlumnoRegistroAsistencia")]
    [Column("dni")]
    public int DNI {get; set; }

    public Alumno AlumnoRegistroAsistencia {get; set;}
}
