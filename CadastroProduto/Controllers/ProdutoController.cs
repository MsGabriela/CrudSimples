using CadastroProduto.DAO.Produto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;
            return View(pDAO.GetProdutos());
            
        }
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Models.Produto p )
        {
            if (ModelState.IsValid)
            {
                ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;

                pDAO.CadastrarProduto(p);

                return RedirectToAction("Index");

            }
            return View(p);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
             ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;

            var p = pDAO.GetProduto(id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }
        [HttpPost]

        public IActionResult Edit(int id, Models.Produto p)
        {
            if (id != p.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;
                
                pDAO.AlterarProduto(id, p);

                return RedirectToAction("Index");
            }
            return View(p);

        }
        public IActionResult Details(int ? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;

            var p = pDAO.GetProduto(id);

            if(p == null)
            {
                return NotFound();
            }
            return View(p);

        }
        public IActionResult Delete(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ProdutoDAO pDAO = HttpContext.RequestServices.GetService(typeof(ProdutoDAO)) as ProdutoDAO;
            pDAO.DeleteProduto(id);

            return RedirectToAction("Index"); 
        }
    }
}
