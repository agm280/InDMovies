using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class ValoracionAssembler
    {
        public static ValoracionModel convertENToModelUI(ValoracionEN valoracionEN)
        {

            ValoracionModel v = new ValoracionModel();

            v.Id = valoracionEN.Id;
            v.Valor = valoracionEN.Valor;
            v.Usuario = valoracionEN.Usuario.Nick;
            v.Video = valoracionEN.Video.Id;

            return v;

        }

        public static IList<ValoracionModel> convertListENToModel(IList<ValoracionEN> valoraciones)
        {

            IList<ValoracionModel> valoracionModels = new List<ValoracionModel>();

            foreach (ValoracionEN v in valoraciones)
            {

                ValoracionModel valoracionM = convertENToModelUI(v);

                valoracionModels.Add(valoracionM);
            }

            return valoracionModels;
        }


    }
}