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
        [RegularExpression("^[0-9]*$", ErrorMessage = "Só é permitido números!")]
        [Required(ErrorMessage = "O campo CPF é inválido")]
        public string Cpf { get; set; }

        [RegularExpression("^[a-zA-Z-\u0000-\u0080 ]*$", ErrorMessage ="Só é permitido letras!")]
        [Required(ErrorMessage = "O campo Nome é inválido")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O campo Departamento é obrigatório")]
        public int DepartamentoId { get; set; }


        [Required(ErrorMessage = "O campo Função é obrigatório")]
        public int FuncaoId { get; set; }

        [Required(ErrorMessage = "O campo Dependentes é obrigatório")]
        public int Dependentes { get; set; }
        public double Salario { get; set; }
    }
}
