
using System;
// Definición clase ValoracionEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valor
 */
private int valor;



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



public virtual int Valor {
        get { return valor; } set { valor = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.VideoEN Video {
        get { return video; } set { video = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int valor, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, DSMGitGenNHibernate.EN.DSMGit.VideoEN video
                    )
{
        this.init (Id, valor, usuario, video);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Valor, valoracion.Usuario, valoracion.Video);
}

private void init (int id
                   , int valor, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, DSMGitGenNHibernate.EN.DSMGit.VideoEN video)
{
        this.Id = id;


        this.Valor = valor;

        this.Usuario = usuario;

        this.Video = video;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
