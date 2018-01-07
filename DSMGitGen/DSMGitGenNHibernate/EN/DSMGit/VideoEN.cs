
using System;
// Definición clase VideoEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class VideoEN
{
/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo etiquetas
 */
private System.Collections.Generic.IList<string> etiquetas;



/**
 *	Atributo usuario
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario;



/**
 *	Atributo valoraciones
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios;



/**
 *	Atributo fecha_subida
 */
private Nullable<DateTime> fecha_subida;



/**
 *	Atributo miniatura
 */
private string miniatura;



/**
 *	Atributo url
 */
private string url;






public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<string> Etiquetas {
        get { return etiquetas; } set { etiquetas = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> Valoraciones {
        get { return valoraciones; } set { valoraciones = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual Nullable<DateTime> Fecha_subida {
        get { return fecha_subida; } set { fecha_subida = value;  }
}



public virtual string Miniatura {
        get { return miniatura; } set { miniatura = value;  }
}



public virtual string Url {
        get { return url; } set { url = value;  }
}





public VideoEN()
{
        valoraciones = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN>();
        comentarios = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN>();
}



public VideoEN(int id, string titulo, string descripcion, System.Collections.Generic.IList<string> etiquetas, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios, Nullable<DateTime> fecha_subida, string miniatura, string url
               )
{
        this.init (Id, titulo, descripcion, etiquetas, usuario, valoraciones, comentarios, fecha_subida, miniatura, url);
}


public VideoEN(VideoEN video)
{
        this.init (Id, video.Titulo, video.Descripcion, video.Etiquetas, video.Usuario, video.Valoraciones, video.Comentarios, video.Fecha_subida, video.Miniatura, video.Url);
}

private void init (int id
                   , string titulo, string descripcion, System.Collections.Generic.IList<string> etiquetas, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios, Nullable<DateTime> fecha_subida, string miniatura, string url)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Etiquetas = etiquetas;

        this.Usuario = usuario;

        this.Valoraciones = valoraciones;

        this.Comentarios = comentarios;

        this.Fecha_subida = fecha_subida;

        this.Miniatura = miniatura;

        this.Url = url;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideoEN t = obj as VideoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
