
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IBusquedaCAD
{
BusquedaEN ReadOIDDefault (int id
                           );

void ModifyDefault (BusquedaEN busqueda);



int New_ (BusquedaEN busqueda);

void Modify (BusquedaEN busqueda);


void Destroy (int id
              );


BusquedaEN ReadOID (int id
                    );


System.Collections.Generic.IList<BusquedaEN> ReadAll (int first, int size);
}
}
