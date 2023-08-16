using projectLivro.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace projectLivro.Controllers
{
    public class LivrosController : Controller
    {
        modelDB db = new modelDB();
        LivrosDAO objDAO = new LivrosDAO();
        List<modelLivro> objLivros = new List<modelLivro>();
        public ActionResult SelectLivros()
        {
            objLivros = objDAO.SelectList();
            return View(objLivros);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(modelLivro livro)
        {
            if (ModelState.IsValid)
            {
                objDAO.Insert(livro);
                return RedirectToAction("SelectLivros");
            }
            return View(livro);
        }
        public ActionResult Details(int id)
        {
            var livro = objDAO.SelectLivro(id);
            return View(livro);
        }
        public ActionResult Edit(int id)
        {
            var objLivro = objDAO.SelectLivro(id);
            return View(objLivro);
        }
        [HttpPost]
        public ActionResult Edit(modelLivro livro, int id)
        {
            if (ModelState.IsValid)
            {
                objDAO.Update(livro, id);
                return RedirectToAction("SelectLivros");
            }
            return View(livro);
        }
        public ActionResult Delete(int Id)
        {
            var objLivro = objDAO.SelectLivro(Id);
            return View(objLivro);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmeDelete(int Id)
        {
            objDAO.Delete(Id);
            return RedirectToAction("SelectLivros");
        }
    }
}