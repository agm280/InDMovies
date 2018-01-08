using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;
using DSMGitGenNHibernate.CEN.DSMGit;
using System.IO;
using System.Web.Security;

namespace InDMoviesWeb.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            IList<UsuarioEN> usuEN = usuCAD.ReadAllDefault(0, -1);
            IList<UsuarioModel> usuM = UsuarioAssembler.crearListaUsus(usuEN);
            SessionClose();
            return View(usuM);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioEN usuEN = usuCAD.ReadOIDDefault(id);
            UsuarioModel usuM = UsuarioAssembler.crearUsu(usuEN);
            SessionClose();
            return View(usuM);
        }
        // GET: Usuario/Details/5
        public ActionResult DetailsGrupo(string id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            IList<UsuarioEN> l_usurarioEN = usuarioCAD.DameUsuarioPorGrupo(id);
            IEnumerable<UsuarioModel> usuarios = UsuarioAssembler.crearListaUsus(l_usurarioEN).ToList();
            return PartialView("~/Views/Usuario/List.cshtml",usuarios);
        }
        public ActionResult DetailsBusqueda(string id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            IList<UsuarioEN> usuEN = usuCAD.DameUsuarioPorNick(id);
            IEnumerable<UsuarioModel> usuarios = UsuarioAssembler.crearListaUsus(usuEN).ToList();
            SessionClose();

            return PartialView(usuarios);
        }
        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            UsuarioModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
            usu = UsuarioAssembler.crearUsu(usuEN);
            ViewBag.Usu=id;
            SessionClose();
            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UsuarioModel usu, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                UsuarioCEN cen = new UsuarioCEN();
                SessionInitialize();
                UsuarioModel usuM = null;
                UsuarioEN usuEN = new UsuarioCAD(session).ReadOIDDefault(id);
                usuM = UsuarioAssembler.crearUsu(usuEN);
                string contraseña = usuEN.Contrasenya;
                string fileName = usuEN.Imagen;
                SessionClose();

                if (file != null && file.ContentLength > 0)
                {   string path = "";
                    // extract only the fielname
                    fileName =usu.Email+Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    file.SaveAs(path);
                    fileName = "/Images/Uploads/" + fileName;
                }
                

                cen.Modify(p_Usuario_OID:id,p_nombre:usu.Nombre,p_apellidos:usu.Apellidos,p_nick:usu.Nick,p_contrasenya:contraseña,p_fecha_nac:usu.Fecha_Nacimiento, p_rol: usu.Rol,p_imagen:fileName,p_descripcion:usu.Descripcion);
                return RedirectToRoute(new{controller = "Usuario", action = "Details", id = id+'/'});
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
                UsuarioEN usuEN = usuCEN.ReadOID(id);
                UsuarioModel tema = UsuarioAssembler.crearUsu(usuEN);

                TemaCAD temCAD = new TemaCAD(session);
                TemaCEN temCEN = new TemaCEN(temCAD);
                IList<TemaEN> temEN = temCEN.DameTemaPorEmail(id);
                IList<TemaModel> temasU = new TemaAssembler().ConvertListENToModel(temEN);

                VideoCAD videoCAD = new VideoCAD(session);
                VideoCEN videoCEN = new VideoCEN(videoCAD);
                IList<VideoEN> videoEN = videoCEN.DameVideoPorEmail(id);
                IList<VideoModel> videosU = VideoAssembler.convertListENToModel(videoEN);

                NotificacionCAD notiCAD = new NotificacionCAD(session);
                NotificacionCEN notiCEN = new NotificacionCEN(notiCAD);
                IList<NotificacionEN> notiEN = notiCEN.DameNotificacionPorEmail(id);
                IList<NotificacionModel> notisU = NotificacionAssembler.ConvertListENToModel(notiEN);

                SugerenciaCAD sugCAD = new SugerenciaCAD(session);
                SugerenciaCEN sugCEN = new SugerenciaCEN(sugCAD);
                IList<SugerenciaEN> sugEN = sugCEN.DameSugerenciaPorEmail(id);
                IList<SugerenciaModel> sugU = SugerenciaAssembler.convertListENToModel(sugEN);

                RespuestaCAD res2CAD = new RespuestaCAD(session);
                RespuestaCEN res2CEN = new RespuestaCEN(res2CAD);
                IList<RespuestaEN> res2EN = res2CEN.DameRespuestaPorEmail(id);
                IList<RespuestaModel> res2 = RespuestaAssembler.ConvertListENToModel(res2EN);

                SessionClose();

                foreach (RespuestaModel r in res2)
                {
                    new RespuestaCEN().Destroy(r.Id);
                }

                foreach (TemaModel t in temasU)
                {
                    SessionInitialize();
                    RespuestaCAD resCAD = new RespuestaCAD(session);
                    RespuestaCEN resCEN = new RespuestaCEN(resCAD);
                    IList<RespuestaEN> resEN = resCEN.DameRespuestaPorTema(t.Id);
                    IList<RespuestaModel> res = RespuestaAssembler.ConvertListENToModel(resEN);
                    SessionClose();

                    foreach (RespuestaModel r in res)
                    {
                        new RespuestaCEN().Destroy(r.Id);
                    }

                    new TemaCEN().Destroy(t.Id);
                }

                foreach (VideoModel v in videosU)
                {
                    SessionInitialize();
                    ComentarioCAD comCAD = new ComentarioCAD(session);
                    ComentarioCEN comCEN = new ComentarioCEN(comCAD);
                    IList<ComentarioEN> comEN = comCEN.DameComentarioPorVideoID(v.Id);
                    IList<ComentarioModel> cres = ComentarioAssembler.convertListENToModel(comEN);
                    SessionClose();

                    foreach (ComentarioModel c in cres)
                    {
                        new ComentarioCEN().Destroy(c.Id);
                    }

                    new VideoCEN().Destroy(v.Id);
                }

                foreach(SugerenciaModel s in sugU)
                {
                    new SugerenciaCEN().Destroy(s.Id);
                }

                foreach (NotificacionModel n in notisU)
                {
                    new NotificacionCEN().Destroy(n.Id);
                }

                new UsuarioCEN().Destroy(id);

                return RedirectToAction("LogOff2", "Account");
            }
            catch
            {
                return View();
            }
        }

        // POST: Usuario/Delete/5
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
