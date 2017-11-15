
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ComentarioEN> DameComentarioPorVideoID (int ? p_id);
}
}
