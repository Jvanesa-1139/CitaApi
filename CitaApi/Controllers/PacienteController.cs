using CitaApi.DTos;
using CitaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _repo;
        public PacienteController(IPacienteService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPacientes()
        {
            var pacients = await _repo.GetAll();
                return Ok(pacients);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            var paciente = await _repo.getPacienteById(id);
            if (paciente == null)
                return NotFound("No existe paciente con id ingresado");
            return Ok(paciente);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePaciente([FromBody] CreatePacienteDto dto)
        {
            var pacienteNuevo = await _repo.CreatePacienteAsync(dto);
            if (pacienteNuevo == false)
            {
                return BadRequest("No se pudo crear el paciente ");
            }
            return Ok(pacienteNuevo);
                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaciente(int id, [FromBody] UpdatePacienteDto updatePaciente)
        {
            if (updatePaciente == null)
                return BadRequest("Formulario vacio");
            var paciente = await _repo.UpdatePacienteAsync(id, updatePaciente);
            if (!paciente)
            {
                return NotFound("Paciente no esta registrado");
            }
            return Ok(paciente);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacienteAsync(int id)
        {
            var paciente = await _repo.DeletePacienteAsync(id);
            if(paciente == "Not Fpund")
                return NotFound();
            if (paciente == "Tiene Citas")
                return BadRequest();
            return Ok(paciente);
        }


    }

}
