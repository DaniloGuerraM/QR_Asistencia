using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IRegistroAsistenciaRepository
{
    RegistroAsistencia RequestAssistancebyID(int dni);
    bool UpdateAlumno(Alumno alumno);
    bool takeAttendanceByID(int dni);
}