
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IPublicacionCAD
{
PublicacionEN ReadOIDDefault (int id
                              );

void ModifyDefault (PublicacionEN publicacion);



int New_ (PublicacionEN publicacion);

void Modify (PublicacionEN publicacion);


void Destroy (int id
              );


PublicacionEN ReadOID (int id
                       );


System.Collections.Generic.IList<PublicacionEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> DamePublicacionesDelGrupo (string p_nombre);
}
}
