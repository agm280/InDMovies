
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IInvitacionCAD
{
InvitacionEN ReadOIDDefault (int id
                             );

void ModifyDefault (InvitacionEN invitacion);



int New_ (InvitacionEN invitacion);

void Modify (InvitacionEN invitacion);


void Destroy (int id
              );


InvitacionEN ReadOID (int id
                      );


System.Collections.Generic.IList<InvitacionEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorEmail (string p_email);


void MeterUsuario (int p_Invitacion_OID, System.Collections.Generic.IList<string> p_usuario_invitado_OIDs);

System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorGrupo (string p_grupo);




void QuitarInvitado (int p_Invitacion_OID, System.Collections.Generic.IList<string> p_usuario_invitado_OIDs);

System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionRecibidaPorEmail (string p_email);
}
}
