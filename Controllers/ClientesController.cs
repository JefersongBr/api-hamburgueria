using APIHamburgueria.Context;
using APIHamburgueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Collections;


namespace APIHamburgueria.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _context.Clientes.ToList();

            if(clientes is null)
            {
                return NotFound("Clientes não encontrado...");
            }
            return clientes;
        }

        [HttpGet("{id:int}", Name = "ObterCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if(cliente is null)
            {
                return NotFound("Cliente não encontrado...");
            }
            return cliente;
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if(cliente is null)
            {
                return BadRequest();
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCliente",
                new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Cliente cliente)
        {
            if(id != cliente.Id)
            {
                return BadRequest("Cliente não encontrado...");
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cliente);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c=> c.Id == id);

            if(cliente is null)
            {
                return BadRequest("Cliente não encontrado...");
            }

            _context.Entry(cliente).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok(cliente);
        }



    }
}
