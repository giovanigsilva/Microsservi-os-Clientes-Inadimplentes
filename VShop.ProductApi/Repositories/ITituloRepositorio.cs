using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface ITituloRepositorio
    {
        Task<IEnumerable<Titulo>> GetAll();
        Task<IEnumerable<Titulo>> GetTitulosClientes();

        Task<Titulo> GetById(int id);
        Task<Titulo> Create(Titulo titulo);
        Task<Titulo> Update(Titulo titulo);
        Task<Titulo> Delete(int id);
    }
}
