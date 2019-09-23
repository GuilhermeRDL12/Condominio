using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _06_Fiap.Web.AspNet.Models;
using _06_Fiap.Web.AspNet.Persitences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _06_Fiap.Web.AspNet.Controllers
{
    public class ImovelController : Controller
    {

        private BancoContext _context;

        public ImovelController(BancoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar( int IdBusca)
        {
            CarregarSelectCondominio();
            return View(_context.Imoveis
                .Include(i => i.Condominio)
                .Where(i=>i.CondominioId == IdBusca || IdBusca == 0).ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return CarregarSelectCondominio();
        }

        private IActionResult CarregarSelectCondominio()
        {
            var lista = _context.Condominios.ToList();
            ViewBag.condominios = new SelectList(lista, "CondominioId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado";
            return RedirectToAction("Cadastrar");
        }

    }
}