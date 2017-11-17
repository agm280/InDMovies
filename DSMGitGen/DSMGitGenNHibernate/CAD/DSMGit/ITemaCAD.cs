
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface ITemaCAD
{
TemaEN ReadOIDDefault (int id
                       );

void ModifyDefault (TemaEN tema);



int New_ (TemaEN tema);

void Modify (TemaEN tema);


void Destroy (int id
              );


TemaEN ReadOID (int id
                );


System.Collections.Generic.IList<TemaEN> ReadAll (int first, int size);




System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasAbiertos ();


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasCerrados ();


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorNick (string p_nick);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorEmail (string p_email);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorDesc (string p_desc);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorTitulo (string p_titulo);
}
}
