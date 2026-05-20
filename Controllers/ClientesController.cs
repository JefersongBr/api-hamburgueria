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
        private readonly IUnitOfWork _uof;

        public ClientesController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _uof.ClienteRepository.GetClientes();

            return Ok(clientes);
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCliente")]
        public ActionResult<Cliente> GetId(int id)
        {
            var cliente = _uof.ClienteRepository.GetCliente(id);

            if (cliente is null)
            {
                return NotFound($"Cliente com id= {id} não encontrada...");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
            {
                return BadRequest("Dados inválidos");
            }

            var clienteCriado = _uof.ClienteRepository.Create(cliente);
            _uof.commit();

            return new CreatedAtRouteResult("ObterCliente", new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("Dados inválidos");
            }

            _uof.ClienteRepository.Update(cliente);
            _uof.commit();
            return Ok(cliente);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _uof.ClienteRepository.GetCliente(id);

            if (cliente is null)
            {
                return NotFound($"Cliente com id={id} não encontrada...");
            }

            var clienteDeletado = _uof.ClienteRepository.Delete(id);
            _uof.commit();
            return Ok(clienteDeletado);

        }
    }
}
