
using System;
// Definición clase RespuestaEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class RespuestaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo tema
 */
private DSMGitGenNHibernate.EN.DSMGit.TemaEN tema;



/**
 *	Atributo usuario
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.TemaEN Tema {
        get { return tema; } set { tema = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public RespuestaEN()
{
}



public RespuestaEN(int id, string descripcion, DSMGitGenNHibernate.EN.DSMGit.TemaEN tema, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, Nullable<DateTime> fecha
                   )
{
        this.init (Id, descripcion, tema, usuario, fecha);
}


public RespuestaEN(RespuestaEN respuesta)
{
        this.init (Id, respuesta.Descripcion, respuesta.Tema, respuesta.Usuario, respuesta.Fecha);
}

private void init (int id
                   , string descripcion, DSMGitGenNHibernate.EN.DSMGit.TemaEN tema, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Tema = tema;

        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RespuestaEN t = obj as RespuestaEN;
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
