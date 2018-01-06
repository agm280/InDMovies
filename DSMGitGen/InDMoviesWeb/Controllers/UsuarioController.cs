using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;
using DSMGitGenNHibernate.CEN.DSMGit;

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
            SessionClose();
            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UsuarioModel usu)
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
                SessionClose();
                
                cen.Modify(p_Usuario_OID:id,p_nombre:usu.Nombre,p_apellidos:usu.Apellidos,p_nick:usu.Nick,p_contrasenya:contraseña,p_fecha_nac:usu.Fecha_Nacimiento, p_rol: usu.Rol,p_imagen:usu.Imagen,p_descripcion:usu.Descripcion);
                return RedirectToAction("Index");
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
                SessionClose();

                new UsuarioCEN().Destroy(id);

                return RedirectToAction("Index");
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
