
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );




UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);




System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNick (string p_nick);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorEmail (string p_email);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNombreYApellidos (string p_nombre, string p_apellidos);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorRol (int ? p_rol);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorDescripcion (string p_descripcion);




System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNombreOApellidos (string p_nombre, string p_apellidos);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorGrupo (string p_nombre);
}
}
