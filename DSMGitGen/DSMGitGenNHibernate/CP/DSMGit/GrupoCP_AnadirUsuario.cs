
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Grupo_anadirUsuario) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class GrupoCP : BasicCP
{
public bool AnadirUsuario (string p_oid, string p_email)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Grupo_anadirUsuario) ENABLED START*/

        IGrupoCAD grupoCAD = null;
        IUsuarioCAD usuarioCAD = null;
        GrupoCEN grupoCEN = null;
        UsuarioCEN usuarioCEN = null;

        bool result = true;

        if (p_email != null && p_oid != null) {
                try
                {
                        SessionInitializeTransaction ();
                        grupoCAD = new GrupoCAD (session);
                        grupoCEN = new GrupoCEN (grupoCAD);
                        usuarioCAD = new UsuarioCAD (session);
                        usuarioCEN = new UsuarioCEN (usuarioCAD);


                        // Write here your custom transaction ...

                        //throw new NotImplementedException ("Method AnadirUsuario() not yet implemented.");


                        IList<UsuarioEN> usuarios = usuarioCEN.DameUsuarioPorEmail (p_email);
                        if (usuarios.Count == 0) {
                                System.Console.WriteLine ("No existe el usuario");
                                result = false;
                        }
                        else {
                                GrupoEN grupito = grupoCEN.ReadOID (p_oid);
                                if (grupito != null) {
                                        IList<UsuarioEN> usuGrupo = grupito.Miembros;

                                        foreach (UsuarioEN usu in usuGrupo) {
                                                if (usu.Email == p_email) {
                                                        result = false;
                                                        break;
                                                }
                                        }
                                }
                                else{
                                        result = false;
                                }


                                if (result == true && grupito != null) {
                                     if (grupito.Completo == false)
                                         {
                                //-------------AQUI-------------

                                            IList<string> enviaUsu = new List<string>();
                                             enviaUsu.Add(p_email);

                                             grupoCEN.MeterUsuario(p_oid, enviaUsu);

                                //------------------------------------
                            }
                                     else
                                        {
                                        System.Console.WriteLine ("El grupo esta lleno.");
                                         result = false;
                                        }
                                }
                                else{
                                     result = false;
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
        }
        else{
                result = false;
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
