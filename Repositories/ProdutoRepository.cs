using APIHamburgueria.Context;
using APIHamburgueria.Controllers;
using APIHamburgueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHamburgueria.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        readonly private AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        public Produto GetProduto(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public Produto Create(Produto produto)
        {
            if(produto is null)
            {
                throw new ArgumentNullException(nameof(produto));
            }

            _context.Add(produto);
            //_context.SaveChanges();

            return produto;
        }

        public Produto Update(Produto produto)
        {
            if(produto is null)
            {
                throw new ArgumentException(nameof(produto));
            }

            _context.Produtos.Entry(produto).State = EntityState.Modified;
            //_context.SaveChanges();

            return produto;
        }

        public Produto Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(id != produto.Id)
            {
                throw new Exception(nameof(produto));
            }

            _context.Remove(produto);
            //_context.SaveChanges();

            return produto;
        }
    }
}
