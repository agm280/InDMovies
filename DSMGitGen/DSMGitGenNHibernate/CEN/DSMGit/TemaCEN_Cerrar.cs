
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CEN.DSMGit_Tema_cerrar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CEN.DSMGit
{
public partial class TemaCEN
{
public void Cerrar (int p_oid)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CEN.DSMGit_Tema_cerrar) ENABLED START*/
        TemaEN tema = _ITemaCAD.ReadOID (p_oid);

        if (tema.Estado == Enumerated.DSMGit.EstadoTemaEnum.abierto) {
                tema.Estado = Enumerated.DSMGit.EstadoTemaEnum.cerrado;
                bool result = true;
        }
        _ITemaCAD.Modify (tema);
        // Write here your custom code...

        //throw new NotImplementedException ("Method Cerrar() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
