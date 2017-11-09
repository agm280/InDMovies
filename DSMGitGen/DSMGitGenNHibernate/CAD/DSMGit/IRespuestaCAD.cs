
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IRespuestaCAD
{
RespuestaEN ReadOIDDefault (int id
                            );

void ModifyDefault (RespuestaEN respuesta);



int New_ (RespuestaEN respuesta);

void Modify (RespuestaEN respuesta);


void Destroy (int id
              );


RespuestaEN ReadOID (int id
                     );


System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorTema (int ? p_id);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorEmail (string p_email);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorNick (string p_nick);
}
}
