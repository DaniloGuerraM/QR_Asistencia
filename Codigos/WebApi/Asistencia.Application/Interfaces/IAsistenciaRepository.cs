using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAsistenciaRepository
{
    AsistenciaR RequestAssistancebyID(int dni);
    bool takeAttendanceByID(AsistenciaR asistenciaR);
}