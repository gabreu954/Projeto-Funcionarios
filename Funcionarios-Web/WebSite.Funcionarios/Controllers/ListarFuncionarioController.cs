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

            ViewData["Registros"] = _consultas.SelectFuncionarios(model);

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            return View("Index");
        }

        public ActionResult Alterar(string cpf, string nome, int idade, int departamentoId, int funcaoId)
        {
            ViewData["Funcoes"] = _consultas.SelectFuncoes();

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            FuncionarioViewModel model = new FuncionarioViewModel
            {
                Cpf = cpf,
                Nome = nome,
                Idade = idade,
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

            return View("Index");

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
