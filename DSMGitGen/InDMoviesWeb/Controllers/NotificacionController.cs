using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InDMoviesWeb.Controllers
{
    public class NotificacionController : BasicController
    {
        // GET: Notificacion
        public ActionResult Index(string id)
        {
            SessionInitialize();
            NotificacionCAD cad = new NotificacionCAD(session);
            IList<NotificacionEN> notifsEN = cad.DameNotificacionPorEmail(id);
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
        public void CreateNT(int tema, string usuario)
        {
                SessionInitialize();
                TemaCAD temCAD = new TemaCAD(session);
                TemaEN temaa = temCAD.ReadOIDDefault(tema);
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioEN usuEN = usuCAD.ReadOIDDefault(usuario);

                string receptor = temaa.Usuario.Email;
                string nombret = temaa.Titulo;
                string nombreu = usuEN.Nick;

                NotificacionCEN noti = new NotificacionCEN();
                noti.New_(nombreu + " te ha respondido al tema " + nombret + " .", receptor);
        }

        public void CreateNV(int video, string usuario)
        {
            SessionInitialize();
            VideoCAD videoCAD = new VideoCAD(session);
            VideoEN videoEN = videoCAD.ReadOIDDefault(video);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioEN usuEN = usuCAD.ReadOIDDefault(usuario);

            string receptor = videoEN.Usuario.Email;
            string nombrev = videoEN.Titulo;
            string nombreu = usuEN.Nick;
            NotificacionCEN noti = new NotificacionCEN();
            noti.New_(nombreu + " ha comentado tu video " + nombrev + " .", receptor);
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
        public ActionResult Delete(int id, string usu)
        {
            SessionInitialize();
            NotificacionCAD notiCAD = new NotificacionCAD(session);
            NotificacionCEN notiCEN = new NotificacionCEN(notiCAD);
            NotificacionEN notiEN = notiCEN.ReadOID(id);
            NotificacionModel noti = NotificacionAssembler.ConvertENToModelUI(notiEN);
            SessionClose();

            new NotificacionCEN().Destroy(id);

            return RedirectToRoute(new { controller = "Usuario", action = "Details", id = usu + '/' });
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
