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
    public void AddAlumno(Alumno alumno)
    {
        _applicationDbContext.Alumnos.Add(alumno);
        _applicationDbContext.SaveChanges();
        //throw new NotImplementedException();
    }

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

    public Alumno GetAlumnoById(int id)
    {
        return _applicationDbContext.Alumnos.Find(id);
        //throw new NotImplementedException();
    }

    public IEnumerable<Alumno> GetAlumnos()
    {
        throw new NotImplementedException();
    }

    public void UpdateAlumno(Alumno alumno)
    {
        throw new NotImplementedException();
    }
}
