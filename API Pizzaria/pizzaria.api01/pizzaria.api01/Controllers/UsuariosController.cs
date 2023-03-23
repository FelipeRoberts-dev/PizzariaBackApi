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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario<Usuarios> _usuariosRepositorio;


        public UsuariosController(IDbConnection dbConnection)
        {
            _usuariosRepositorio = new UsuariosRepositorio(dbConnection);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuarios = await _usuariosRepositorio.GetByIdUsuario(id);
            if (usuarios == null)
                return NotFound();

            return Ok(usuarios);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuariosRepositorio.ListarUsuario();
            return Ok(usuarios);
        }

        [HttpPost("Incluir")]
        public async Task<IActionResult> IncluirUsuarios([FromBody] Usuarios usuarios)
        {
            var id = await _usuariosRepositorio.InserirUsuarios(usuarios);
            usuarios.Id = id;

            return CreatedAtAction(nameof(GetById), new { id = usuarios.Id }, usuarios);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<IActionResult> AlterarUsuarios(int id, [FromBody] Usuarios usuarios)
        {
            if (id != usuarios.Id)
                return BadRequest();

            var result = await _usuariosRepositorio.AlterarUsuarios(usuarios);
            if (!result)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> ExcluirUsuarios(int id)
        {
            var result = await _usuariosRepositorio.ExcluirUsuarios(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}
