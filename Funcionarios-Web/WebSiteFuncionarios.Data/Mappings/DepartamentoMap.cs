using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Entities.Departamento>
    {
        public void Configure(EntityTypeBuilder<Entities.Departamento> builder)
        {
            builder.ToTable("Departamentos");            

            builder.Property(f => f.Descricao)
                .HasColumnType("varchar(100)");

            builder.HasData(
                    new Entities.Departamento
                    {
                        DepartamentoId = 1,
                        Descricao = "Infraestrutura"
                    },
                    new Entities.Departamento
                    {
                        DepartamentoId = 2,
                        Descricao = "Desenvolvimento"
                    },
                    new Entities.Departamento
                    {
                        DepartamentoId = 3,
                        Descricao = "Segurança"
                    }


                );
        }
    }
}
