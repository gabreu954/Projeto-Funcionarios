using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSiteFuncionarios.Data.Mappings;

namespace WebSiteFuncionarios.Data.Context
{
    public class FuncionarioContext : DbContext
    {        
        public DbSet<Entities.Funcao> Funcoes { get; set; }
        public DbSet<Entities.Departamento> Departamentos { get; set; }
        public DbSet<Entities.Funcionario> Funcionarios { get; set; }

        public string DbPath { get; }

        public FuncionarioContext()
        {
            string basePath = Environment.CurrentDirectory;
            string relativePath = "./Data/funcionario.db";
            DbPath = Path.GetFullPath(relativePath, basePath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new FuncaoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
                           
        
    }
}
