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
            try
            {
                var clientes = _context.Clientes.AsNoTracking().ToList();

                if (clientes is null)
                {
                    return NotFound("Clientes não encontrado...");
                }

                return Ok(clientes);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "ocorrreu um problema ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterCliente")]
        public ActionResult<Cliente> Get(int id)
        {
            try
            {
                var cliente = _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);

                if (cliente is null)
                {
                    return NotFound("Cliente não encontrado...");
                }

                return Ok(cliente);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            try
            {
                if (cliente is null)
                {
                    return BadRequest();
                }

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCliente",
                    new { id = cliente.Id }, cliente);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return BadRequest("Cliente não encontrado...");
                }

                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(cliente);
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
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

                if (cliente is null)
                {
                    return NotFound("Cliente não encontrado...");
                }

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();

                return Ok(cliente);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "ocorrreu um problema ao tratar sua solicitação");
            }
        }
    }
}
