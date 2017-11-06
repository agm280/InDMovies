
using System;
// Definición clase ComentarioEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo usuario
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario;



/**
 *	Atributo video
 */
private DSMGitGenNHibernate.EN.DSMGit.VideoEN video;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.VideoEN Video {
        get { return video; } set { video = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string texto, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, DSMGitGenNHibernate.EN.DSMGit.VideoEN video
                    )
{
        this.init (Id, texto, usuario, video);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Texto, comentario.Usuario, comentario.Video);
}

private void init (int id
                   , string texto, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, DSMGitGenNHibernate.EN.DSMGit.VideoEN video)
{
        this.Id = id;


        this.Texto = texto;

        this.Usuario = usuario;

        this.Video = video;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
