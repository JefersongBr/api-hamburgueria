

using APIHamburgueria.Context;
using APIHamburgueria.Controllers;
using APIHamburgueria.Models;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHamburgueria.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ClientesController> _logger;
        public ClienteRepository(AppDbContext context, ILogger<ClientesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetCliente(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public Cliente Create(Cliente cliente)
        {
            if (cliente is null)
            {
                throw new ArgumentException(nameof(cliente));
            }

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            if (cliente is null)
            {
                throw new ArgumentException(nameof(cliente));
            }

            _context.Clientes.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (id != cliente.Id)
            {
                throw new ArgumentException(nameof(cliente));
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return cliente;
        }
    
    }
}