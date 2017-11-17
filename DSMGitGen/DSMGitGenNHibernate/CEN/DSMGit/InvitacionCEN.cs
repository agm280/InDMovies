

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;

using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


namespace DSMGitGenNHibernate.CEN.DSMGit
{
/*
 *      Definition of the class InvitacionCEN
 *
 */
public partial class InvitacionCEN
{
private IInvitacionCAD _IInvitacionCAD;

public InvitacionCEN()
{
        this._IInvitacionCAD = new InvitacionCAD ();
}

public InvitacionCEN(IInvitacionCAD _IInvitacionCAD)
{
        this._IInvitacionCAD = _IInvitacionCAD;
}

public IInvitacionCAD get_IInvitacionCAD ()
{
        return this._IInvitacionCAD;
}

public int New_ (string p_descripcion, string p_grupo, string p_invitador)
{
        InvitacionEN invitacionEN = null;
        int oid;

        //Initialized InvitacionEN
        invitacionEN = new InvitacionEN ();
        invitacionEN.Descripcion = p_descripcion;


        if (p_grupo != null) {
                // El argumento p_grupo -> Property grupo es oid = false
                // Lista de oids id
                invitacionEN.Grupo = new DSMGitGenNHibernate.EN.DSMGit.GrupoEN ();
                invitacionEN.Grupo.Nombre = p_grupo;
        }


        if (p_invitador != null) {
                // El argumento p_invitador -> Property invitador es oid = false
                // Lista de oids id
                invitacionEN.Invitador = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                invitacionEN.Invitador.Email = p_invitador;
        }

        //Call to InvitacionCAD

        oid = _IInvitacionCAD.New_ (invitacionEN);
        return oid;
}

public void Modify (int p_Invitacion_OID, string p_descripcion)
{
        InvitacionEN invitacionEN = null;

        //Initialized InvitacionEN
        invitacionEN = new InvitacionEN ();
        invitacionEN.Id = p_Invitacion_OID;
        invitacionEN.Descripcion = p_descripcion;
        //Call to InvitacionCAD

        _IInvitacionCAD.Modify (invitacionEN);
}

public void Destroy (int id
                     )
{
        _IInvitacionCAD.Destroy (id);
}

public InvitacionEN ReadOID (int id
                             )
{
        InvitacionEN invitacionEN = null;

        invitacionEN = _IInvitacionCAD.ReadOID (id);
        return invitacionEN;
}

public System.Collections.Generic.IList<InvitacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<InvitacionEN> list = null;

        list = _IInvitacionCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorEmail (string p_email)
{
        return _IInvitacionCAD.DameInvitacionEnviadaPorEmail (p_email);
}
public void MeterUsuario (int p_Invitacion_OID, System.Collections.Generic.IList<string> p_usuario_invitado_OIDs)
{
        //Call to InvitacionCAD

        _IInvitacionCAD.MeterUsuario (p_Invitacion_OID, p_usuario_invitado_OIDs);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorGrupo (string p_grupo)
{
        return _IInvitacionCAD.DameInvitacionEnviadaPorGrupo (p_grupo);
}
public void QuitarInvitado (int p_Invitacion_OID, System.Collections.Generic.IList<string> p_usuario_invitado_OIDs)
{
        //Call to InvitacionCAD

        _IInvitacionCAD.QuitarInvitado (p_Invitacion_OID, p_usuario_invitado_OIDs);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionRecibidaPorEmail (string p_email)
{
        return _IInvitacionCAD.DameInvitacionRecibidaPorEmail (p_email);
}
public void QuitarGrupo (int p_Invitacion_OID, string p_grupo_OID)
{
        //Call to InvitacionCAD

        _IInvitacionCAD.QuitarGrupo (p_Invitacion_OID, p_grupo_OID);
}
public void QuitarInvitador (int p_Invitacion_OID, string p_invitador_OID)
{
        //Call to InvitacionCAD

        _IInvitacionCAD.QuitarInvitador (p_Invitacion_OID, p_invitador_OID);
}
}
}
