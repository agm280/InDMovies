
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface ISugerenciaCAD
{
SugerenciaEN ReadOIDDefault (string id
                             );

void ModifyDefault (SugerenciaEN sugerencia);



string New_ (SugerenciaEN sugerencia);

void Modify (SugerenciaEN sugerencia);


void Destroy (string id
              );


SugerenciaEN ReadOID (string id
                      );


System.Collections.Generic.IList<SugerenciaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> DameSugerenciaPorEmail (string p_email);
}
}
