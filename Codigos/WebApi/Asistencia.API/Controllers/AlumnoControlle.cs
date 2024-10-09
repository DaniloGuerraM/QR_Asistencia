using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController : ControllerBase
{
    private readonly IAlumnoServicio _alumnoServicio;
    public AlumnoController(IAlumnoServicio alumnoServicio)
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
    [HttpGet("Dni")]
    public ActionResult<Alumno> GetAlumno(int dni)
    {
        var alumno = _alumnoServicio.ObtenerAlumnoPorDNI(dni);
        if (alumno == null)
        {
            return Ok("No encontrado");//NotFound();
        }
        return Ok(alumno);
    }
////////////////////////////////////////////////////////////
    [HttpPost]
    public IActionResult AddAlumno([FromBody] Alumno alumno)
    {
        _alumnoServicio.AgregarAlumno(alumno);
        return CreatedAtAction(nameof(GetAlumno),new {id = alumno.DNI}, alumno);
    }
////////////////////////////////////////////////////////////
    [HttpPut("dni")]
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
    [HttpPut("mac")]
    public IActionResult UpdateAlumnoMAC([FromBody] AlumnoDTO alumnoDTO)
    {
        if (_alumnoServicio.ActualizarAlumnoMac(alumnoDTO))
        {
            return Ok("Asistencia tomada");
        }else{
            return BadRequest();
        }
    }

////////////////////////////////////////////////////////////
    [HttpDelete()]
    public IActionResult DeleteAlumno(int dni)
    {
        _alumnoServicio.EliminarAlumno(dni);
        return NoContent();
    }
}
