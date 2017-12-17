using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TemaAssembler
    {
        public static TemaModel ConvertENToModelUI(TemaEN tema)
        {
            TemaModel te = new TemaModel();
            te.Id = tema.Id;
            te.Descripcion = tema.Descripcion;
            te.Usuario = tema.Usuario.Nick;
            te.Estado = tema.Estado.ToString();
            te.Titulo = tema.Titulo;
            te.Etiquetas = tema.Etiquetas;
            return te;
        }

        public static IList<TemaModel> ConvertListENToModel(IList<TemaEN> temas)
        {
            IList<TemaModel> arts = new List<TemaModel>();
            foreach (TemaEN en in temas)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}