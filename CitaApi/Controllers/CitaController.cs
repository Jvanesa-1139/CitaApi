using CitaApi.DTos;
using CitaApi.Entities;
using CitaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _repoCita;

        public CitaController(ICitaService repoCita)
        {
            _repoCita = repoCita;
        }

        [HttpGet]
        public async Task<IActionResult> GetallCitasAsync()
        {
            var citas = await _repoCita.GetAllCitasAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCitasById(int id)
        {
            var cita = await _repoCita.GetCitaByID(id);
            if (cita == null)
                return NotFound("no existen cita con ese ID");
            return Ok(cita);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCitaAsync([FromBody] CreateCitaDto cita)
        {
            if (cita == null)
                return BadRequest("formulario vacio");
            bool citaNueva = await _repoCita.CreateCitaAsync(cita);
            if (!citaNueva)
                return BadRequest("fecha mal creada");
            return Ok("Cita creada correctamente");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCitaAsync(int id, [FromBody] UpdateCitaDto cita)
        {
            if (cita == null)
                return BadRequest("formulario vacio");
           bool CitaUp =  await _repoCita.UpdateCitaAsync(id, cita);
            if (!CitaUp)
                return NotFound("Cita no encontrada");
            return Ok("se actualizo correctamente");

        }

        [HttpGet("/medico/{medicoId}")]

        public async Task<IActionResult> GetCitaByMedicoId(int medicoId)
        {
           var citaByMedico= await _repoCita.GetCitaByMedicoId(medicoId);
            if (citaByMedico == null)
                return Ok("No existe cita para ese el medico consultado");
            return Ok(citaByMedico);    
        

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var CitaEliminada = await _repoCita.DeleteCitaAsync(id);
            if (!CitaEliminada)
                return NotFound("No se encontro cita");
            return Ok($"Se elimino la cita con el id: {id}");
        }


    }
}
