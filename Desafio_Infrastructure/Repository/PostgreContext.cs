using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Desafio_Infrastructure.Repository
{
    public class PostgreContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<TipoContato> TipoContato { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }

        private readonly IConfiguration _configuration;

        public PostgreContext()
        {

        }

        public PostgreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetSection("ConnectionStrings:PostgreConnection").Value);
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreContext).Assembly);

            modelBuilder.Entity<TipoEndereco>().HasData(
                new TipoEndereco { Id = 1, Descricao = "Comercial" },
                new TipoEndereco { Id = 2, Descricao = "Residencial" }                
            );

            modelBuilder.Entity<TipoContato>().HasData(
                new TipoContato { Id = 1, Descricao = "Celular" },
                new TipoContato { Id = 2, Descricao = "Comercial" },
                new TipoContato { Id = 3, Descricao = "E-mail" }
            );
        }
    }
}