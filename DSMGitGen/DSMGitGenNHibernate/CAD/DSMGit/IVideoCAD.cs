
using System;
using DSMGitGenNHibernate.EN.DSMGit;

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial interface IVideoCAD
{
VideoEN ReadOIDDefault (int id
                        );

void ModifyDefault (VideoEN video);



int New_ (VideoEN video);

void Modify (VideoEN video);


void Destroy (int id
              );


VideoEN ReadOID (int id
                 );


System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size);



System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorTitulo (string p_titulo);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorNick (string p_nick);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorFecha (int? p_anyo, int? p_mes, int ? p_dia);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorEmail (string p_email);


System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorDescripcion (string p_descripcion);
}
}
