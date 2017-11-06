
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (string id
                               );

void ModifyDefault (NotificacionEN notificacion);



string New_ (NotificacionEN notificacion);

void Modify (NotificacionEN notificacion);


void Destroy (string id
              );


NotificacionEN ReadOID (string id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.NotificacionEN> DameNotificacionPorEmail (string p_email);
}
}
