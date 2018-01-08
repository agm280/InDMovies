

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;

using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


namespace DSMGitGenNHibernate.CEN.DSMGit
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public int New_ (int p_valor, string p_usuario, int p_video)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Valor = p_valor;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                valoracionEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                valoracionEN.Usuario.Email = p_usuario;
        }


        if (p_video != -1) {
                // El argumento p_video -> Property video es oid = false
                // Lista de oids id
                valoracionEN.Video = new DSMGitGenNHibernate.EN.DSMGit.VideoEN ();
                valoracionEN.Video.Id = p_video;
        }

        //Call to ValoracionCAD

        oid = _IValoracionCAD.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, int p_valor)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Valor = p_valor;
        //Call to ValoracionCAD

        _IValoracionCAD.Modify (valoracionEN);
}

public void Destroy (int id
                     )
{
        _IValoracionCAD.Destroy (id);
}

public ValoracionEN ReadOID (int id
                             )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionCAD.ReadOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> DameValoracionPorVideoID (int ? p_id)
{
        return _IValoracionCAD.DameValoracionPorVideoID (p_id);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.ValoracionEN> DameValoracionPorEmail (string user)
{
        return _IValoracionCAD.DameValoracionPorEmail (user);
}
}
}
