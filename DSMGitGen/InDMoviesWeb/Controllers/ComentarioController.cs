using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InDMoviesWeb.Controllers
{
    public class ComentarioController : BasicController
    {
        // GET: Comentario
        public ActionResult Index()
        {
            SessionInitialize();
            ComentarioCAD comentarioCAD = new ComentarioCAD(session);
            IList<ComentarioEN> comentarios = comentarioCAD.ReadAllDefault(0, -1);
            IList<ComentarioModel> comentarioModels = ComentarioAssembler.convertListENToModel(comentarios);
            SessionClose();
            return View(comentarioModels);
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ComentarioCEN comentarioCEN = new ComentarioCEN();
                comentarioCEN.New_(p_texto: collection["Texto"], p_usuario: User.Identity.GetUserName(), p_video: 0);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comentario/Edit/5
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

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comentario/Delete/5
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
