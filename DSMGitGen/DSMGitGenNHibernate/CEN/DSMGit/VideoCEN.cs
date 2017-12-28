

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
 *      Definition of the class VideoCEN
 *
 */
public partial class VideoCEN
{
private IVideoCAD _IVideoCAD;

public VideoCEN()
{
        this._IVideoCAD = new VideoCAD ();
}

public VideoCEN(IVideoCAD _IVideoCAD)
{
        this._IVideoCAD = _IVideoCAD;
}

public IVideoCAD get_IVideoCAD ()
{
        return this._IVideoCAD;
}

public int New_ (string p_titulo, string p_descripcion, string p_usuario, Nullable<DateTime> p_fecha_subida, string p_miniatura)
{
        VideoEN videoEN = null;
        int oid;

        //Initialized VideoEN
        videoEN = new VideoEN ();
        videoEN.Titulo = p_titulo;

        videoEN.Descripcion = p_descripcion;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                videoEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                videoEN.Usuario.Email = p_usuario;
        }

        videoEN.Fecha_subida = p_fecha_subida;

        videoEN.Miniatura = p_miniatura;

        //Call to VideoCAD

        oid = _IVideoCAD.New_ (videoEN);
        return oid;
}

public void Modify (int p_Video_OID, string p_titulo, string p_descripcion, Nullable<DateTime> p_fecha_subida, string p_miniatura)
{
        VideoEN videoEN = null;

        //Initialized VideoEN
        videoEN = new VideoEN ();
        videoEN.Id = p_Video_OID;
        videoEN.Titulo = p_titulo;
        videoEN.Descripcion = p_descripcion;
        videoEN.Fecha_subida = p_fecha_subida;
        videoEN.Miniatura = p_miniatura;
        //Call to VideoCAD

        _IVideoCAD.Modify (videoEN);
}

public void Destroy (int id
                     )
{
        _IVideoCAD.Destroy (id);
}

public VideoEN ReadOID (int id
                        )
{
        VideoEN videoEN = null;

        videoEN = _IVideoCAD.ReadOID (id);
        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> list = null;

        list = _IVideoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorTitulo (string p_titulo)
{
        return _IVideoCAD.DameVideoPorTitulo (p_titulo);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorNick (string p_nick)
{
        return _IVideoCAD.DameVideoPorNick (p_nick);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorFecha (int? p_anyo, int? p_mes, int ? p_dia)
{
        return _IVideoCAD.DameVideoPorFecha (p_anyo, p_mes, p_dia);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorEmail (string p_email)
{
        return _IVideoCAD.DameVideoPorEmail (p_email);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorDescripcion (string p_descripcion)
{
        return _IVideoCAD.DameVideoPorDescripcion (p_descripcion);
}
}
}
