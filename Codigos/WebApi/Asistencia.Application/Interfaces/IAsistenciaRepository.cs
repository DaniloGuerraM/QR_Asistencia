using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAsistenciaRepository
{
    IEnumerable<AsistenciaAlumno> ObtenerAsistenciaPorId(int dni);
    bool RegistrarAsistencia(AsistenciaAlumno asistenciaR);
}