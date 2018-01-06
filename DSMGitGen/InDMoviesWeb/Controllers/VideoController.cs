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

        public ActionResult DetailsUsuario(string id)
        {
            SessionInitialize();
            VideoCAD videoCAD = new VideoCAD(session);
            IList<VideoEN> videoEN = videoCAD.DameVideoPorEmail(id);
            IEnumerable<VideoModel> videos = VideoAssembler.convertListENToModel(videoEN).ToList();
            return PartialView(videos);
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
                video.New_(p_titulo: collection["Titulo"], p_descripcion: collection["Descripcion"], p_usuario: User.Identity.GetUserName(), p_fecha_subida: DateTime.Today, p_miniatura: "");

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
            VideoModel vid = null;
            SessionInitialize();
            VideoEN videoEN = new VideoCAD(session).ReadOIDDefault(id);
            vid = VideoAssembler.convertENToModelUI(videoEN);
            SessionClose();

            return View();
        }

        // POST: Video/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                SessionInitialize();
                VideoModel vid = null;
                UsuarioModel usu = null;
                VideoEN videoEN = new VideoCAD(session).ReadOIDDefault(id);
                UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(User.Identity.GetUserName());
                vid = VideoAssembler.convertENToModelUI(videoEN);
                usu = UsuarioAssembler.crearUsu(usuarioEN);
                SessionClose();

                VideoCEN videoCEN = new VideoCEN();

                string tit = collection["Titulo"];
                string desc = collection["Descripcion"];
                string miniature = collection["Miniatura"];

                if (tit == null) tit = vid.Titulo;
                if (desc == null) desc = vid.Descripcion;
                if (miniature == null) miniature = vid.Miniatura;

                

                if (vid.Usuario == usu.Nick)
                {
                    videoCEN.Modify(p_Video_OID: id, p_titulo: tit, p_descripcion: desc, p_fecha_subida: DateTime.Today, p_miniatura: "");
                }
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
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                VideoCAD videoCAD = new VideoCAD(session);
                VideoCEN videoCEN = new VideoCEN(videoCAD);
                VideoEN videoEN = videoCEN.ReadOID(id);
                VideoModel video = VideoAssembler.convertENToModelUI(videoEN);
                SessionClose();

                new VideoCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
