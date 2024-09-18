using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Asistencia.Infrastructure.Data;

namespace Asistencia.Infrastructure.Repository;

public class RegistroAsistenciaRepository : IAsistenciaRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public RegistroAsistenciaRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public AsistenciaR RequestAssistancebyID(int dni)
    {
        return _applicationDbContext.AsistenciasR.Find(dni);
    }

    public bool takeAttendanceByID(AsistenciaR asistenciaR)
    {
        throw new NotImplementedException();
    }
}
