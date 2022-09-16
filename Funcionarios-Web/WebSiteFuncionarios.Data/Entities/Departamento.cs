using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteFuncionarios.Data.Entities
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Descricao { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
