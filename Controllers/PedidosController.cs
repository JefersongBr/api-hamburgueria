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
        private readonly ILogger<PedidosController> _logger;

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
            return await _context.Pedidos.AsNoTracking().ToListAsync();

        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPedido")]
        public async Task<ActionResult<Pedido>> GetAsync(int id)
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id == id);

            if (pedido == null)
            {
                _logger.LogWarning($"Pedido com id={id} não encontrada...");
                return NotFound($"Pedido com id={id} não encontrada...");
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult Post(Pedido pedido)
        {
            if (pedido is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPedido", new { id = pedido.Id }, pedido);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _context.Entry(pedido).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(pedido);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var pedido = _context.Clientes.FirstOrDefault(p => p.Id == id);

            if (pedido == null)
            {
                _logger.LogWarning($"Pedido com id={id} não encontrada...");
                return NotFound($"Pedido com id={id} não encontrada...");
            }

            _context.Clientes.Remove(pedido);
            _context.SaveChanges();
            return Ok(pedido);
        }
    }
}
