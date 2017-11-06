
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
public partial class SugerenciaCP : BasicCP
{
public SugerenciaCP() : base ()
{
}

public SugerenciaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
