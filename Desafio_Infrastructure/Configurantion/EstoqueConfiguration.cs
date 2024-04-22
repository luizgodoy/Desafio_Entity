using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Infrastructure.Configurantion
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(e => e.DataAtualizacao).HasColumnType("DATE").IsRequired();
            builder.Property(e => e.Quantidade).HasColumnType("INT").IsRequired();
            builder.Property(e => e.LivroId).HasColumnType("INT").IsRequired();
        }
    }
}