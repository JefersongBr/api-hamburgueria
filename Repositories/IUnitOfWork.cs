namespace APIHamburgueria.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        IPedidoRepository pedidoRepository { get; }
        IProdutoRepository produtoRepository { get; }

        void commit();
    }
}
