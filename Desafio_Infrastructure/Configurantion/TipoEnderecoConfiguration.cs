using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Infrastructure.Configurantion
{
    public class TipoEnderecoConfiguration : IEntityTypeConfiguration<TipoEndereco>
    {
        public void Configure(EntityTypeBuilder<TipoEndereco> builder)
        {
            builder.ToTable("TipoEndereco");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(u => u.Descricao).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataAtualizacao).HasColumnType("DATE").IsRequired();
        }
    }
}