
using System;
// Definición clase SugerenciaEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class SugerenciaEN
{
/**
 *	Atributo id
 */
private string id;



/**
 *	Atributo titulo
 */
private string titulo;



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



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public SugerenciaEN()
{
}



public SugerenciaEN(string id, string titulo, string descripcion, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario
                    )
{
        this.init (Id, titulo, descripcion, usuario);
}


public SugerenciaEN(SugerenciaEN sugerencia)
{
        this.init (Id, sugerencia.Titulo, sugerencia.Descripcion, sugerencia.Usuario);
}

private void init (string id
                   , string titulo, string descripcion, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SugerenciaEN t = obj as SugerenciaEN;
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
