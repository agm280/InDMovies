

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_texto, string p_usuario, int p_video)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Texto = p_texto;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                comentarioEN.Usuario.Email = p_usuario;
        }


        if (p_video != -1) {
                // El argumento p_video -> Property video es oid = false
                // Lista de oids id
                comentarioEN.Video = new DSMGitGenNHibernate.EN.DSMGit.VideoEN ();
                comentarioEN.Video.Id = p_video;
        }

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_texto)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Texto = p_texto;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> DameComentarioPorVideoID (int ? p_id)
{
        return _IComentarioCAD.DameComentarioPorVideoID (p_id);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> DameComentarioPorEmail (string user)
{
        return _IComentarioCAD.DameComentarioPorEmail (user);
}
}
}
