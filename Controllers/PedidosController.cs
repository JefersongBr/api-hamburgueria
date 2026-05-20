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
        private readonly IUnitOfWork _uof;

        public PedidosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            var pedidos = _uof.PedidoRepository.GetPedidos();

            return Ok(pedidos);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterPedido")]
        public ActionResult<Pedido> GetId(int id)
        {
            var pedido = _uof.PedidoRepository.GetPedido(id);

            if (pedido is null)
            {
                return NotFound($"Pedido com id= {id} não encontrada...");
            }
            return Ok(pedido);
        }

        [HttpPost]
        public ActionResult Post(Pedido pedido)
        {
            if (pedido is null)
            {
                return BadRequest("Dados inválidos");
            }

            var pedidoCriado = _uof.PedidoRepository.Create(pedido);
            _uof.commit();

            return new CreatedAtRouteResult("ObterPedido", new { id = pedidoCriado.Id }, pedidoCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest("Dados inválidos");
            }

            _uof.PedidoRepository.Update(pedido);
            _uof.commit();
            return Ok(pedido);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var pedido = _uof.PedidoRepository.GetPedido(id);

            if (pedido is null)
            {
                return NotFound($"Pedido com id={id} não encontrada...");
            }

            var pedidoDeletado = _uof.PedidoRepository.Delete(id);
            _uof.commit();
            return Ok(pedidoDeletado);

        }
    }
}
