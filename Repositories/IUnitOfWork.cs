namespace APIHamburgueria.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository ClienteRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        void commit();
    }
}
