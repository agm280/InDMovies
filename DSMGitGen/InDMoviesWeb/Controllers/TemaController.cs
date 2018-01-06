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
    public class TemaController : BasicController
    {
        // GET: Tema
        public ActionResult Index()
        {
            SessionInitialize();
            TemaCAD temaCAD = new TemaCAD(session);
            IList<TemaEN> list_temaEN = temaCAD.ReadAllDefault(0,- 1);
            IEnumerable<TemaModel> temas = new TemaAssembler().ConvertListENToModel(list_temaEN).ToList();
            SessionClose();
            return View(temas);
        }

        // GET: Tema/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult DetailsUsuario(string id)
        {
            SessionInitialize();
            TemaCAD temCAD = new TemaCAD(session);
            IList<TemaEN> temasEN = temCAD.DameTemaPorEmail(id);
            IEnumerable<TemaModel> temas = new TemaAssembler().ConvertListENToModel(temasEN).ToList();
            return PartialView(temas);
        }

        // GET: Tema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tema/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TemaCEN tema = new TemaCEN();
                DateTime fech = new DateTime();
                fech = System.DateTime.Today;
                tema.New_(p_usuario: User.Identity.GetUserName(),p_titulo: System.DateTime.Today.ToString(), p_descripcion: collection["Descripcion"],p_estado:DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.abierto, p_fecha: fech);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tema/Edit/5
        public ActionResult Edit(int id)
        {
            TemaModel tem = null;
            SessionInitialize();
            TemaEN temaEN = new TemaCAD(session).ReadOIDDefault(id);
            tem = TemaAssembler.ConvertENToModelUI(temaEN);
            SessionClose();


            return View();
        }

        // POST: Tema/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TemaCEN cen = new TemaCEN();

                SessionInitialize();
                TemaModel tem = null;
                TemaEN temaEN = new TemaCAD(session).ReadOIDDefault(id);
                tem = TemaAssembler.ConvertENToModelUI(temaEN);
                SessionClose();

                DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum estado;
                if (DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.abierto.ToString()==tem.Estado)
                {
                    estado = DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.abierto; 
                }
                else{
                    estado = DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.cerrado;
                }


                cen.Modify(p_Tema_OID: id,p_titulo: collection["Titulo"], p_descripcion: collection["Descripcion"],p_estado: estado, p_fecha: System.DateTime.Today);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tema/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                SessionInitialize();
                TemaCAD temaCAD = new TemaCAD(session);
                TemaCEN temaCEN = new TemaCEN(temaCAD);
                TemaEN temaEN = temaCEN.ReadOID(id);
                TemaModel tema = TemaAssembler.ConvertENToModelUI(temaEN);
                SessionClose();

                new TemaCEN().Destroy(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Tema/Delete/5
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
