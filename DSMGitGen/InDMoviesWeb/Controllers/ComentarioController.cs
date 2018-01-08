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

        public ActionResult DetailsVideo(int id)
        {
            SessionInitialize();
            ComentarioCAD comentCAD = new ComentarioCAD(session);
            IList<ComentarioEN> comentEN = comentCAD.DameComentarioPorVideoID(id);
            IEnumerable<ComentarioModel> comentarios = ComentarioAssembler.convertListENToModel(comentEN).ToList();
            SessionClose();
            return PartialView(comentarios);
        }

        // GET: Comentario/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                ComentarioCEN comentarioCEN = new ComentarioCEN();

                if (!collection["Texto"].Equals(""))
                {
                    comentarioCEN.New_(p_texto: collection["Texto"], p_usuario: User.Identity.GetUserName(), p_video: id);
                    var ctrl = new NotificacionController();
                    ctrl.CreateNV(id, User.Identity.GetUserName());
                }


                return RedirectToRoute(new
                {
                    controller = "Video",
                    action = "Details",
                    id = id,
                });
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
        {
            ComentarioModel coment = null;
            SessionInitialize();
            ComentarioEN comentarioEN = new ComentarioCAD(session).ReadOIDDefault(id);
            coment = ComentarioAssembler.convertENToModelUI(comentarioEN);
            SessionClose();
            return View();
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ComentarioCEN cen = new ComentarioCEN();

                SessionInitialize();
                ComentarioModel com = null;
                ComentarioEN comEN = new ComentarioCAD(session).ReadOIDDefault(id);
                com = ComentarioAssembler.convertENToModelUI(comEN);


                VideoModel vid = new VideoModel();
                VideoEN vidEN = new VideoCAD(session).ReadOIDDefault(comEN.Video.Id);
                vid = VideoAssembler.convertENToModelUI(vidEN);

                SessionClose();

                if (!collection["Texto"].Equals(""))
                {
                    cen.Modify(p_Comentario_OID: com.Id, p_texto: collection["Texto"]);
                    
                }
                if (true)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Video",
                        action = "Details",
                        id = vid.Id,
                    });

                }


            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                ComentarioCAD comentarioCAD = new ComentarioCAD(session);
                ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioCAD);
                ComentarioEN comentarioEN = comentarioCEN.ReadOID(id);
                ComentarioModel comentario = ComentarioAssembler.convertENToModelUI(comentarioEN);

                VideoModel vid = new VideoModel();
                VideoEN vidEN = new VideoCAD(session).ReadOIDDefault(comentarioEN.Video.Id);
                vid = VideoAssembler.convertENToModelUI(vidEN);

                SessionClose();

                new ComentarioCEN().Destroy(id);



                return RedirectToRoute(new
                {
                    controller = "Video",
                    action = "Details",
                    id = vid.Id,
                });
            }
            catch
            {
                return View();
            }

        }

        // POST: Comentario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                ComentarioCAD comentarioCAD = new ComentarioCAD(session);
                ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioCAD);
                ComentarioEN comentarioEN = comentarioCEN.ReadOID(id);
                ComentarioModel comentario = ComentarioAssembler.convertENToModelUI(comentarioEN);

                VideoModel vid = new VideoModel();
                VideoEN vidEN = new VideoCAD(session).ReadOIDDefault(comentarioEN.Video.Id);
                vid = VideoAssembler.convertENToModelUI(vidEN);

                SessionClose();

                new ComentarioCEN().Destroy(id);



                return RedirectToRoute(new
                {
                    controller = "Video",
                    action = "Details",
                    id = vid.Id,
                });
            }
            catch
            {
                return View();
            }
        }
    }
}
