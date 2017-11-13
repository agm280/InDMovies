
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Usuario_salirDeGrupo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class UsuarioCP : BasicCP
{
public void SalirDeGrupo (string p_oid, string p_nombreGrupo)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Usuario_salirDeGrupo) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method SalirDeGrupo() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
