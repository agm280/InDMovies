using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RolModel
    {
        public string SelectedRol { get; set; }
        public IEnumerable<DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum> Roles { get; set; }
    }
}