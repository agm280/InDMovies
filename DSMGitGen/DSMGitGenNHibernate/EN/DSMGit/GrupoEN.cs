
using System;
// Definición clase GrupoEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class GrupoEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo miembros
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> miembros;



/**
 *	Atributo publicaciones
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> publicaciones;



/**
 *	Atributo invitaciones
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones;



/**
 *	Atributo lider
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN lider;



/**
 *	Atributo completo
 */
private bool completo;



/**
 *	Atributo aceptaMiembros
 */
private bool aceptaMiembros;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> Miembros {
        get { return miembros; } set { miembros = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> Publicaciones {
        get { return publicaciones; } set { publicaciones = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> Invitaciones {
        get { return invitaciones; } set { invitaciones = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Lider {
        get { return lider; } set { lider = value;  }
}



public virtual bool Completo {
        get { return completo; } set { completo = value;  }
}



public virtual bool AceptaMiembros {
        get { return aceptaMiembros; } set { aceptaMiembros = value;  }
}





public GrupoEN()
{
        miembros = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
        publicaciones = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN>();
        invitaciones = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN>();
}



public GrupoEN(string nombre, string imagen, string descripcion, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> miembros, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> publicaciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN lider, bool completo, bool aceptaMiembros
               )
{
        this.init (Nombre, imagen, descripcion, miembros, publicaciones, invitaciones, lider, completo, aceptaMiembros);
}


public GrupoEN(GrupoEN grupo)
{
        this.init (Nombre, grupo.Imagen, grupo.Descripcion, grupo.Miembros, grupo.Publicaciones, grupo.Invitaciones, grupo.Lider, grupo.Completo, grupo.AceptaMiembros);
}

private void init (string nombre
                   , string imagen, string descripcion, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> miembros, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> publicaciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN lider, bool completo, bool aceptaMiembros)
{
        this.Nombre = nombre;


        this.Imagen = imagen;

        this.Descripcion = descripcion;

        this.Miembros = miembros;

        this.Publicaciones = publicaciones;

        this.Invitaciones = invitaciones;

        this.Lider = lider;

        this.Completo = completo;

        this.AceptaMiembros = aceptaMiembros;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GrupoEN t = obj as GrupoEN;
        if (t == null)
                return false;
        if (Nombre.Equals (t.Nombre))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nombre.GetHashCode ();
        return hash;
}
}
}
