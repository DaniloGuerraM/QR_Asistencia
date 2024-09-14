using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IRegistroAsistenciaServicio
{
    RegistroAsistencia PedirAsistenciaPorDNI(int dni);
    bool ActualizarAlumno(Alumno alumno);
    bool TomarAsistenciaPorDNI(int dni);
    
}
