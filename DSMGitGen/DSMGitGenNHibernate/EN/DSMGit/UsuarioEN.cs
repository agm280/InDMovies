
using System;
// Definición clase UsuarioEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nick
 */
private string nick;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo fecha_nac
 */
private Nullable<DateTime> fecha_nac;



/**
 *	Atributo rol
 */
private DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum rol;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo notificaciones
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> notificaciones;



/**
 *	Atributo sugerencias
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> sugerencias;



/**
 *	Atributo grupos
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos;



/**
 *	Atributo grupos_lidera
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos_lidera;



/**
 *	Atributo invitaciones_enviadas
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_enviadas;



/**
 *	Atributo videos
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> videos;



/**
 *	Atributo valoraciones
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones;



/**
 *	Atributo invitaciones_recibidas
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_recibidas;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios;



/**
 *	Atributo temas
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> temas;



/**
 *	Atributo respuestas
 */
private System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas;



/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Nick {
        get { return nick; } set { nick = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual Nullable<DateTime> Fecha_nac {
        get { return fecha_nac; } set { fecha_nac = value;  }
}



public virtual DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum Rol {
        get { return rol; } set { rol = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> Sugerencias {
        get { return sugerencias; } set { sugerencias = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> Grupos {
        get { return grupos; } set { grupos = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> Grupos_lidera {
        get { return grupos_lidera; } set { grupos_lidera = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> Invitaciones_enviadas {
        get { return invitaciones_enviadas; } set { invitaciones_enviadas = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> Videos {
        get { return videos; } set { videos = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> Valoraciones {
        get { return valoraciones; } set { valoraciones = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> Invitaciones_recibidas {
        get { return invitaciones_recibidas; } set { invitaciones_recibidas = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> Temas {
        get { return temas; } set { temas = value;  }
}



public virtual System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public UsuarioEN()
{
        notificaciones = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN>();
        sugerencias = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN>();
        grupos = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
        grupos_lidera = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
        invitaciones_enviadas = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN>();
        videos = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
        valoraciones = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN>();
        invitaciones_recibidas = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN>();
        comentarios = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN>();
        temas = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
        respuestas = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
}



public UsuarioEN(string email, string nombre, string apellidos, string nick, String contrasenya, Nullable<DateTime> fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum rol, string imagen, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> notificaciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> sugerencias, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos_lidera, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_enviadas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> videos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_recibidas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> temas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas, string descripcion
                 )
{
        this.init (Email, nombre, apellidos, nick, contrasenya, fecha_nac, rol, imagen, notificaciones, sugerencias, grupos, grupos_lidera, invitaciones_enviadas, videos, valoraciones, invitaciones_recibidas, comentarios, temas, respuestas, descripcion);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Nombre, usuario.Apellidos, usuario.Nick, usuario.Contrasenya, usuario.Fecha_nac, usuario.Rol, usuario.Imagen, usuario.Notificaciones, usuario.Sugerencias, usuario.Grupos, usuario.Grupos_lidera, usuario.Invitaciones_enviadas, usuario.Videos, usuario.Valoraciones, usuario.Invitaciones_recibidas, usuario.Comentarios, usuario.Temas, usuario.Respuestas, usuario.Descripcion);
}

private void init (string email
                   , string nombre, string apellidos, string nick, String contrasenya, Nullable<DateTime> fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum rol, string imagen, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> notificaciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> sugerencias, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos_lidera, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_enviadas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> videos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_recibidas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> temas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas, string descripcion)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Nick = nick;

        this.Contrasenya = contrasenya;

        this.Fecha_nac = fecha_nac;

        this.Rol = rol;

        this.Imagen = imagen;

        this.Notificaciones = notificaciones;

        this.Sugerencias = sugerencias;

        this.Grupos = grupos;

        this.Grupos_lidera = grupos_lidera;

        this.Invitaciones_enviadas = invitaciones_enviadas;

        this.Videos = videos;

        this.Valoraciones = valoraciones;

        this.Invitaciones_recibidas = invitaciones_recibidas;

        this.Comentarios = comentarios;

        this.Temas = temas;

        this.Respuestas = respuestas;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
