using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class TemaAssembler
    {
        public static TemaModel ConvertENToModelUI(TemaEN en) {

            TemaModel tema = new TemaModel();

            tema.Id = en.Id;
            tema.Titulo = en.Titulo;
            tema.Descripcion = en.Descripcion;
            tema.Estado = en.Estado.ToString();
            tema.Usuario = en.Usuario.Nick;
            tema.Fecha = en.Fecha.Value;

            return tema;
        }

        public IList<TemaModel> ConvertListENToModel(IList<TemaEN> ens)
        {
            IList<TemaModel> arts = new List<TemaModel>();
            foreach (TemaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}