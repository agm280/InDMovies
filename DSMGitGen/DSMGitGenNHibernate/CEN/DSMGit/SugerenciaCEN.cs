

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
 *      Definition of the class SugerenciaCEN
 *
 */
public partial class SugerenciaCEN
{
private ISugerenciaCAD _ISugerenciaCAD;

public SugerenciaCEN()
{
        this._ISugerenciaCAD = new SugerenciaCAD ();
}

public SugerenciaCEN(ISugerenciaCAD _ISugerenciaCAD)
{
        this._ISugerenciaCAD = _ISugerenciaCAD;
}

public ISugerenciaCAD get_ISugerenciaCAD ()
{
        return this._ISugerenciaCAD;
}

public int New_ (string p_titulo, string p_descripcion, string p_usuario)
{
        SugerenciaEN sugerenciaEN = null;
        int oid;

        //Initialized SugerenciaEN
        sugerenciaEN = new SugerenciaEN ();
        sugerenciaEN.Titulo = p_titulo;

        sugerenciaEN.Descripcion = p_descripcion;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                sugerenciaEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                sugerenciaEN.Usuario.Email = p_usuario;
        }

        //Call to SugerenciaCAD

        oid = _ISugerenciaCAD.New_ (sugerenciaEN);
        return oid;
}

public void Modify (int p_Sugerencia_OID, string p_titulo, string p_descripcion)
{
        SugerenciaEN sugerenciaEN = null;

        //Initialized SugerenciaEN
        sugerenciaEN = new SugerenciaEN ();
        sugerenciaEN.Id = p_Sugerencia_OID;
        sugerenciaEN.Titulo = p_titulo;
        sugerenciaEN.Descripcion = p_descripcion;
        //Call to SugerenciaCAD

        _ISugerenciaCAD.Modify (sugerenciaEN);
}

public void Destroy (int id
                     )
{
        _ISugerenciaCAD.Destroy (id);
}

public SugerenciaEN ReadOID (int id
                             )
{
        SugerenciaEN sugerenciaEN = null;

        sugerenciaEN = _ISugerenciaCAD.ReadOID (id);
        return sugerenciaEN;
}

public System.Collections.Generic.IList<SugerenciaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SugerenciaEN> list = null;

        list = _ISugerenciaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> DameSugerenciaPorEmail (string p_email)
{
        return _ISugerenciaCAD.DameSugerenciaPorEmail (p_email);
}
}
}
