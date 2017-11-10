
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Invitacion_crearInvitacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class InvitacionCP : BasicCP
{
public bool CrearInvitacion (string invitado, string invitador, string grupo, string descripcion)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Invitacion_crearInvitacion) ENABLED START*/

        IInvitacionCAD invitacionCAD = null;
        InvitacionCEN invitacionCEN = null;
        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        bool result = false;


        try
        {
                SessionInitializeTransaction ();
                invitacionCAD = new InvitacionCAD (session);
                invitacionCEN = new  InvitacionCEN (invitacionCAD);
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);


                int id_invitacion = invitacionCEN.New_ (p_descripcion: descripcion, p_grupo: grupo, p_invitador: invitador);
                //ALVARO HE PUESTO ESTO EN COMENTARIO PORQUE NO ME DEJABA COMPILAR:
                //invitacionCEN.AnadirUsuario (id_invitacion, invitado);
                result = true;


                // Write here your custom transaction ...

                //throw new NotImplementedException ("Method CrearInvitacion() not yet implemented.");



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
