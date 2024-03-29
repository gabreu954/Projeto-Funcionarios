﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Entities.Funcao>
    {
        public void Configure(EntityTypeBuilder<Entities.Funcao> builder)
        {
            builder.ToTable("Funcoes");

            builder.Property(f => f.Descricao)
                .HasColumnType("varchar(100)");

            builder.HasData(
                    new Entities.Funcao
                    {
                        FuncaoId = 1,
                        Descricao = "Técnico de TI",
                        Salario = 1200.00
                    },
                    new Entities.Funcao
                    {
                        FuncaoId = 2,
                        Descricao = "Técnico de Segurança",
                        Salario = 3000.00
                    },
                    new Entities.Funcao
                    {
                        FuncaoId = 3,
                        Descricao = "Desenvolvedor",
                        Salario = 2200.00
                    },
                    new Entities.Funcao
                    {
                        FuncaoId = 4,
                        Descricao = "Analista de Dados",
                        Salario = 2200.00
                    },
                    new Entities.Funcao
                    {
                        FuncaoId = 5,
                        Descricao = "QA Tester",
                        Salario = 2200.00
                    }
                );
        }
    }
}
