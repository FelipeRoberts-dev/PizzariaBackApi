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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutos<Produtos> _produtosRepositorio;

        public ProdutosController(IDbConnection dbConnection)
        {
            _produtosRepositorio = new ProdutosRepositorio(dbConnection);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _produtosRepositorio.GetByIdProdutos(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _produtosRepositorio.ListarProdutos();
            return Ok(produtos);
        }

        [HttpPost("Incluir")]
        public async Task<IActionResult> IncluirProdutos([FromBody] Produtos produtos)
        {
            var id = await _produtosRepositorio.InserirProdutos(produtos);
            produtos.Id = id;

            return CreatedAtAction(nameof(GetById), new { id = produtos.Id }, produtos);
        }

        [HttpPut("Alterar/{id}")]
        public async Task<IActionResult> AlterarProdutos(int id, [FromBody] Produtos produtos)
        {
            if (id != produtos.Id)
                return BadRequest();

            var result = await _produtosRepositorio.AlterarProdutos(produtos);
            if (!result)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> ExcluirProdutos(int id)
        {
            var result = await _produtosRepositorio.ExcluirProdutos(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
