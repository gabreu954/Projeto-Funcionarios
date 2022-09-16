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

    }
}
