using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAlumnoServicio
{
    IEnumerable<Alumno> ObtenerAlumnos();
    Alumno ObtenerAlumnoPorId(int id);
    void AgregarAlumno(Alumno alumno);
    void ActualizarAlumno(Alumno alumno);
    void EliminarAlumno(int id);
}
