using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnoControlle : ControllerBase
{
    private readonly IAlumnoServicio _alumnoServicio;
    public AlumnoControlle(IAlumnoServicio alumnoServicio)
    {
        _alumnoServicio = alumnoServicio;
    }
////////////////////////////////////////////////////////////
    [HttpGet]
    public ActionResult<IEnumerable<Alumno>> GetAlumnos()
    {
        var alumno = _alumnoServicio.ObtenerAlumnos();
        return Ok(alumno);
    }
////////////////////////////////////////////////////////////
    [HttpGet("{DNI}")]
    public ActionResult<Alumno> GetAlumno(int dni)
    {
        var alumno = _alumnoServicio.ObtenerAlumnoPorDNI(dni);
        if (alumno == null)
        {
            return NotFound();
        }
        return Ok(alumno);
    }
////////////////////////////////////////////////////////////
    [HttpPost]
    public IActionResult AddAlumno([FromBody] Alumno alumno)
    {
        return CreatedAtAction(nameof(GetAlumno),new {id = alumno.DNI}, alumno);
    }
////////////////////////////////////////////////////////////
    [HttpPut("{DNI}")]
    public IActionResult UpdateAlumno(int dni, [FromBody] Alumno alumno)
    {
        if (dni != alumno.DNI)
        {
            return BadRequest();
        }
        _alumnoServicio.ActualizarAlumno(alumno);
        return NoContent();
    }
////////////////////////////////////////////////////////////
    [HttpDelete("{DNI}")]
    public IActionResult DeleteAlumno(int dni)
    {
        _alumnoServicio.EliminarAlumno(dni);
        return NoContent();
    }
}
