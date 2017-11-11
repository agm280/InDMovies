
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IGrupoCAD
{
GrupoEN ReadOIDDefault (string nombre
                        );

void ModifyDefault (GrupoEN grupo);



string New_ (GrupoEN grupo);

void Modify (GrupoEN grupo);


void Destroy (string nombre
              );


GrupoEN ReadOID (string nombre
                 );


System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size);



System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposNoLlenos ();


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLlenos ();


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorNick (string p_nick);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorEmail (string p_email);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorNombre (string p_nombre);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorDesc (string p_desc);


void MeterUsuario (string p_Grupo_OID, System.Collections.Generic.IList<string> p_miembros_OIDs);

void SacarUsuario (string p_Grupo_OID, System.Collections.Generic.IList<string> p_miembros_OIDs);
}
}
