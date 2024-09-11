using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAlumnoRepository
{
    IEnumerable<Alumno> GetAlumnos();
    Alumno GetAlumnoById(int id);
    void AddAlumno(Alumno alumno);
    void UpdateAlumno(Alumno alumno);
    void DeleteAlumno(int id);
}
