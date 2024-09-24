using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAsistenciaRepository
{
    IEnumerable<AsistenciaR> RequestAssistancebyID(int dni);
    bool takeAttendanceByID(AsistenciaR asistenciaR);
}