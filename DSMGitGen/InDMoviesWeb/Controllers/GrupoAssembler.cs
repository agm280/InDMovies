using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InDMoviesWeb.Models;

namespace InDMoviesWeb.Controllers
{
    public class GrupoAssembler
    {

        public static GrupoModel convertENToModelUI(GrupoEN grupoEN) {

            GrupoModel g = new GrupoModel();

            g.Nombre = grupoEN.Nombre;
            g.Imagen = grupoEN.Imagen;
            g.Descripcion = grupoEN.Descripcion;
            g.Lider = grupoEN.Lider.Nick;
            g.AceptaMiembros = grupoEN.AceptaMiembros;

            return g;
        }

        public static IList<GrupoModel> convertListToModelUI(IList<GrupoEN> grupos) {
            IList<GrupoModel> g = new List<GrupoModel>();
            foreach (GrupoEN gEN in grupos)
                g.Add(convertENToModelUI(gEN));
            return g;
        }
    }
}