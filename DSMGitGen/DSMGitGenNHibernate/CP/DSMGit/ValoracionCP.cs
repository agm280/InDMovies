
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using DSMGitGenNHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;


namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class ValoracionCP : BasicCP
{
public ValoracionCP() : base ()
{
}

public ValoracionCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
