using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult DetailsBusqueda(string id)
        {
            SessionInitialize();
            VideoCAD videoCAD = new VideoCAD(session);
            IList<VideoEN> videoEN = videoCAD.DameVideoPorTitulo(id);
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
        public ActionResult Create(VideoModel vid, HttpPostedFileBase file)
        {
            string fileName = "", path = "";

            if (file != null && file.ContentLength > 0)
            {

                fileName = Path.GetFileName(file.FileName);

                path = Path.Combine(Server.MapPath("~/Images/Uploads/Miniaturas"), fileName);

                file.SaveAs(path);
            }
            else {
                fileName = "defaultUser.png";
            }

            try
            {
                fileName = "/Images/Uploads/Miniaturas/" + fileName;
                VideoCEN videoCEN = new VideoCEN();
                videoCEN.New_(p_titulo: vid.Titulo, p_descripcion: vid.Descripcion, p_usuario: User.Identity.GetUserName(), p_fecha_subida: DateTime.Today, p_miniatura: fileName, p_url: vid.Url);

                return RedirectToAction("Index");
            }
            catch {

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

            return View(vid);
        }

        // POST: Video/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VideoModel vid, HttpPostedFileBase file)
        {
            try
            {
                
                SessionInitialize();
                VideoModel vidM = null;
                UsuarioModel usu = null;
                VideoEN videoEN = new VideoCAD(session).ReadOIDDefault(id);
                UsuarioEN usuarioEN = new UsuarioCAD(session).ReadOIDDefault(User.Identity.GetUserName());
                vidM = VideoAssembler.convertENToModelUI(videoEN);
                usu = UsuarioAssembler.crearUsu(usuarioEN);
                SessionClose();

                VideoCEN videoCEN = new VideoCEN();

                string fileName = "", path = "";

                if (file != null && file.ContentLength > 0)
                {

                    fileName = Path.GetFileName(file.FileName);

                    path = Path.Combine(Server.MapPath("~/Images/Uploads/Miniaturas"), fileName);

                    file.SaveAs(path);
                }
                else
                {
                    fileName = "defaultUser.png";
                }

                string tit = vid.Titulo;
                string desc = vid.Descripcion;
                string enlace = vid.Url;

                if (tit == null) tit = vidM.Titulo;
                if (desc == null) desc = vidM.Descripcion;
                if (desc == null) desc = vidM.Url;


                if (vidM.Usuario == usu.Nick)
                {
                    fileName = "/Images/Uploads/Miniaturas/" + fileName;
                    videoCEN.Modify(p_Video_OID: id, p_titulo: tit, p_descripcion: desc, p_fecha_subida: DateTime.Today, p_miniatura: fileName, p_url: enlace);
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
                ValoracionCAD valCAD = new ValoracionCAD(session);
                ValoracionCEN valCEN = new ValoracionCEN(valCAD);
                IList<ValoracionEN> valEN = valCEN.DameValoracionPorVideoID(id);
                IList<ValoracionModel> vals = ValoracionAssembler.convertListENToModel(valEN);
                SessionClose();

                foreach (ValoracionModel vl in vals)
                {
                    new ValoracionCEN().Destroy(vl.Id);
                }

                SessionInitialize();
                ComentarioCAD comCAD = new ComentarioCAD(session);
                ComentarioCEN comCEN = new ComentarioCEN(comCAD);
                IList<ComentarioEN> comEN = comCEN.DameComentarioPorVideoID(id);
                IList<ComentarioModel> cres = ComentarioAssembler.convertListENToModel(comEN);
                SessionClose();

                foreach (ComentarioModel c in cres)
                {
                    new ComentarioCEN().Destroy(c.Id);
                }

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
