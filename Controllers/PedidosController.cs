using APIHamburgueria.Context;
using APIHamburgueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace APIHamburgueria.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PedidosController : Controller
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosClientesAsync()
        {
            return await _context.Pedidos.AsNoTracking().
                        Include(c => c.Cliente).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetAsync()
        {
            try
            {
                var pedidos = await _context.Pedidos.AsNoTracking().ToListAsync();

                if (pedidos is null)
                {
                    return NotFound("Pedidos não encontrado...");
                }

                return Ok(pedidos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ocorrreu um problema ao tratar sua solicitação");
                
            }

        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPedido")]
        public async Task<ActionResult<Pedido>> GetAsync(int id)
        {
            try
            {
                var pedido = await _context.Pedidos.AsNoTracking().
                    FirstOrDefaultAsync(p => p.Id == id);

                if (pedido is null)
                {
                    return NotFound($"Pedido do cliente id: {id} não encontrado...");
                }

                return Ok(pedido);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");

            }
        }

        [HttpPost]
        public ActionResult Post(Pedido pedido)
        {
            try
            {
                if (pedido is null)
                {
                    return BadRequest();
                }

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterPedido",
                    new { id = pedido.Id }, pedido);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pedido pedido)
        {
            try
            {
                if (id != pedido.Id)
                {
                    return BadRequest("ID da URL diferente do ID do pedido");
                }

                _context.Entry(pedido).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(pedido);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }

            
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            try
            {
                var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);

                if (pedido is null)
                {
                    return NotFound("Pedido nao encontrado...");
                }

                _context.Remove(pedido);
                _context.SaveChanges();

                return Ok(pedido);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }

           
        }

    }
}
