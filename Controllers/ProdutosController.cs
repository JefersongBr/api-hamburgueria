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
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _uof.ProdutoRepository.GetProdutos();

            return Ok(produtos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public ActionResult<Produto> GetId(int id)
        {
            var produto = _uof.ProdutoRepository.GetProduto(id);

            if (produto is null)
            {
                return NotFound($"Produto com id= {id} não encontrada...");
            }
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
            {               
                return BadRequest("Dados inválidos");
            }

            var produtoCriado = _uof.ProdutoRepository.Create(produto);
            _uof.commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id)
            {            
                return BadRequest("Dados inválidos");
            }

            _uof.ProdutoRepository.Update(produto);
            _uof.commit();
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _uof.ProdutoRepository.GetProduto(id);

            if (produto is null)
            {
                return NotFound($"Produto com id={id} não encontrada...");
            }

            var produtoDeletado = _uof.ProdutoRepository.Delete(id);
            _uof.commit();
            return Ok(produtoDeletado);
        }
    }
}


