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
    public class NotificacionController : BasicController
    {
        // GET: Notificacion
        public ActionResult Index()
        {
            SessionInitialize();
            NotificacionCAD cad = new NotificacionCAD(session);
            IList<NotificacionEN> notifsEN = cad.DameNotificacionPorEmail(User.Identity.Name);
            IList<NotificacionModel> notifs = NotificacionAssembler.ConvertListENToModel(notifsEN);
            SessionClose();
            return View(notifs);
        }

        // GET: Notificacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notificacion/Create
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

        // GET: Notificacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Notificacion/Edit/5
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

        // GET: Notificacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notificacion/Delete/5
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
