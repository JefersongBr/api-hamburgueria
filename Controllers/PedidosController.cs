using APIHamburgueria.Context;
using APIHamburgueria.Models;
using APIHamburgueria.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace APIHamburgueria.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _repository;
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(IPedidoRepository repository, ILogger<PedidosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            var pedidos = _repository.GetPedidos();

            return Ok(pedidos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPedido")]
        public ActionResult<Pedido> GetId(int id)
        {
            var pedido = _repository.GetPedido(id);

            if (pedido is null)
            {
                _logger.LogWarning($"Pedido com id= {id} não encontrada...");
                return NotFound($"Pedido com id= {id} não encontrada...");
            }
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

            var pedidoCriado = _repository.Create(pedido);

            return new CreatedAtRouteResult("ObterPedido", new { id = pedidoCriado.Id }, pedidoCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _repository.Update(pedido);
            return Ok(pedido);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var pedido = _repository.GetPedido(id);

            if (pedido is null)
            {
                _logger.LogWarning($"Pedido com id={id} não encontrada...");
                return NotFound($"Pedido com id={id} não encontrada...");
            }

            var pedidoDeletado = _repository.Delete(id);
            return Ok(pedidoDeletado);

        }
    }
}
