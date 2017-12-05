
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Invitacion_aceptarInvitacion) ENABLED START*/
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class InvitacionCP : BasicCP
{
public void AceptarInvitacion (int p_oid, string idInvitado)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Invitacion_aceptarInvitacion) ENABLED START*/

        IInvitacionCAD invitacionCAD = null;
        InvitacionCEN invitacionCEN = null;
        IGrupoCAD grupoCAD = null;
        GrupoCEN grupoCEN = null;
        GrupoCP grupoCP = null;


        try
        {
                SessionInitializeTransaction ();
                invitacionCAD = new InvitacionCAD (session);
                invitacionCEN = new  InvitacionCEN (invitacionCAD);

                //obteniendo el grupo de la invitacion
                grupoCAD = new GrupoCAD (session);
                grupoCEN = new GrupoCEN (grupoCAD);

                InvitacionEN invi = invitacionCEN.ReadOID (p_oid);

                grupoCP = new GrupoCP ();
                grupoCP.AnadirUsuario (invi.Grupo.Nombre, idInvitado);

                invitacionCEN.QuitarInvitado (p_oid, new List<string>() {
                                idInvitado
                        });

                invi = invitacionCEN.ReadOID (p_oid);
                IList<UsuarioEN> usuarios = invi.Usuario_invitado;

                if (usuarios.Count <= 0) {
                        invitacionCEN.QuitarGrupo (p_oid, invi.Grupo.Nombre);
                        invitacionCEN.QuitarInvitador (p_oid, invi.Invitador.Email);
                        invitacionCEN.Destroy (p_oid);
                }

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
