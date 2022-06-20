using VShop.Web.Models;

namespace VShop.Web.Services.Contratos;

public interface IClienteService
{
    Task<IEnumerable<ClienteViewModel>> GetAllClients();
    Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByName();
    Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByValor();
    Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByDesde();
    Task<IEnumerable<ClienteViewModel>> GetAllClientsOrderByTitulo();
    Task<ClienteViewModel> FindClienteByID(int id);
    Task<ClienteViewModel> CreateCliente(ClienteViewModel clienteVM);
    Task<ClienteViewModel> UpdateCliente(ClienteViewModel clienteVM);
    Task<bool> DeleteClienteById(int id);
}
