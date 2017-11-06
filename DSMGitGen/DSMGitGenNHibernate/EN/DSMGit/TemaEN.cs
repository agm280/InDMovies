
using System;
// Definición clase TemaEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class TemaEN
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
 *	Atributo respuestas
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas;



/**
 *	Atributo estado
 */
private DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum estado;



/**
 *	Atributo usuario
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo etiquetas
 */
private System.Collections.Generic.IList<string> etiquetas;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}



public virtual DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual System.Collections.Generic.IList<string> Etiquetas {
        get { return etiquetas; } set { etiquetas = value;  }
}





public TemaEN()
{
        respuestas = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
}



public TemaEN(int id, string descripcion, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas, DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum estado, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, string titulo, System.Collections.Generic.IList<string> etiquetas
              )
{
        this.init (Id, descripcion, respuestas, estado, usuario, titulo, etiquetas);
}


public TemaEN(TemaEN tema)
{
        this.init (Id, tema.Descripcion, tema.Respuestas, tema.Estado, tema.Usuario, tema.Titulo, tema.Etiquetas);
}

private void init (int id
                   , string descripcion, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas, DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum estado, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario, string titulo, System.Collections.Generic.IList<string> etiquetas)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Respuestas = respuestas;

        this.Estado = estado;

        this.Usuario = usuario;

        this.Titulo = titulo;

        this.Etiquetas = etiquetas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TemaEN t = obj as TemaEN;
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
