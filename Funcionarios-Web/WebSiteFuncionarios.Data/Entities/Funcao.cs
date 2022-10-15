using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Entities
{
    public class Funcao
    {
        public int FuncaoId { get; set; }
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double Salario { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
