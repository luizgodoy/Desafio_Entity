using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Infrastructure.Configurantion
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnType("DATE");
            builder.Property(u => u.DataAtualizacao).HasColumnType("DATE").IsRequired();
            builder.Property(u => u.CPF).HasColumnType("INT").IsRequired();
        }
    }    
}