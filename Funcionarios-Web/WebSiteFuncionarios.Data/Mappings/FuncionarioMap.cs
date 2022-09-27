using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Entities.Funcionario>
    {
        public void Configure(EntityTypeBuilder<Entities.Funcionario> builder)
        {
            builder.ToTable("Funcionarios");

            builder.HasKey(f => f.Cpf);

            builder.Property(f => f.Nome)
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Cpf)
                .HasColumnType("varchar(11)");

            builder.Property(f => f.Status)
                .HasColumnType("varchar(100)");




        }
    }
}
