
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
using System.Collections.Generic;

/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class UsuarioCP : BasicCP
{
public bool SalirDeGrupo (string p_oid, string p_nombreGrupo)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Usuario_salirDeGrupo) ENABLED START*/


        IUsuarioCAD usuarioCAD = null;
        IGrupoCAD grupoCAD = null;
        UsuarioCEN usuarioCEN = null;
        GrupoCEN grupoCEN = null;
        Boolean resultadoOperacion = false;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                grupoCAD = new GrupoCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                grupoCEN = new GrupoCEN (grupoCAD);


                GrupoEN grupoEN = new GrupoEN ();
                UsuarioEN usuarioEN = new UsuarioEN ();
                Boolean existe = false;
                Boolean perteneceAlGrupo = false;


                // Write here your custom transaction ...

                IList<UsuarioEN> usuarios = usuarioCEN.DameUsuarioPorEmail (p_oid);

                if (usuarios.Count == 0) {
                        System.Console.WriteLine ("No existe ese usuario");
                }
                else{
                        IList<GrupoEN> grupos = grupoCEN.DameGruposPorNombre (p_nombreGrupo);

                        if (grupos.Count == 0) {
                                System.Console.WriteLine ("No existe ese grupo");
                        }
                        else{
                                if (grupoCEN.ReadOID (p_nombreGrupo) != null) {
                                        usuarioEN = usuarioCEN.ReadOID (p_oid);
                                        //System.Console.WriteLine("El grupo existe!");
                                        grupoEN = grupoCEN.ReadOID (p_nombreGrupo);
                                        existe = true;
                                }
                        }
                }



                if (existe == true && usuarioEN.Grupos != null) {
                        foreach (GrupoEN gru in usuarioEN.Grupos) {
                                if (gru.Nombre == p_nombreGrupo) {
                                        perteneceAlGrupo = true;
                                }
                        }
                }



                if (perteneceAlGrupo == true) {
                        IList<string> emailsQueQuitarDelGrupo = new List<string>();
                        emailsQueQuitarDelGrupo.Add (p_oid);
                        grupoCEN.SacarUsuario (p_nombreGrupo, emailsQueQuitarDelGrupo);
                        resultadoOperacion = true;
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
