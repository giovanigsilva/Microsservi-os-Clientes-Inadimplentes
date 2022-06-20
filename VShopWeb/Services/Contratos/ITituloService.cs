using VShop.Web.Models;

namespace VShop.Web.Services.Contratos
{
    public interface ITituloService
    {
        Task<IEnumerable<TituloViewModel>> GetAllTitulos();
    }
}
