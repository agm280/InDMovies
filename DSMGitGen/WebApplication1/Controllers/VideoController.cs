using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            return View();
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
