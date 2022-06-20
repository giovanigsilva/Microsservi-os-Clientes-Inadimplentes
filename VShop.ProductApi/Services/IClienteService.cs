using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteDTO>> GetClientes(); 
    Task<IEnumerable<ClienteDTO>> GetClientesOrderByName();
    Task<IEnumerable<ClienteDTO>> GetClientesOrderByValor();
    Task<IEnumerable<ClienteDTO>> GetClientesOrderByDesde();
    Task<IEnumerable<ClienteDTO>> GetClientesOrderByTitulo();
    Task<ClienteDTO> GetClienteByID(int id);
    Task AddCliente(ClienteDTO cliente);
    Task RemoveCliente(int id);
    Task UpdateCliente(ClienteDTO cliente);
}
