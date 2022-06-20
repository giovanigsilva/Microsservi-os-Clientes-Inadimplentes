using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        /// <summary>
        /// Fluent API sobrescrver as convenções e seguirar minhas definições
        /// </summary>
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Titulos
            mb.Entity<Titulo>().HasKey(t=>t.TituloId);
            mb.Entity<Titulo>().Property(t => t.Name).HasMaxLength(100).IsRequired();
            mb.Entity<Cliente>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            mb.Entity<Cliente>().Property(c => c.Valor).HasPrecision(12, 2).IsRequired();
            mb.Entity<Cliente>().Property(c => c.Desde).IsRequired();

            mb.Entity<Titulo>()
                .HasMany(g => g.Clientes)
                .WithOne(c => c.Titulo)
                .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Titulo>().HasData(

                new Titulo
                {
                    TituloId = 1,
                    Name = "Duplicata",
                },
                new Titulo
                {
                    TituloId = 2,
                    Name = "Boleto",
                }
                );

        }
    }
}
