using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;

namespace InDMoviesWeb.Controllers
{
    public class GrupoController : BasicController
    {
        // GET: Grupo
        public ActionResult Index()
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            IList<GrupoEN> gruposEN = grupoCAD.ReadAllDefault(0, -1);
            IList<GrupoModel> grupoModels = GrupoAssembler.convertListToModelUI(gruposEN);
            SessionClose();
            return View(grupoModels);
        }

        // GET: Grupo/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            GrupoEN grupoEN = grupoCAD.ReadOIDDefault(id);
            GrupoModel g = GrupoAssembler.convertENToModelUI(grupoEN);
            SessionClose();
            return View(g);
        }

        public ActionResult DetailsUsuario(string id)
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            IList<GrupoEN> grupo = grupoCAD.DameGruposLideradosPorEmail(id);
            IEnumerable<GrupoModel> grupos = GrupoAssembler.convertListToModelUI(grupo).ToList();
            return PartialView(grupos);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupo/Create
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

        // GET: Grupo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Grupo/Edit/5
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

        // GET: Grupo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Grupo/Delete/5
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
