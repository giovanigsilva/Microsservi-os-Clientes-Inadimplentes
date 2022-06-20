using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> GetAllCliente();
        Task<IEnumerable<Cliente>> GetAllClienteOrderByName();
        Task<IEnumerable<Cliente>> GetAllClienteOrderByValor();
        Task<IEnumerable<Cliente>> GetAllClienteOrderByDesde();
        Task<IEnumerable<Cliente>> GetAllClienteOrderByTitulo();

        Task<Cliente> GetById(int id);
        Task<Cliente> Create(Cliente cliente);
        Task<Cliente> Update(Cliente cliente);
        Task<Cliente> Delete(int id);
         

    }
}
