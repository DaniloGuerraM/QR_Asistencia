using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Asistencia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Asistencia.Infrastructure.Repository;

public class RegistroAsistenciaRepository : IAsistenciaRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public RegistroAsistenciaRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<AsistenciaR> RequestAssistancebyID(int dni)
    {
        return _applicationDbContext.AsistenciasR.ToList();
    }

    public bool takeAttendanceByID(AsistenciaR asistenciaR)
    {
        try
        {
            _applicationDbContext.AsistenciasR.Add(asistenciaR);
            _applicationDbContext.SaveChanges();
            return true;
        }
        catch (System.Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        
    }
}
