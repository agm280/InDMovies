
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Grupo_crearGrupo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class GrupoCP : BasicCP
{
public DSMGitGenNHibernate.EN.DSMGit.GrupoEN CrearGrupo (string p_nombre, System.Collections.Generic.IList<string> p_miembros, string p_lider, bool p_completo, bool p_aceptaMiembros, string p_descripcion, string p_imagen)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Grupo_crearGrupo) ENABLED START*/

        IGrupoCAD grupoCAD = null;
        GrupoCEN grupoCEN = null;
        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        DSMGitGenNHibernate.EN.DSMGit.GrupoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                grupoCAD = new GrupoCAD (session);
                grupoCEN = new  GrupoCEN (grupoCAD);
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);

                string oid;
                //Initialized GrupoEN
                GrupoEN grupoEN;
                grupoEN = new GrupoEN ();
                grupoEN.Nombre = p_nombre;


                grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                if (p_miembros != null) {
                        foreach (string item in p_miembros) {
                                try
                                {
                                        UsuarioEN en = usuarioCAD.ReadOID (item);
                                        grupoEN.Miembros.Add (en);
                                }
                                catch { }
                        }
                }

                else{
                        grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                }


                if (p_lider != null) {
                        grupoEN.Lider = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                        grupoEN.Lider.Email = p_lider;
                }



                if (p_completo == true)
                        grupoEN.AceptaMiembros = false;
                else
                        grupoEN.AceptaMiembros = p_aceptaMiembros;

                grupoEN.Descripcion = p_descripcion;
                grupoEN.Imagen = p_imagen;
                //Call to GrupoCAD

                oid = grupoCAD.CrearGrupo (grupoEN);
                result = grupoCAD.ReadOIDDefault (oid);



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
