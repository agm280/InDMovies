
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Usuario_entrarAGrupo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class UsuarioCP : BasicCP
{
public bool EntrarAGrupo (string p_oid, string p_nombreGrupo)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Usuario_entrarAGrupo) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        IGrupoCAD grupoCAD = null;
        UsuarioCEN usuarioCEN = null;
        GrupoCEN grupoCEN = null;
        Boolean resultadoOperacion = false;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);

                grupoCAD = new GrupoCAD (session);
                grupoCEN = new GrupoCEN (grupoCAD);
                Boolean existe = false;

                GrupoEN grupoEN = new GrupoEN ();
                UsuarioEN usuarioEN = new UsuarioEN ();

                // Write here your custom transaction ...

                IList<UsuarioEN> usuarios = usuarioCEN.DameUsuarioPorEmail (p_oid);
                if (usuarios.Count == 0) {
                        System.Console.WriteLine ("No hay usuario");
                        existe = false;
                }
                else{
                        if (grupoCEN.ReadOID (p_nombreGrupo) != null) {
                                usuarioEN = usuarioCEN.ReadOID (p_oid);
                                //System.Console.WriteLine("El grupo existe!");
                                grupoEN = grupoCEN.ReadOID (p_nombreGrupo);
                                existe = true;
                        }
                }

                if (existe == true) {
                        if (grupoEN.AceptaMiembros == true) {
                                if (grupoEN.Completo == false) {
                                        //esto podria modificarse para reutilizar el metodo GrupoCP_AnadirUsuario.
                                        /* IList<string> enviaUsu = new List<string>();
                                         * enviaUsu.Add(p_oid);
                                         * grupoCEN.MeterUsuario(p_oid, enviaUsu);
                                         * resultadoOperacion = true;*/
                                        GrupoCP grupoCP = new GrupoCP (session);
                                        resultadoOperacion = grupoCP.AnadirUsuario (p_nombreGrupo, p_oid);
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

        return resultadoOperacion;
        /*PROTECTED REGION END*/
}
}
}
