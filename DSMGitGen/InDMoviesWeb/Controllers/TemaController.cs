using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InDMoviesWeb.Controllers
{
    public class TemaController : BasicController
    {
        // GET: Tema
        public ActionResult Index()
        {
            SessionInitialize();
            TemaCAD temaCAD = new TemaCAD(session);
            IList<TemaEN> list_temaEN = temaCAD.ReadAllDefault(0,- 1);
            IEnumerable<TemaModel> temas = new TemaAssembler().ConvertListENToModel(list_temaEN).ToList();
            SessionClose();
            return View(temas);
        }

        // GET: Tema/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            TemaCAD temaCAD = new TemaCAD(session);
            TemaEN temaEN = temaCAD.ReadOIDDefault(id);
            TemaModel tema = TemaAssembler.ConvertENToModelUI(temaEN);
            SessionClose();

            return View(tema);
        }

        // GET: Tema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tema/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tema/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tema/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tema/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tema/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
