using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Entities
{
    public class Funcionario
    {
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Status { get; set; }
        public int Dependentes { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }


        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
    }
}
