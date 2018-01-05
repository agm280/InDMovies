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
    public class VideoController : BasicController
    {
        // GET: Video
        public ActionResult Index()
        {
            SessionInitialize();
            VideoCAD videoCAD = new VideoCAD(session);
            IList<VideoEN> videos = videoCAD.ReadAllDefault(0, -1);
            IList<VideoModel> videoModels = VideoAssembler.convertListENToModel(videos);
            SessionClose();
            return View(videoModels);
        }

        // GET: Video/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            VideoCAD videoCAD = new VideoCAD(session);
            VideoEN videoEN = videoCAD.ReadOIDDefault(id);
            VideoModel videoModel = VideoAssembler.convertENToModelUI(videoEN);
            SessionClose();
            return View(videoModel);
        }

        // GET: Video/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Video/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                VideoCEN video = new VideoCEN();
                video.New_(p_titulo: collection["Titulo"], p_descripcion: collection["Descripcion"], p_usuario: User.Identity.GetUserName(), p_fecha_subida: new DateTime(1992, 2, 4), p_miniatura: "");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Video/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Video/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                VideoCEN videoCEN = new VideoCEN();
                videoCEN.Modify(id, collection["Titulo"], collection["Descripcion"], null, collection["Miniatura"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Video/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Video/Delete/5
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
