using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Asistencia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroAsistenciaController : ControllerBase
    {
        private readonly IAsistenciaServicio _registroAsistenciaServicio;
        public RegistroAsistenciaController(IAsistenciaServicio registroAsistenciaServicio)
        {
            _registroAsistenciaServicio = registroAsistenciaServicio;
        }
        [HttpGet("{dni}")]
        public ActionResult<IEnumerable<AsistenciaR>> GetRegistro(int dni)
        {
            var asistenciat = _registroAsistenciaServicio.PedirAsistenciaPorDNI(dni);
            return Ok(asistenciat);
        }
        [HttpPost]
        public IActionResult TomarAsistencia([FromBody] AsistenciaDTO asistenciaDTO)
        {
            if (_registroAsistenciaServicio.TomarAsistenciaPorDNI(asistenciaDTO))
            {
                return Ok();
            }else{
                return NotFound();
            }
        }
    }
}