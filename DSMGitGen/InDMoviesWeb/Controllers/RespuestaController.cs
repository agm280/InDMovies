using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;
using DSMGitGenNHibernate.CEN.DSMGit;
using Microsoft.AspNet.Identity;

namespace InDMoviesWeb.Controllers
{
    public class RespuestaController : BasicController
    {
        // GET: Respuesta
        public ActionResult Index()
        {
            SessionInitialize();
            RespuestaCAD respuestaCAD = new RespuestaCAD(session);
            IList<RespuestaEN> respuestas = respuestaCAD.ReadAllDefault(0, -1);
            IList<RespuestaModel> respuestaModels = RespuestaAssembler.ConvertListENToModel(respuestas);
            SessionClose();
            return View(respuestaModels);
        }

        // GET: Respuesta/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            RespuestaCAD respuestaCAD = new RespuestaCAD(session);
            RespuestaEN respuestas = respuestaCAD.ReadOIDDefault(id);
            RespuestaModel respuestaModel = RespuestaAssembler.ConvertENToModelUI(respuestas);
            SessionClose();
            return View(respuestaModel);
        }

        public ActionResult DetailsTema(int id)
        {
            SessionInitialize();
            RespuestaCAD resCAD = new RespuestaCAD(session);
            IList<RespuestaEN> resEN = resCAD.DameRespuestaPorTema(id);
            IEnumerable<RespuestaModel> respuestas = RespuestaAssembler.ConvertListENToModel(resEN).ToList();
            return PartialView(respuestas);
        }

        // GET: Respuesta/Create
        public ActionResult Create(int id)
        {

            return View();
        }

        // POST: Respuesta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                RespuestaCEN res = new RespuestaCEN();
                DateTime fech = new DateTime();
                fech = System.DateTime.Now;

                res.New_(p_tema: id ,p_usuario: User.Identity.GetUserName(), p_descripcion: collection["Descripcion"],p_fecha: fech);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Respuesta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Respuesta/Edit/5
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

        // GET: Respuesta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Respuesta/Delete/5
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
