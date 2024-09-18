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

    public bool ActualizarAlumnoMac(AlumnoDTO alumnoDTO)
    {
        var alumno = _alumnoRepository.GetAlumnoById(alumnoDTO.DNI);
        if (alumno != null)
        {
            alumno.MAC = alumnoDTO.MAC;
            _alumnoRepository.UpdateAlumno(alumno);
            return true;
        }else{
            return false;
        }
    }

    /////////////////////////////////////////////////////
    public int AgregarAlumno(Alumno alumno)
    {
        _alumnoRepository.AddAlumno(alumno);
        return 1;
    }
/////////////////////////////////////////////////////
    public bool EliminarAlumno(int id)
    {
        _alumnoRepository.DeleteAlumno(id);
        return true;
    }
/////////////////////////////////////////////////////
    public Alumno ObtenerAlumnoPorDNI(int dni)
    {
        return _alumnoRepository.GetAlumnoById(dni);
    }
/////////////////////////////////////////////////////
    public IEnumerable<Alumno> ObtenerAlumnos()
    {
        return _alumnoRepository.GetAlumnos();
    }
/////////////////////////////////////////////////////
    public Alumno ObtenerPorMac(string mac)
    {
        return _alumnoRepository.GetByMac(mac);
    }
}
