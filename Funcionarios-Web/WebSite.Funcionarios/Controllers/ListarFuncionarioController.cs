using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Funcionarios.Models;
using WebSiteFuncionarios.Data.Context;

namespace WebSite.Funcionarios.Controllers
{
    public class ListarFuncionarioController : Controller
    {
        private readonly ILogger<ListarFuncionarioController> _logger;

        private readonly Connections.ConsultasEntity _consultas;

        public ListarFuncionarioController(ILogger<ListarFuncionarioController> logger, FuncionarioContext dbContext)
        {
            _consultas = new Connections.ConsultasEntity(dbContext);
            _logger = logger;
        }
        public IActionResult Index()
        {

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            return View();
        }

        [HttpPost]
        public ActionResult Buscar(BuscaViewModel model)
        {

            var registros = _consultas.SelectFuncionarios(model);

            if (model.Status != "Desligado" && String.IsNullOrEmpty(model.Status))
            {
                ViewData["Registros"] = registros.FindAll(f => f.Status != "Desligado");
            }
            else if(model.Status == "Ativo")
            {
                ViewData["Registros"] = registros.FindAll(f => f.Status == "Ativo");
            }
            else if(model.Status == "Ausente")
            {
                ViewData["Registros"] = registros.FindAll(f => f.Status == "Ausente");
            }
            else
            {
                ViewData["Registros"] = registros.FindAll(f => f.Status == "Desligado");
            }
            

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            return View("Index");
        }

        public ActionResult Alterar(string cpf, string nome, int idade, string status,int dependentes, int departamentoId, int funcaoId)
        {
            ViewData["Funcoes"] = _consultas.SelectFuncoes();

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            FuncionarioViewModel model = new FuncionarioViewModel
            {
                Cpf = cpf,
                Nome = nome,
                Idade = idade,
                Status = status,
                Dependentes = dependentes,
                DepartamentoId = departamentoId,
                FuncaoId = funcaoId
            };

            return View("Alterar", model);
        }

        public ActionResult AtualizarBanco(FuncionarioViewModel model)
        {

            try
            {
                _consultas.UpdateFuncionario(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocorreu um erro: {ex.Message}";

                return View("Index");
            }

            TempData["Success"] = "Funcionário atualizado com Sucesso";

            return RedirectToAction("Index");

        }

        public ActionResult Excluir(string cpf)
        {

            try
            {
                _consultas.DeletarFuncionario(cpf);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocorreu um erro: {ex.Message}";

                return View("Index");
            }

            TempData["Success"] = "Funcionário deletado com Sucesso";

            return RedirectToAction("Index");
        }

    }
}
