using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class TituloRepositorio : ITituloRepositorio
    {
        private readonly AppDbContext _context;

        public TituloRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Titulo>> GetAll()
        {
            return await _context.Titulos.ToListAsync();
        }
        public async Task<Titulo> GetById(int id)
        {
            return await _context.Titulos.Where( c=>c.TituloId == id).FirstOrDefaultAsync();
        }
        public async Task<Titulo> Create(Titulo titulo)
        {
            _context.Titulos.Add(titulo);
            await _context.SaveChangesAsync();
            return titulo;
        }

        public async Task<Titulo> Delete(int id)
        {
            var titulo = await GetById(id);
            _context.Titulos.Remove(titulo);
            await _context.SaveChangesAsync();
            return titulo;
        }

        public async Task<IEnumerable<Titulo>> GetTitulosClientes()
        {
            return await _context.Titulos.Include(c => c.Clientes).ToListAsync();
        }

        public async Task<Titulo> Update(Titulo titulo)
        {
            _context.Entry(titulo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return titulo;
        }
    }
}
