
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Invitacion_operation) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class InvitacionCP : BasicCP
{
public DSMGitGenNHibernate.EN.DSMGit.InvitacionEN Operation (string p_descripcion, string p_grupo, string p_invitador)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Invitacion_operation) ENABLED START*/

        IInvitacionCAD invitacionCAD = null;
        InvitacionCEN invitacionCEN = null;

        DSMGitGenNHibernate.EN.DSMGit.InvitacionEN result = null;


        try
        {
                SessionInitializeTransaction ();
                invitacionCAD = new InvitacionCAD (session);
                invitacionCEN = new  InvitacionCEN (invitacionCAD);




                int oid;
                //Initialized InvitacionEN
                InvitacionEN invitacionEN;
                invitacionEN = new InvitacionEN ();
                invitacionEN.Descripcion = p_descripcion;


                if (p_grupo != null) {
                        invitacionEN.Grupo = new DSMGitGenNHibernate.EN.DSMGit.GrupoEN ();
                        invitacionEN.Grupo.Nombre = p_grupo;
                }


                if (p_invitador != null) {
                        invitacionEN.Invitador = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                        invitacionEN.Invitador.Email = p_invitador;
                }

                //Call to InvitacionCAD

                oid = invitacionCAD.Operation (invitacionEN);
                result = invitacionCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
