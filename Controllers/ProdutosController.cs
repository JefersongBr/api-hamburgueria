using APIHamburgueria.Context;
using APIHamburgueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHamburgueria.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();

                if(produtos is null)
                {
                    return NotFound("Produtos não encontrado...");
                }

                return Ok(produtos);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ocorreu um erro ao tratar sua solicitação");
            }
        }

    }
}
