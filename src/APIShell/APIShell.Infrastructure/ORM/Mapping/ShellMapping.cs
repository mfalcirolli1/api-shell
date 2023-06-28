using APIShell.Domain.Shell.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIShell.Infrastructure.ORM.Mapping
{
    public class ShellMapping : IEntityTypeConfiguration<ShellModel>
    {
        public void Configure(EntityTypeBuilder<ShellModel> builder)
        {
            builder.ToTable("TB_API_SHELL");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Idade).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
            builder.Property(x => x.DataCadastro);
            builder.Property(x => x.DataAlteracao);
            builder.Property(x => x.Observacao).HasMaxLength(int.MaxValue);
        }
    }
}
