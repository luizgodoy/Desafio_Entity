using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Infrastructure.Configurantion
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.ClienteId).HasColumnType("INT").IsRequired();
            builder.Property(e => e.TipoEnderecoId).HasColumnType("INT").IsRequired();

            builder.Property(e => e.Rua).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Numero).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(e => e.Cidade).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.Estado).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.DataAtualizacao).HasColumnType("DATE").IsRequired();

            builder.HasOne(e => e.Cliente).WithMany(c => c.Enderecos).HasPrincipalKey(c => c.Id);            
        }
    }
}