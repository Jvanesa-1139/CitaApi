using CitaApi.DTos;
using CitaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CitaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoService _repo;
        public MedicoController(IMedicoService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Medicos = await _repo.GetAllAsync();

            if (Medicos.Count() == 0)
                return Ok("No existe medicos  registrados");
            return Ok(Medicos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Medico = await _repo.GetByIdAsync(id);
            if (Medico == null)
                return NotFound();
            return Ok(Medico);
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsyn([FromBody] CreateMedicoDto dto)
        {
            bool resultado = await _repo.CreateAsync(dto);
            if (!resultado)
            {
                return BadRequest("Formulario vacio");
            }
            return Ok("Medico creado correctamente");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminacionMedicos(int id)
        {
            var medicoDelete = await _repo.DeleteAsync(id);
            if (medicoDelete == "Not found")
            {
                return NotFound("Medico no existe");
            }
            else if (medicoDelete == "Tiene Citas")
            {
                return BadRequest("El medico no se puede eliminar porque tiene citas activas");
            }

            return Ok(medicoDelete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizacionMedicos(int id,[FromBody] UpdateMedicoDto updto)
        {
            bool resultado = await _repo.UpdateAsync(id, updto);
            if (!resultado)
                return NotFound("Cliente no existe");
            return Ok(resultado);


        }
    }
}
