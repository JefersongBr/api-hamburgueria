using APIHamburgueria.Context;
using APIHamburgueria.Controllers;
using APIHamburgueria.Models;
using Microsoft.EntityFrameworkCore;

namespace APIHamburgueria.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            return _context.Pedidos.AsNoTracking().ToList();
        }

        public Pedido GetPedido(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.Id == id);
        }

        public Pedido Create(Pedido pedido)
        {
            if(pedido is null)
            {
                throw new ArgumentException(nameof(pedido));
            }

            _context.Pedidos.Add(pedido);
            //_context.SaveChanges();

            return pedido;  
        }
        public Pedido Update(Pedido pedido)
        {
            if(pedido is null)
            {
                throw new ArgumentException(nameof(pedido));
            }

            _context.Pedidos.Entry(pedido).State = EntityState.Modified;
            //_context.SaveChanges();

            return pedido;
        }

        public Pedido Delete(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (id != pedido.Id)
            {
                throw new ArgumentException(nameof(pedido));
            }

            _context.Pedidos.Remove(pedido);
            //_context.SaveChanges();

            return pedido;
        }
    }
}
