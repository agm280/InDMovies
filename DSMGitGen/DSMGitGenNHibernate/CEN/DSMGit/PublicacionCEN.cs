

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
 *      Definition of the class PublicacionCEN
 *
 */
public partial class PublicacionCEN
{
private IPublicacionCAD _IPublicacionCAD;

public PublicacionCEN()
{
        this._IPublicacionCAD = new PublicacionCAD ();
}

public PublicacionCEN(IPublicacionCAD _IPublicacionCAD)
{
        this._IPublicacionCAD = _IPublicacionCAD;
}

public IPublicacionCAD get_IPublicacionCAD ()
{
        return this._IPublicacionCAD;
}

public int New_ (string p_titulo, Nullable<DateTime> p_fecha, string p_imagen, string p_grupo)
{
        PublicacionEN publicacionEN = null;
        int oid;

        //Initialized PublicacionEN
        publicacionEN = new PublicacionEN ();
        publicacionEN.Titulo = p_titulo;

        publicacionEN.Fecha = p_fecha;

        publicacionEN.Imagen = p_imagen;


        if (p_grupo != null) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                publicacionEN.Grupo = new DSMGitGenNHibernate.EN.DSMGit.GrupoEN ();
                publicacionEN.Grupo.Nombre = p_grupo;
        }

        //Call to PublicacionCAD

        oid = _IPublicacionCAD.New_ (publicacionEN);
        return oid;
}

public void Modify (int p_Publicacion_OID, string p_titulo, Nullable<DateTime> p_fecha, string p_imagen)
{
        PublicacionEN publicacionEN = null;

        //Initialized PublicacionEN
        publicacionEN = new PublicacionEN ();
        publicacionEN.Id = p_Publicacion_OID;
        publicacionEN.Titulo = p_titulo;
        publicacionEN.Fecha = p_fecha;
        publicacionEN.Imagen = p_imagen;
        //Call to PublicacionCAD

        _IPublicacionCAD.Modify (publicacionEN);
}

public void Destroy (int id
                     )
{
        _IPublicacionCAD.Destroy (id);
}

public PublicacionEN ReadOID (int id
                              )
{
        PublicacionEN publicacionEN = null;

        publicacionEN = _IPublicacionCAD.ReadOID (id);
        return publicacionEN;
}

public System.Collections.Generic.IList<PublicacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PublicacionEN> list = null;

        list = _IPublicacionCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> DamePublicacionesDelGrupo (string p_nombre)
{
        return _IPublicacionCAD.DamePublicacionesDelGrupo (p_nombre);
}
}
}
