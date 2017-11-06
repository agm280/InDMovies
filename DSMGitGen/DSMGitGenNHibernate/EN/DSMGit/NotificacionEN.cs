
using System;
// Definición clase NotificacionEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private string id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo usuario
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario;






public virtual string Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(string id, string descripcion, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario
                      )
{
        this.init (Id, descripcion, usuario);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Descripcion, notificacion.Usuario);
}

private void init (string id
                   , string descripcion, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
