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
    public class ValoracionController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index()
        {
            SessionInitialize();
            ValoracionCAD valoracionCAD = new ValoracionCAD(session);
            IList<ValoracionEN> valoraciones = valoracionCAD.ReadAllDefault(0, -1);
            IList<ValoracionModel> valoracionModels = ValoracionAssembler.convertListENToModel(valoraciones);
            SessionClose();
            return View(valoracionModels);
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult DetailsVideo(int id)
        {
            SessionInitialize();
            ValoracionCAD valoracionCAD = new ValoracionCAD(session);
            IList<ValoracionEN> valoracionEN = valoracionCAD.DameValoracionPorVideoID(id);
            IEnumerable<ValoracionModel> valoraciones = ValoracionAssembler.convertListENToModel(valoracionEN).ToList();
            SessionClose();

            int total=0;
            int suma = 0;
            int media = 0;
            
            foreach (ValoracionModel v in valoraciones) {

                suma = suma + v.Valor;
                total = total +1;

            }
            
            media = suma / total;
            

            ViewBag.Media = media;
            ViewBag.Total = total;

            return PartialView(valoraciones);
        }

        // GET: Valoracion/Create
        public ActionResult Create(int id)
        {
            return PartialView();
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int id)
        {
            try
            {
                // TODO: Add insert logic here
                ValoracionCEN valoracionCEN = new ValoracionCEN();
                string auxS = collection["Valor"];
                int auxI;
                int.TryParse(auxS, out auxI);
                valoracionCEN.New_(p_valor: auxI, p_usuario: User.Identity.GetUserName(), p_video: id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Valoracion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Valoracion/Edit/5
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

        // GET: Valoracion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Valoracion/Delete/5
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
