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
    public class FuncionarioController : Controller
    {
        private readonly ILogger<FuncionarioController> _logger;

        private readonly Connections.ConsultasEntity _consultas;

        public FuncionarioController(ILogger<FuncionarioController> logger, FuncionarioContext dbContext)
        {
            _consultas = new Connections.ConsultasEntity(dbContext);
            _logger = logger;
        }
        public IActionResult Index()
        {

            ViewData["Funcoes"] = _consultas.SelectFuncoes();

            ViewData["Departamentos"] = _consultas.SelectDepartamentos();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(FuncionarioViewModel model)
        {
            try
            {
                _consultas.InsertFuncionario(model);
            }
            catch(Exception ex)
            {
                TempData["Error"] = $"Ocorreu um erro: {ex.Message}";

                return View("Index");
            }

            TempData["Success"] = "Funcionário cadastrado com Sucesso";

            return RedirectToAction("Index");
        }
    }
}
