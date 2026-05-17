using APIHamburgueria.Context;
using APIHamburgueria.Filters;
using APIHamburgueria.Models;
using APIHamburgueria.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Data.SqlClient.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace APIHamburgueria.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteRepository repository, ILogger<ClientesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _repository.GetClientes();

            return Ok(clientes);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCliente")]
        public ActionResult<Cliente> GetId(int id)
        {
            var cliente = _repository.GetCliente(id);

            if (cliente is null)
            {
                _logger.LogWarning($"Cliente com id= {id} não encontrada...");
                return NotFound($"Cliente com id= {id} não encontrada...");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            var clienteCriado = _repository.Create(cliente);

            return new CreatedAtRouteResult("ObterCliente", new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                _logger.LogWarning($"Dados inválidos...");
                return BadRequest("Dados inválidos");
            }

            _repository.Update(cliente);
            return Ok(cliente);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _repository.GetCliente(id);

            if (cliente is null)
            {
                _logger.LogWarning($"Cliente com id={id} não encontrada...");
                return NotFound($"Cliente com id={id} não encontrada...");
            }

            var clienteDeletado = _repository.Delete(id);
            return Ok(clienteDeletado);

        }
    }
}
