using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio

    {
        private readonly AppDbContext _context;

        public ClienteRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente()
        {
            return await _context.Clientes.Include(c=> c.Titulo).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteOrderByName()
        {
            return await _context.Clientes.Include(t => t.Titulo).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.Include(c => c.Titulo).Where(t => t.TituloId == id).FirstOrDefaultAsync();
        }
        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Delete(int id)
        {
            var cliente = await GetById(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetClientesTitulos()
        {
            return await _context.Clientes.Include(t => t.Titulo).ToListAsync();
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteOrderByValor()
        {
            return await _context.Clientes.Include(t => t.Titulo).OrderBy(c => c.Valor).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteOrderByDesde()
        {
            return await _context.Clientes.Include(t => t.Titulo).OrderBy(c => c.Desde).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteOrderByTitulo()
        {
            return await _context.Clientes.Include(t => t.Titulo).OrderBy(c => c.Titulo).ToListAsync();
        }
    }
}
