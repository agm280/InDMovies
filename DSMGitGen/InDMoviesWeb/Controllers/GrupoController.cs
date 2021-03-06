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
using System.IO;
using DSMGitGenNHibernate.CP.DSMGit;

namespace InDMoviesWeb.Controllers
{
    public class GrupoController : BasicController
    {
        // GET: Grupo
        public ActionResult Index()
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            IList<GrupoEN> gruposEN = grupoCAD.ReadAllDefault(0, -1);
            IList<GrupoModel> grupoModels = GrupoAssembler.convertListToModelUI(gruposEN);
            SessionClose();
            return View(grupoModels);
        }

        // GET: Grupo/Details/5
        public ActionResult Details(string id)
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            GrupoEN grupoEN = grupoCAD.ReadOIDDefault(id);
            GrupoModel g = GrupoAssembler.convertENToModelUI(grupoEN);
            SessionClose();
            return View(g);
        }

        public ActionResult DetailsUsuario(string id)
        {
            SessionInitialize();
            GrupoCAD grupoCAD = new GrupoCAD(session);
            IList<GrupoEN> grupo = grupoCAD.DameGrupoPorUsuario(id);
            IEnumerable<GrupoModel> grupos = GrupoAssembler.convertListToModelUI(grupo).ToList();
            return PartialView(grupos);
        }
        public ActionResult HerramientasGrupo(string idUsu, string idGrup)
        {
            SessionInitialize();
            GrupoEN grupo = new GrupoCEN(new GrupoCAD(session)).ReadOID(idGrup);
            ViewBag.Nombre = grupo.Nombre;
            ViewBag.Iguales = false;
            if (String.Compare(grupo.Lider.Email, idUsu) == 0 || String.Compare("admin@admin.com", idUsu) == 0)
            {
                ViewBag.Iguales = true;
            }
            SessionClose();
            return PartialView();
        }

        public ActionResult ExpulsarMiembro(string id) {
            ViewBag.IdGrupo = id;
            ViewBag.Error = false;
            return View();
        }

        [HttpPost]
        public ActionResult ExpulsarMiembro(string id, FormCollection collection)
        {
            try
            {
                GrupoCEN grupo = new GrupoCEN();
                NotificacionCEN notificacion = new NotificacionCEN();

                GrupoEN grupoEN = grupo.ReadOID(id);
                grupo.SacarUsuario(p_Grupo_OID: id, p_miembros_OIDs: new List<string>() { collection["Usuario"] });

                string descripcion = "Expulsado del grupo" + grupoEN.Nombre;
                if (!string.IsNullOrEmpty(collection["Descripcion"]))
                {
                    descripcion += collection["Descripcion"];
                }
                 
                notificacion.New_(p_descripcion: descripcion, p_usuario: collection["Usuario"]);

                return RedirectToAction("Details", new { id = id });
            }
            catch {
                ViewBag.Error = true;
                return View();
            }
            
        }

        public ActionResult UnirseAGrupo(string id, string idGrup)
        {
            try
            {
                SessionInitialize();
                GrupoCEN grupoCEN = new GrupoCEN();

                GrupoEN grupo = grupoCEN.ReadOID(idGrup);
                bool une = true;
                IList<UsuarioEN> miembros = new UsuarioCEN().DameUsuarioPorGrupo(idGrup);
                foreach (UsuarioEN u in miembros)
                {
                    if (String.Compare(id, u.Email) == 0)
                        une = false;
                }

                if (une)
                {
                    grupoCEN.MeterUsuario(p_Grupo_OID: idGrup, p_miembros_OIDs: new List<string>() { id });
                }
                SessionClose();
                return RedirectToAction("Details", new { id = idGrup });
            }
            catch {
                return RedirectToAction("Details", new { id = idGrup });
            }
           
            
        }


        // GET: Grupo/Create
        public ActionResult Create()
        {
            ViewBag.Error = false;
            return View();
        }

        // POST: Grupo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here

                GrupoCEN gru = new GrupoCEN();
                UsuarioCEN usu = new UsuarioCEN();

                string fileName = "/Images/Uploads/defaultUser.png";

                if (file != null && file.ContentLength > 0)
                {
                    fileName = file.FileName;
                    string path = "";
                    // extract only the fielname
                    fileName = User.Identity.GetUserName() + Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    file.SaveAs(path);
                    fileName = "/Images/Uploads/" + fileName;
                }

                bool acepta = false;
                if (!string.IsNullOrEmpty(collection["AceptaMiembros"]))
                {
                    string[] check = collection["AceptaMiembros"].Split(',');
                    bool checkB = Convert.ToBoolean(check[0]);
                    acepta = checkB;
                }

                string descripcion = "";
                if (!string.IsNullOrEmpty(collection["Descripcion"]))
                {
                    descripcion = collection["Descripcion"];
                }


                IList<string> miembros = new List<string>() { User.Identity.GetUserName() };

                
                String idgru = gru.New_(p_lider: User.Identity.GetUserName(), p_nombre: collection["Nombre"], p_descripcion: descripcion, p_imagen: fileName, p_aceptaMiembros: acepta, p_miembros: miembros);


                miembros = new List<string>();
                if ((!string.IsNullOrEmpty(collection["Miembros"])))
                {
                    string[] l_miembros = collection["Miembros"].Split(';');
                    foreach (string s in l_miembros)
                    {
                        miembros.Add(s);
                    }
                }

                gru.MeterUsuario(p_Grupo_OID: idgru, p_miembros_OIDs: miembros);

                return RedirectToRoute(new
                {
                    controller = "Grupo",
                    action = "Details",
                    id = idgru,
                });
                
            }
            catch
            {
                ViewBag.Error = true;
                return View();
            }
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(string id)
        {
            SessionInitialize();
            GrupoEN grupo = new GrupoCEN(new GrupoCAD(session)).ReadOID(id);
            GrupoModel grupoModel = GrupoAssembler.convertENToModelUI(grupo);
            SessionClose();
            ViewBag.Id = grupo.Nombre;
            return View();
        }

        // POST: Grupo/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
         
                GrupoCEN gru = new GrupoCEN();

                GrupoEN grupoEN = gru.ReadOID(id);

                string fileName = grupoEN.Imagen;
                if (file != null && file.ContentLength > 0)
                {
                    fileName = file.FileName;
                    string path = "";
                    // extract only the fielname
                    fileName = User.Identity.GetUserName() + Path.GetFileName(file.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    //string pathDef = path.Replace(@"\\", @"\");
                    file.SaveAs(path);
                    fileName = "/Images/Uploads/" + fileName;
                }

     

                bool acepta = grupoEN.AceptaMiembros;
                if (!string.IsNullOrEmpty(collection["AceptaMiembros"]))
                {
                    string[] check = collection["AceptaMiembros"].Split(',');
                    bool checkB = Convert.ToBoolean(check[0]);
                    acepta = checkB;
                }

                string descripcion = grupoEN.Descripcion;
                if (!string.IsNullOrEmpty(collection["Descripcion"]))
                {
                    descripcion = collection["Descripcion"];
                }

                gru.Modify(p_Grupo_OID: id, p_descripcion: descripcion, p_imagen: fileName, p_aceptaMiembros: acepta);
       
                return RedirectToRoute(new
                {
                    controller = "Grupo",
                    action = "Details",
                    id = id,
                });

            }
            catch
            {
                return View();
            }
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(string id)
        {
            SessionInitialize();
            GrupoEN grupo = new GrupoCEN(new GrupoCAD(session)).ReadOID(id);
            GrupoModel grupoModel = GrupoAssembler.convertENToModelUI(grupo);
            SessionClose();
            ViewBag.Id = grupo.Nombre;
            return View();
        }

        // POST: Grupo/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GrupoCEN grupoCEN = new GrupoCEN();
                grupoCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetailsBusqueda(string id)
        {
            SessionInitialize();
            GrupoCAD gruCAD = new GrupoCAD(session);
            IList<GrupoEN> gruEN = gruCAD.DameGruposPorNombre(id);
            IEnumerable<GrupoModel> grupos = GrupoAssembler.convertListToModelUI(gruEN).ToList();
            SessionClose();

            return PartialView(grupos);
        }


    }
}
