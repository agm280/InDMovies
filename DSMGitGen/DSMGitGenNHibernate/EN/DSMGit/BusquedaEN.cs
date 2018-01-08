
using System;
// Definición clase BusquedaEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class BusquedaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo texto
 */
private string texto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}





public BusquedaEN()
{
}



public BusquedaEN(int id, string texto
                  )
{
        this.init (Id, texto);
}


public BusquedaEN(BusquedaEN busqueda)
{
        this.init (Id, busqueda.Texto);
}

private void init (int id
                   , string texto)
{
        this.Id = id;


        this.Texto = texto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BusquedaEN t = obj as BusquedaEN;
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
