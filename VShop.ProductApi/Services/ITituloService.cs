using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface ITituloService
{
    Task<IEnumerable<TituloDTO>> GetTitulos();
    Task<IEnumerable<TituloDTO>> GetTitulosClientes();
    Task<TituloDTO> GetTituloByID(int id);
    Task AddTitulo(TituloDTO tituloDto);
    Task RemoveTitulo(int id);
    Task UpdateTitulo(TituloDTO tituloDto);
}
