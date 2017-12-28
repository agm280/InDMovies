using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RolListAssembler
    {

        public static RolModel ConvertSelectRol() {

            RolModel roles = new RolModel();

            roles.SelectedRol = DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.actor.ToString();

            roles.Roles = new List<DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum>() {
                DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.actor,
                DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.camara,
                DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.director,
                DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.editor,
                DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum.guionista,
            };

            return roles;
        }
    }
}