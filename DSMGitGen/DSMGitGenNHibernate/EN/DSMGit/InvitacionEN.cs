
using System;
// Definición clase InvitacionEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class InvitacionEN
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
 *	Atributo grupo
 */
private DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo;



/**
 *	Atributo invitador
 */
private DSMGitGenNHibernate.EN.DSMGit.UsuarioEN invitador;



/**
 *	Atributo usuario_invitado
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> usuario_invitado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.GrupoEN Grupo {
        get { return grupo; } set { grupo = value;  }
}



public virtual DSMGitGenNHibernate.EN.DSMGit.UsuarioEN Invitador {
        get { return invitador; } set { invitador = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> Usuario_invitado {
        get { return usuario_invitado; } set { usuario_invitado = value;  }
}





public InvitacionEN()
{
        usuario_invitado = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
}



public InvitacionEN(int id, string descripcion, DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN invitador, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> usuario_invitado
                    )
{
        this.init (Id, descripcion, grupo, invitador, usuario_invitado);
}


public InvitacionEN(InvitacionEN invitacion)
{
        this.init (Id, invitacion.Descripcion, invitacion.Grupo, invitacion.Invitador, invitacion.Usuario_invitado);
}

private void init (int id
                   , string descripcion, DSMGitGenNHibernate.EN.DSMGit.GrupoEN grupo, DSMGitGenNHibernate.EN.DSMGit.UsuarioEN invitador, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> usuario_invitado)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Grupo = grupo;

        this.Invitador = invitador;

        this.Usuario_invitado = usuario_invitado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        InvitacionEN t = obj as InvitacionEN;
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
