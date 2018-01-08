using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class BusquedaAssembler
    {
        public static BusquedaModel ConvertENToModelUI(BusquedaEN en)
        {
            BusquedaModel bus = new BusquedaModel();
            bus.Id = en.Id;
            bus.Texto = en.Texto;
            return bus;
        }

        public IList<BusquedaModel> ConvertListENToModel(IList<BusquedaEN> ens)
        {
            IList<BusquedaModel> arts = new List<BusquedaModel>();
            foreach (BusquedaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}