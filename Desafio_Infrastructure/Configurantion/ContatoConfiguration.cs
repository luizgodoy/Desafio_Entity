using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Infrastructure.Configurantion
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("INT").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(e => e.ClienteId).HasColumnType("INT").IsRequired();
            builder.Property(e => e.TipoContatoId).HasColumnType("INT").IsRequired();
            builder.Property(e => e.Descricao).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(e => e.DataAtualizacao).HasColumnType("DATE").IsRequired();

            builder.HasOne(e => e.Cliente).WithMany(c => c.Contatos).HasPrincipalKey(c => c.Id);
        }
    }
}
