
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface ISugerenciaCAD
{
SugerenciaEN ReadOIDDefault (int id
                             );

void ModifyDefault (SugerenciaEN sugerencia);



int New_ (SugerenciaEN sugerencia);

void Modify (SugerenciaEN sugerencia);


void Destroy (int id
              );


SugerenciaEN ReadOID (int id
                      );


System.Collections.Generic.IList<SugerenciaEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> DameSugerenciaPorEmail (string p_email);
}
}
