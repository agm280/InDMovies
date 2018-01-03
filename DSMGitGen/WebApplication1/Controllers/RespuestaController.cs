using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;
using WebApplication1.Controllers;

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

        // GET: Respuesta/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Respuesta/Create
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
