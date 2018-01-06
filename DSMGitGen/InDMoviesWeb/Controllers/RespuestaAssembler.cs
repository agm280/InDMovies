using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InDMoviesWeb.Models;
using System.Globalization;

namespace InDMoviesWeb.Controllers
{
    public class RespuestaAssembler
    {

        public static RespuestaModel ConvertENToModelUI(RespuestaEN respuestaEN)
        {

            RespuestaModel r = new RespuestaModel();

            r.Id = respuestaEN.Id;
            r.Descripcion = respuestaEN.Descripcion;
            r.Tema = respuestaEN.Tema.Titulo;
            r.Usuario = respuestaEN.Usuario.Nick;
            r.Fecha = respuestaEN.Fecha.Value;

            return r;
        }

        public static IList<RespuestaModel> ConvertListENToModel(IList<RespuestaEN> respuestas)
        {
            IList<RespuestaModel> respuestaModels = new List<RespuestaModel>();

            foreach (RespuestaEN r in respuestas)
            {
                RespuestaModel respuestaM = ConvertENToModelUI(r);

                respuestaModels.Add(respuestaM);
            }
            return respuestaModels;

        }

    }

}