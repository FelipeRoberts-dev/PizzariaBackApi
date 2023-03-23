using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizzaria.api01.Interface;
using pizzaria.api01.Model;
using pizzaria.api01.Repositorio;
using System.Data;

namespace pizzaria.api01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaPrimaController : ControllerBase
    {
        private readonly IMateriaPrima<MateriaPrimas> _materiaprimaRepositorio;

        public MateriaPrimaController(IDbConnection dbConnection)
        {
            _materiaprimaRepositorio = new MateriaPrimaRepositorio(dbConnection);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var materiaPrimas = await _materiaprimaRepositorio.GetByIdMateriaPrima(id);
            if (materiaPrimas == null)
                return NotFound();

            return Ok(materiaPrimas);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarMateriaPrima()
        {
            var materiaPrimas = await _materiaprimaRepositorio.ListarMateriaPrima();
            return Ok(materiaPrimas);
        }

        [HttpPost("Incluir")]
        public async Task<IActionResult> IncluirMateriaPrima([FromBody] MateriaPrimas materiaPrima)
        {
            var id = await _materiaprimaRepositorio.InserirMateriaPrima(materiaPrima);
            materiaPrima.Id = id;

            return CreatedAtAction(nameof(GetById), new { id = materiaPrima.Id }, materiaPrima);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<IActionResult> AlterarMateriaPrima(int id, [FromBody] MateriaPrimas materiaPrima)
        {
            if (id != materiaPrima.Id)
                return BadRequest();

            var result = await _materiaprimaRepositorio.AlterarMateriaPrima(materiaPrima);
            if (!result)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> ExcluirMateriaPrima(int id)
        {
            var result = await _materiaprimaRepositorio.ExcluirMateriaPrima(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
