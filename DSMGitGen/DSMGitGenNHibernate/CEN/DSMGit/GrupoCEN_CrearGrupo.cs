
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CEN.DSMGit_Grupo_crearGrupo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CEN.DSMGit
{
public partial class GrupoCEN
{
public string CrearGrupo (string p_nombre, System.Collections.Generic.IList<string> p_miembros, string p_lider, bool p_aceptaMiembros, string p_descripcion, string p_imagen)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CEN.DSMGit_Grupo_crearGrupo_customized) START*/

        GrupoEN grupoEN = null;

        string oid;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Nombre = p_nombre;


        grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
        if (p_miembros != null) {
                for (string item : p_miembros) {
                        DSMGitGenNHibernate.EN.DSMGit.UsuarioEN en = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                        en.Email = item;
                        grupoEN.Miembros ().Add (en);
                }
        }

        else{
                grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
        }


        if (p_lider != null) {
                grupoEN.Lider = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                grupoEN.Lider.Email = p_lider;
        }

        grupoEN.AceptaMiembros = p_aceptaMiembros;

        grupoEN.Descripcion = p_descripcion;

        grupoEN.Imagen = p_imagen;

        //Call to GrupoCAD

        oid = _IGrupoCAD.CrearGrupo (grupoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
