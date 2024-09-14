using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;

namespace Asistencia.Application;

public class AlumnoServicio : IAlumnoServicio
{
    private readonly IAlumnoRepository _alumnoRepository;
    public AlumnoServicio(IAlumnoRepository alumnoRepository)
    {
        _alumnoRepository = alumnoRepository;
    }
/////////////////////////////////////////////////////
    public bool ActualizarAlumno(Alumno alumno)
    {
        _alumnoRepository.UpdateAlumno(alumno);
        return true;
    }
/////////////////////////////////////////////////////
    public bool AgregarAlumno(Alumno alumno)
    {
        _alumnoRepository.AddAlumno(alumno);
        return true;
    }
/////////////////////////////////////////////////////
    public bool EliminarAlumno(int id)
    {
        _alumnoRepository.DeleteAlumno(id);
        return true;
    }
/////////////////////////////////////////////////////
    public Alumno ObtenerAlumnoPorDNI(int id)
    {
        return _alumnoRepository.GetAlumnoById(id);
    }
/////////////////////////////////////////////////////
    public IEnumerable<Alumno> ObtenerAlumnos()
    {
        return _alumnoRepository.GetAlumnos();
    }
}
