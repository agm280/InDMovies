
using System;
// Definición clase PublicacionEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class PublicacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo grupo
 */
private DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}





public PublicacionEN()
{
}



public PublicacionEN(int id, string titulo, Nullable<DateTime> fecha, string imagen, DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo
                     )
{
        this.init (Id, titulo, fecha, imagen, grupo);
}


public PublicacionEN(PublicacionEN publicacion)
{
        this.init (Id, publicacion.Titulo, publicacion.Fecha, publicacion.Imagen, publicacion.Grupo);
}

private void init (int id
                   , string titulo, Nullable<DateTime> fecha, string imagen, DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Fecha = fecha;

        this.Imagen = imagen;

        this.Grupo = grupo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PublicacionEN t = obj as PublicacionEN;
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
