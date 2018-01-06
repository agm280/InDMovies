﻿using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InDMoviesWeb.Models;

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
            return View();
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