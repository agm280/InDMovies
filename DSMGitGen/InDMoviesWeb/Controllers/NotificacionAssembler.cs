using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InDMoviesWeb.Models;

namespace InDMoviesWeb.Controllers
{
    public class NotificacionAssembler
    {
        public static NotificacionModel ConvertENToModelUI(NotificacionEN en)
        {
            NotificacionModel not = new NotificacionModel();
            not.Id = en.Id;
            not.Usuario = en.Usuario.Nick;
            not.Descripcion = en.Descripcion;

            return not;
        }

        public static IList<NotificacionModel> ConvertListENToModel(IList<NotificacionEN> ens)
        {
            IList<NotificacionModel> notifs = new List<NotificacionModel>();
            foreach (NotificacionEN en in ens)
            {
                notifs.Add(ConvertENToModelUI(en));
            }
            return notifs;
        }
    }
}