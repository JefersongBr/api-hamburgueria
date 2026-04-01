using APIHamburgueria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace APIHamburgueria.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
    }
}
