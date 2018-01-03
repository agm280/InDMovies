using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InDMoviesWeb.Models;

namespace InDMoviesWeb.Controllers
{
    public class SugerenciaAssembler
    {
        public static SugerenciaModel convertENToModelUI(SugerenciaEN sugerenciaEN)
        {
            SugerenciaModel nueva = new SugerenciaModel();

            nueva.Id = sugerenciaEN.Id;
            nueva.Titulo = sugerenciaEN.Titulo;
            nueva.Descripcion = sugerenciaEN.Descripcion;
            nueva.Usuario = sugerenciaEN.Usuario.Nick;

            return nueva;
        }
        public static IList<SugerenciaModel> convertListENToModel(IList<SugerenciaEN> sugerencias)
        {
            IList<SugerenciaModel> sugerenciaModels = new List<SugerenciaModel>();

            foreach (SugerenciaEN v in sugerencias)
            {
                SugerenciaModel sugerenciaM = convertENToModelUI(v);

                sugerenciaModels.Add(sugerenciaM);
            }
            return sugerenciaModels;
        }
    }
}