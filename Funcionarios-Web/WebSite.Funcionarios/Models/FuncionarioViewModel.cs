using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Funcionarios.Models
{
    public class FuncionarioViewModel
    {

        [Required(ErrorMessage = "O campo CPF é inválido")]
        public string Cpf { get; set; }


        [Required(ErrorMessage = "O campo Nome é inválido")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }


        [Required(ErrorMessage = "O campo Departamento é obrigatório")]
        public int DepartamentoId { get; set; }


        [Required(ErrorMessage = "O campo Função é obrigatório")]
        public int FuncaoId { get; set; }
    }
}
