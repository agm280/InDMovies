using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InDMoviesWeb.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            IList<UsuarioEN> usuarios = usuarioCAD.ReadAllDefault(0, -1);
            IList<UsuarioModel> usuarioModels = UsuarioAssembler.ConvertListENToModel(usuarios);
            SessionClose();
            return View(usuarioModels);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioEN usuario = usuarioCAD.ReadOIDDefault(id);
            UsuarioModel usu = UsuarioAssembler.ConvertENToModel(usuario);
            SessionClose();
            return View(usu);
        }
        /*public ActionResult DetailsGrupo(string id)
        {
            SessionInitialize();
            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            IList<UsuarioEN> l_usurarioEN = usuarioCAD.DameUsuarioPorGrupo(id);
            IEnumerable<UsuarioModel> usuarios = UsuarioAssembler.ConvertListENToModel(l_usurarioEN).ToList();
            SessionClose();
            return PartialView("~/Views/Usuario/List.cshtml", usuarios);

        }*/


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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
