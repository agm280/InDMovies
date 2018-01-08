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
    public class BusquedaController : BasicController
    {
        // GET: Busqueda
        public ActionResult Index()
        {
            SessionInitialize();
            BusquedaCAD busquedaCAD = new BusquedaCAD(session);
            IList<BusquedaEN> list_busquedaEN = busquedaCAD.ReadAllDefault(0, -1);
            IEnumerable<BusquedaModel> busquedas = new BusquedaAssembler().ConvertListENToModel(list_busquedaEN).ToList();
            SessionClose();
            return View(busquedas);
        }

        // GET: Busqueda/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            BusquedaCAD busquedaCAD = new BusquedaCAD(session);
            BusquedaEN busquedaEN = busquedaCAD.ReadOIDDefault(id);
            BusquedaModel busquedaModel = BusquedaAssembler.ConvertENToModelUI(busquedaEN);
            SessionClose();
            return View(busquedaModel);
        }

        // GET: Busqueda/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Busqueda/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BusquedaCEN bus = new BusquedaCEN();


                int idbus = bus.New_(p_Texto: collection["Texto"]);
                return RedirectToRoute(new
                {
                    controller = "Busqueda",
                    action = "Details",
                    id = idbus,
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Busqueda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Busqueda/Edit/5
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

        // GET: Busqueda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Busqueda/Delete/5
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
