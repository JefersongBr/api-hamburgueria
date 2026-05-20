using APIHamburgueria.Context;
using APIHamburgueria.Controllers;


namespace APIHamburgueria.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClienteRepository? _clienteRepo;

        private IPedidoRepository? _pedidoRepo;

        private IProdutoRepository? _produtoRepo;  

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);
            }
        }

        public IPedidoRepository PedidoRepository
        {
            get
            {
                return _pedidoRepo = _pedidoRepo ?? new PedidoRepository(_context);
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }
        public void commit()
        {
            _context.SaveChanges();
        }

        public void Dispose() 
        {
            _context.Dispose();        
        }

    }
}
