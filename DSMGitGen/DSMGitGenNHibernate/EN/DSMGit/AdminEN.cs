
using System;
// Definición clase AdminEN
namespace DSMGitGenNHibernate.EN.DSMGit
{
public partial class AdminEN                                                                        : DSMGitGenNHibernate.EN.DSMGit.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(string email,
               string nombre, string apellidos, string nick, String contrasenya, Nullable<DateTime> fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum rol, string imagen, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> notificaciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> sugerencias, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> grupos_lidera, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_enviadas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> videos, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> valoraciones, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> invitaciones_recibidas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> comentarios, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> temas, System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> respuestas, string descripcion
               )
{
        this.init (Email, nombre, apellidos, nick, contrasenya, fecha_nac, rol, imagen, notificaciones, sugerencias, grupos, grupos_lidera, invitaciones_enviadas, videos, valoraciones, invitaciones_recibidas, comentarios, temas, respuestas, descripcion);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Nombre, admin.Apellidos, admin.Nick, admin.Contrasenya, admin.Fecha_nac, admin.Rol, admin.Imagen, admin.Notificaciones, admin.Sugerencias, admin.Grupos, admin.Grupos_lidera, admin.Invitaciones_enviadas, admin.Videos, admin.Valoraciones, admin.Invitaciones_recibidas, admin.Comentarios, admin.Temas, admin.Respuestas, admin.Descripcion);
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
        AdminEN t = obj as AdminEN;
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
