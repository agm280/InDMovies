using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class ComentarioAssembler
    {

        public static ComentarioModel convertENToModelUI(ComentarioEN comentarioEN) {

            ComentarioModel c = new ComentarioModel();

            c.Id = comentarioEN.Id;
            c.Texto = comentarioEN.Texto;
            c.Usuario = comentarioEN.Usuario.Nick;
            c.Video = comentarioEN.Video.Id;

            return c;
        }

        public static IList<ComentarioModel> convertListENToModel(IList<ComentarioEN> comentarios) {

            IList<ComentarioModel> comentarioModels = new List<ComentarioModel>();

            foreach (ComentarioEN c in comentarios) {

                ComentarioModel comentarioModel = convertENToModelUI(c);

                comentarioModels.Add(comentarioModel);

            }

            return comentarioModels;

        }

    }
}