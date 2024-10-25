using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Asistencia.Infrastructure.Data;

namespace Asistencia.Infrastructure.Repository;

public class AlumnoRepository : IAlumnoRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public AlumnoRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
/////////////////////////////////////////////////////
    public bool AddAlumno(Alumno alumno)
    {
        try
        {
            var sinMac = alumno;
            sinMac.MAC = null;
            _applicationDbContext.Alumnos.Add(sinMac);
            _applicationDbContext.SaveChanges();
            return true;
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }
        //throw new NotImplementedException();
    }
/////////////////////////////////////////////////////
    public void DeleteAlumno(int id)
    {
        var alumno = _applicationDbContext.Alumnos.Find(id);
        if (alumno != null)
        {
            _applicationDbContext.Alumnos.Remove(alumno);
            _applicationDbContext.SaveChanges();
        }
        //throw new NotImplementedException();
    }
/////////////////////////////////////////////////////
    public Alumno GetAlumnoById(int dni)
    {
        return _applicationDbContext.Alumnos.Find(dni);
        //return _applicationDbContext.Alumnos.Find(dni);
        //throw new NotImplementedException();
    }
/////////////////////////////////////////////////////
    public IEnumerable<Alumno> GetAlumnos()
    {
        return _applicationDbContext.Alumnos.ToList();
        //throw new NotImplementedException();
    }
/////////////////////////////////////////////////////
    public Alumno GetByMac(string mac)
    {
        return _applicationDbContext.Alumnos
        .Where(d => d.MAC.ToLower().Contains(mac.ToLower()))
        .FirstOrDefault();
    }

    /////////////////////////////////////////////////////
    public bool UpdateAlumno(Alumno alumno)
    {
        try
        {
            _applicationDbContext.Alumnos.Update(alumno);
            _applicationDbContext.SaveChanges();
            return true;
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }

        //throw new NotImplementedException();
    }
}
