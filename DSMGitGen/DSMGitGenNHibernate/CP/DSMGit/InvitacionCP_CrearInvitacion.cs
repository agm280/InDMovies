
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
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class InvitacionCP : BasicCP
{
public void CrearInvitacion (System.Collections.Generic.IList<string> invitado, string invitador, string grupo, string descripcion)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Invitacion_crearInvitacion) ENABLED START*/

        IInvitacionCAD invitacionCAD = null;
        InvitacionCEN invitacionCEN = null;
        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IGrupoCAD grupoCAD = null;
        GrupoCEN grupoCEN = null;

        try
        {
                SessionInitializeTransaction ();
                invitacionCAD = new InvitacionCAD (session);
                invitacionCEN = new  InvitacionCEN (invitacionCAD);
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);
                grupoCAD = new GrupoCAD (session);
                grupoCEN = new GrupoCEN (grupoCAD);
                foreach (string usuinvi in invitado) {
                        bool result = true;
                        UsuarioEN usua = usuarioCEN.ReadOID (usuinvi);
                        GrupoEN gr = grupoCEN.ReadOID (grupo);
                        if (usua != null && gr != null) {
                                IList<UsuarioEN> usuGrupo = gr.Miembros;
                                foreach (UsuarioEN usu in usuGrupo) {
                                        if (usu.Email == usuinvi) {
                                                result = false;
                                                break;
                                        }
                                }
                                bool dentro = false;
                                foreach (UsuarioEN usu2 in usuGrupo) {
                                        if (usu2.Email == invitador)
                                                dentro = true;
                                }
                                if (result == true && dentro == true) {
                                        int id_invitacion = invitacionCEN.New_ (p_descripcion: descripcion, p_grupo: grupo, p_invitador: invitador);
                                        IList<string> enviaUsu = new List<string>();
                                        enviaUsu.Add (usuinvi);
                                        invitacionCEN.MeterUsuario (id_invitacion, enviaUsu);
                                }
                        }
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
