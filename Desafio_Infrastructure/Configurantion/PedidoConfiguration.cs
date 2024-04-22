using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Infrastructure.Configurantion
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(u => u.DataAtualizacao).HasColumnType("DATE").IsRequired();
            builder.Property(u => u.ClienteId).HasColumnType("INT").IsRequired();
            builder.Property(u => u.LivroId).HasColumnType("INT").IsRequired();
            
            builder.HasOne(p => p.Cliente).WithMany(u => u.Pedidos).HasPrincipalKey(u => u.Id);
            builder.HasOne(p => p.Livro).WithMany(u => u.Pedidos).HasPrincipalKey(u => u.Id);
        }
    }
}