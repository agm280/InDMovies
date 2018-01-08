
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IValoracionCAD
{
ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);



int New_ (ValoracionEN valoracion);

void Modify (ValoracionEN valoracion);


void Destroy (int id
              );


ValoracionEN ReadOID (int id
                      );


System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> DameValoracionPorVideoID (int ? p_id);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> DameValoracionPorEmail (string user);
}
}
