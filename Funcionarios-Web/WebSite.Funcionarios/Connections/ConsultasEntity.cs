using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Funcionarios.Models;
using WebSiteFuncionarios.Data.Context;
using WebSiteFuncionarios.Data.Entities;

namespace WebSite.Funcionarios.Connections
{
    public class ConsultasEntity
    {
        private readonly FuncionarioContext _dbContext;

        public ConsultasEntity(FuncionarioContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<FuncaoViewModel> SelectFuncoes()
        {

            List<FuncaoViewModel> retorno = new List<FuncaoViewModel>();

            var funcoes = _dbContext.Funcoes.ToList();

            foreach (var item in funcoes)
            {
                retorno.Add(new FuncaoViewModel
                {
                    FuncaoId = item.FuncaoId,
                    Descricao = item.Descricao

                });
            }

            return retorno;
        }

        public List<DepartamentoViewModel> SelectDepartamentos()
        {

            List<DepartamentoViewModel> retorno = new List<DepartamentoViewModel>();

            var departamentos = _dbContext.Departamentos.ToList();

            foreach (var item in departamentos)
            {
                retorno.Add(new DepartamentoViewModel
                {
                    DepartamentoId = item.DepartamentoId,
                    Descricao = item.Descricao

                });
            }

            return retorno;
        }

        public void InsertFuncionario(FuncionarioViewModel funcionario)
        {
            _dbContext.Funcionarios.Add(new Funcionario { Cpf = funcionario.Cpf, Nome = funcionario.Nome, Idade = funcionario.Idade, Status = funcionario.Status, Dependentes = funcionario.Dependentes, DepartamentoId = funcionario.DepartamentoId, FuncaoId = funcionario.FuncaoId });

            _dbContext.SaveChanges();
        }

        public List<FuncionarioViewModel> SelectFuncionarios(BuscaViewModel model)
        {
            List<FuncionarioViewModel> retorno = new List<FuncionarioViewModel>();
            List<Funcionario> retornoquery;

            if (model.Nome != null && model.DepartamentoId != 0)
            {
                retornoquery = _dbContext.Funcionarios.Where(f => f.DepartamentoId == model.DepartamentoId && f.Nome.Contains(model.Nome)).ToList();
            }

            else if (model.Nome != null)
            {
                retornoquery = _dbContext.Funcionarios.Where(f => f.Nome.Contains(model.Nome)).ToList();
            }
            else if (model.DepartamentoId != 0)
            {
                retornoquery = _dbContext.Funcionarios.Where(f => f.DepartamentoId == model.DepartamentoId).ToList();
            }
            else
            {
                retornoquery = _dbContext.Funcionarios.ToList();
            }

            foreach (var item in retornoquery)
            {

                double salario = 0;

                item.Funcao = _dbContext.Funcoes.Where(func => func.FuncaoId == item.FuncaoId).ToList()[0];

                if (item.Dependentes == 0)
                {
                    salario = item.Funcao.Salario;
                }
                if (item.Dependentes == 1)
                {
                    salario = item.Funcao.Salario * 0.98;
                }
                if (item.Dependentes == 2)
                {
                    salario = item.Funcao.Salario * 0.97;
                }
                if (item.Dependentes == 3)
                {
                    salario = item.Funcao.Salario * 0.95;
                }

                retorno.Add(new FuncionarioViewModel
                {
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    Idade = item.Idade,
                    Status = item.Status,
                    Dependentes = item.Dependentes,
                    DepartamentoId = item.DepartamentoId,
                    FuncaoId = item.FuncaoId,
                    Salario = salario
                });
            }

            return retorno;

        }

        public void UpdateFuncionario(FuncionarioViewModel model)
        {
            _dbContext.Funcionarios.Update(new Funcionario
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                Idade = model.Idade,
                Status = model.Status,
                Dependentes = model.Dependentes,
                DepartamentoId = model.DepartamentoId,
                FuncaoId = model.FuncaoId
            });

            _dbContext.SaveChanges();
        }

        public void DeletarFuncionario(string cpf)
        {
            _dbContext.Funcionarios.Remove(new Funcionario { Cpf = cpf });
            _dbContext.SaveChanges();
        }

    }
}
