

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;

using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


namespace DSMGitGenNHibernate.CEN.DSMGit
{
/*
 *      Definition of the class GrupoCEN
 *
 */
public partial class GrupoCEN
{
private IGrupoCAD _IGrupoCAD;

public GrupoCEN()
{
        this._IGrupoCAD = new GrupoCAD ();
}

public GrupoCEN(IGrupoCAD _IGrupoCAD)
{
        this._IGrupoCAD = _IGrupoCAD;
}

public IGrupoCAD get_IGrupoCAD ()
{
        return this._IGrupoCAD;
}

public string New_ (string p_nombre, string p_imagen, string p_descripcion, System.Collections.Generic.IList<string> p_miembros, string p_lider, bool p_completo, bool p_aceptaMiembros)
{
        GrupoEN grupoEN = null;
        string oid;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Nombre = p_nombre;

        grupoEN.Imagen = p_imagen;

        grupoEN.Descripcion = p_descripcion;


        grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
        if (p_miembros != null) {
                foreach (string item in p_miembros) {
                        DSMGitGenNHibernate.EN.DSMGit.UsuarioEN en = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                        en.Email = item;
                        grupoEN.Miembros.Add (en);
                }
        }

        else{
                grupoEN.Miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
        }


        if (p_lider != null) {
                // El argumento p_lider -> Property lider es oid = false
                // Lista de oids nombre
                grupoEN.Lider = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                grupoEN.Lider.Email = p_lider;
        }

        grupoEN.Completo = p_completo;

        grupoEN.AceptaMiembros = p_aceptaMiembros;

        //Call to GrupoCAD

        oid = _IGrupoCAD.New_ (grupoEN);
        return oid;
}

public void Modify (string p_Grupo_OID, string p_imagen, string p_descripcion, bool p_completo, bool p_aceptaMiembros)
{
        GrupoEN grupoEN = null;

        //Initialized GrupoEN
        grupoEN = new GrupoEN ();
        grupoEN.Nombre = p_Grupo_OID;
        grupoEN.Imagen = p_imagen;
        grupoEN.Descripcion = p_descripcion;
        grupoEN.Completo = p_completo;
        grupoEN.AceptaMiembros = p_aceptaMiembros;
        //Call to GrupoCAD

        _IGrupoCAD.Modify (grupoEN);
}

public void Destroy (string nombre
                     )
{
        _IGrupoCAD.Destroy (nombre);
}

public GrupoEN ReadOID (string nombre
                        )
{
        GrupoEN grupoEN = null;

        grupoEN = _IGrupoCAD.ReadOID (nombre);
        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> list = null;

        list = _IGrupoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposNoLlenos ()
{
        return _IGrupoCAD.DameGruposNoLlenos ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLlenos ()
{
        return _IGrupoCAD.DameGruposLlenos ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorNick (string p_nick)
{
        return _IGrupoCAD.DameGruposLideradosPorNick (p_nick);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorEmail (string p_email)
{
        return _IGrupoCAD.DameGruposLideradosPorEmail (p_email);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorNombre (string p_nombre)
{
        return _IGrupoCAD.DameGruposPorNombre (p_nombre);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorDesc (string p_desc)
{
        return _IGrupoCAD.DameGruposPorDesc (p_desc);
}
public void MeterUsuario (string p_Grupo_OID, System.Collections.Generic.IList<string> p_miembros_OIDs)
{
        //Call to GrupoCAD

        _IGrupoCAD.MeterUsuario (p_Grupo_OID, p_miembros_OIDs);
}
public void SacarUsuario (string p_Grupo_OID, System.Collections.Generic.IList<string> p_miembros_OIDs)
{
        //Call to GrupoCAD

        _IGrupoCAD.SacarUsuario (p_Grupo_OID, p_miembros_OIDs);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposQueAceptenNuevos ()
{
        return _IGrupoCAD.DameGruposQueAceptenNuevos ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposQueRechacenNuevos ()
{
        return _IGrupoCAD.DameGruposQueRechacenNuevos ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGrupoPorUsuario (string p_email)
{
        return _IGrupoCAD.DameGrupoPorUsuario (p_email);
}
}
}
