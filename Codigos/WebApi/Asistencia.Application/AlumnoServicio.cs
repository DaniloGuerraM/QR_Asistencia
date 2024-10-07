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
        var alumnoIS = ObtenerAlumnoPorDNI(alumno.DNI);
        if (alumnoIS == null)
        {
            throw new InvalidDataException("El alumno no existe");
        }
        if (_alumnoRepository.UpdateAlumno(alumno)){
            return true;
        }else{
            return false;
        }
    }
/////////////////////////////////////////////////////

    public bool ActualizarAlumnoMac(AlumnoDTO alumnoDTO)
    {
        var alumno =  ObtenerAlumnoPorDNI(alumnoDTO.DNI);
        if (alumno != null )//&& alumno.MAC ==null
        {
            var alumnaMac = ObtenerPorMac(alumnoDTO.MAC);
            alumno.MAC = alumnoDTO.MAC;
            if(ActualizarAlumno(alumno))
            {
                return true;
            }else{
                return false;
            }
            
        }else{
            return false;
        }
    }

    /////////////////////////////////////////////////////
    public int AgregarAlumno(Alumno alumno)
    {
        var alumnoExiste = ObtenerAlumnoPorDNI(alumno.DNI);
        if (alumnoExiste != null)
        {
            throw new InvalidDataException("El alumno ya existe");
        }else if (String.IsNullOrEmpty(alumno.Nombre) && String.IsNullOrEmpty(alumno.Apellido)){
            throw new InvalidDataException("Datos vacios");
        }
        _alumnoRepository.AddAlumno(alumno);
        return 1;
    }
/////////////////////////////////////////////////////
    public bool EliminarAlumno(int id)
    {
        var alumno = ObtenerAlumnoPorDNI(id);
        if (alumno == null){
            throw new InvalidDataException("El alumno no existe");
        }
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
