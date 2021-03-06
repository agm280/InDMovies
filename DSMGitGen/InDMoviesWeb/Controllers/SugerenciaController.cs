﻿using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
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
    public class SugerenciaController : BasicController
    {
        // GET: Sugerencia
        public ActionResult Index()
        {
            SessionInitialize();
            SugerenciaCAD sugerenciaCAD = new SugerenciaCAD(session);
            IList<SugerenciaEN> sugerencias = sugerenciaCAD.ReadAllDefault(0, -1);
            IList<SugerenciaModel> sugerenciaModels = SugerenciaAssembler.convertListENToModel(sugerencias);
            SessionClose();
            return View(sugerenciaModels);
        }

        // GET: Sugerencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sugerencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sugerencia/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SugerenciaCEN sugerencia = new SugerenciaCEN();

                int idsugerencia = sugerencia.New_(p_titulo: collection["Titulo"], p_descripcion: collection["Descripcion"], p_usuario: User.Identity.GetUserName());
                return RedirectToRoute(new { controller = "Sugerencia", action = "Index", id = idsugerencia });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sugerencia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sugerencia/Edit/5
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

        // GET: Sugerencia/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SessionInitialize();
                SugerenciaCAD sugerenciaCAD = new SugerenciaCAD(session);
                SugerenciaCEN sugerenciaCEN = new SugerenciaCEN(sugerenciaCAD);
                SugerenciaEN sugerenciaEN = sugerenciaCEN.ReadOID(id);
                SugerenciaModel sugerencia = SugerenciaAssembler.convertENToModelUI(sugerenciaEN);
                SessionClose();

                new SugerenciaCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Sugerencia/Delete/5
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
