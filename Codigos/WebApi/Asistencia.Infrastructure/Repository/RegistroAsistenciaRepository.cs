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

    public IEnumerable<AsistenciaAlumno> ObtenerAsistenciaPorId(int dni)
    {
        //var asistenciaRa =
        //return _applicationDbContext.AsistenciasR.ToList();
        return _applicationDbContext.AsistenciasR.Where(d => d.AlumnoDNI == dni).ToList();
        /*
        return _applicationDbContext.Alumnos
        .Where(d => d.MAC.ToLower().Contains(mac.ToLower()))
        .FirstOrDefault();
        */
    }


    public bool RegistrarAsistencia(AsistenciaAlumno asistenciaR)
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
