using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAlumnoServicio
{
    IEnumerable<Alumno> ObtenerAlumnos();
    Alumno ObtenerAlumnoPorDNI(int dni);
    bool AgregarAlumno(Alumno alumno);
    bool ActualizarAlumno(Alumno alumno);
    bool EliminarAlumno(int id);
}
