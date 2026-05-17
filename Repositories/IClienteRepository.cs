using APIHamburgueria.Models;

namespace APIHamburgueria.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetCliente(int id);
        Cliente Create(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente Delete(int Id);
    }
}
