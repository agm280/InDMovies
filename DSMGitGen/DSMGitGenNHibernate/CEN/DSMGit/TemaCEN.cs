

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
 *      Definition of the class TemaCEN
 *
 */
public partial class TemaCEN
{
private ITemaCAD _ITemaCAD;

public TemaCEN()
{
        this._ITemaCAD = new TemaCAD ();
}

public TemaCEN(ITemaCAD _ITemaCAD)
{
        this._ITemaCAD = _ITemaCAD;
}

public ITemaCAD get_ITemaCAD ()
{
        return this._ITemaCAD;
}

public int New_ (string p_descripcion, DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum p_estado, string p_usuario, string p_titulo, Nullable<DateTime> p_fecha)
{
        TemaEN temaEN = null;
        int oid;

        //Initialized TemaEN
        temaEN = new TemaEN ();
        temaEN.Descripcion = p_descripcion;

        temaEN.Estado = p_estado;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                temaEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                temaEN.Usuario.Email = p_usuario;
        }

        temaEN.Titulo = p_titulo;

        temaEN.Fecha = p_fecha;

        //Call to TemaCAD

        oid = _ITemaCAD.New_ (temaEN);
        return oid;
}

public void Modify (int p_Tema_OID, string p_descripcion, DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum p_estado, string p_titulo, Nullable<DateTime> p_fecha)
{
        TemaEN temaEN = null;

        //Initialized TemaEN
        temaEN = new TemaEN ();
        temaEN.Id = p_Tema_OID;
        temaEN.Descripcion = p_descripcion;
        temaEN.Estado = p_estado;
        temaEN.Titulo = p_titulo;
        temaEN.Fecha = p_fecha;
        //Call to TemaCAD

        _ITemaCAD.Modify (temaEN);
}

public void Destroy (int id
                     )
{
        _ITemaCAD.Destroy (id);
}

public TemaEN ReadOID (int id
                       )
{
        TemaEN temaEN = null;

        temaEN = _ITemaCAD.ReadOID (id);
        return temaEN;
}

public System.Collections.Generic.IList<TemaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TemaEN> list = null;

        list = _ITemaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasAbiertos ()
{
        return _ITemaCAD.DameTemasAbiertos ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasCerrados ()
{
        return _ITemaCAD.DameTemasCerrados ();
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorNick (string p_nick)
{
        return _ITemaCAD.DameTemaPorNick (p_nick);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorEmail (string p_email)
{
        return _ITemaCAD.DameTemaPorEmail (p_email);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorDesc (string p_desc)
{
        return _ITemaCAD.DameTemaPorDesc (p_desc);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorTitulo (string p_titulo)
{
        return _ITemaCAD.DameTemaPorTitulo (p_titulo);
}
}
}
