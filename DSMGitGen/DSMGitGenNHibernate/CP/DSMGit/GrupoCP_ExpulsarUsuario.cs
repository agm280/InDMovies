
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Grupo_expulsarUsuario) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;

/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class GrupoCP : BasicCP
{
public bool ExpulsarUsuario (string p_oid, string p_email)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Grupo_expulsarUsuario) ENABLED START*/

        IGrupoCAD grupoCAD = null;
        IUsuarioCAD usuarioCAD = null;
        GrupoCEN grupoCEN = null;
        UsuarioCEN usuarioCEN = null;

        Boolean resultado = false;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                grupoCAD = new GrupoCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);
                grupoCEN = new GrupoCEN (grupoCAD);


                GrupoEN grupoEN = new GrupoEN ();
                UsuarioEN usuarioEN = new UsuarioEN ();

                // Write here your custom transaction ...

                IList<UsuarioEN> usuarios = usuarioCEN.DameUsuarioPorEmail (p_email);

                if (usuarios.Count == 0) {
                        System.Console.WriteLine ("Usuario inexistente");
                }
                else{                                            // Si el usuario existe
                        IList<GrupoEN> grupos = grupoCEN.DameGruposPorNombre (p_oid);

                        if (grupos.Count == 0) {
                                System.Console.WriteLine ("No existe ese grupo");
                        }
                        else{                                           // Si el grupo tambien existe
                                GrupoEN group = grupoCEN.ReadOID (p_oid);
                                IList<UsuarioEN> usuGrupo = group.Miembros;

                                foreach (UsuarioEN usu in usuGrupo) {       // Recorro el grupo
                                        if (usu.Email == p_email) {                 // Si existe ese usuario en el grupo
                                                IList<string> expulsados = new List<string>();
                                                expulsados.Add (p_email);
                                                grupoCEN.SacarUsuario (p_oid, expulsados);
                                                resultado = true;
                                                break;
                                        }
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
        return resultado;


        /*PROTECTED REGION END*/
}
}
}
