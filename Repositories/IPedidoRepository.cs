using APIHamburgueria.Models;

namespace APIHamburgueria.Repositories
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> GetPedidos();
        Pedido GetPedido(int id);
        Pedido Create(Pedido pedido);
        Pedido Update(Pedido pedido);
        Pedido Delete(int id);
    }
}
