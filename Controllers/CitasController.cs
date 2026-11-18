using ClinicaCitas.Models;
using ClinicaCitas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaCitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;

        // Inyección de dependencias
        public CitasController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        // GET: api/citas
        [HttpGet]
        public IActionResult GetCitas()
        {
            var citas = _citaService.ObtenerTodas();
            return Ok(citas); // Retorna 200 OK
        }

        // GET: api/citas/5
        [HttpGet("{id}")]
        public IActionResult GetCita(int id)
        {
            var cita = _citaService.ObtenerPorId(id);
            if (cita == null)
            {
                return NotFound(new { message = $"No se encontró la cita con ID {id}." }); // Retorna 404 Not Found
            }
            return Ok(cita);
        }

        // POST: api/citas
        [HttpPost]
        public IActionResult PostCita([FromBody] Cita cita)
        {
            // Valida automáticamente las Data Annotations del Modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna 400 Bad Request
            }

            var nuevaCita = _citaService.Registrar(cita);
            // Retorna 201 Created con la URL para consultar el nuevo recurso
            return CreatedAtAction(nameof(GetCita), new { id = nuevaCita.Id }, nuevaCita);
        }

        // PUT: api/citas/5
        [HttpPut("{id}")]
        public IActionResult PutCita(int id, [FromBody] Cita cita)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actualizado = _citaService.Actualizar(id, cita);
            if (!actualizado)
            {
                return NotFound(new { message = $"No se encontró la cita con ID {id} para actualizar." });
            }

            return NoContent(); // 204 No Content es el estándar para actualizaciones exitosas
        }

        // DELETE: api/citas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCita(int id)
        {
            var eliminado = _citaService.Eliminar(id);
            if (!eliminado)
            {
                return NotFound(new { message = $"No se encontró la cita con ID {id} para eliminar." });
            }

            return NoContent();
        }
    }
}