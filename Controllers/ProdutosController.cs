using APIHamburgueria.Context;
using APIHamburgueria.Models;
using APIHamburgueria.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace APIHamburgueria.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(IProdutoRepository repository, ILogger<ProdutosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repository.GetProdutos();

            return Ok(produtos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public ActionResult<Produto> GetId(int id)
        {
            var produto = _repository.GetProduto(id);

            if (produto is null)
            {
                _logger.LogWarning($"Produto com id= {id} não encontrada...");
                return NotFound($"Produto com id= {id} não encontrada...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var produtoCriado = _repository.Create(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _repository.Update(produto);
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _repository.GetProduto(id);

            if (produto is null)
            {
                _logger.LogWarning($"Produto com id={id} não encontrada...");
                return NotFound($"Produto com id={id} não encontrada...");
            }

            var produtoDeletado = _repository.Delete(id);
            return Ok(produtoDeletado);
        }
    }
}


