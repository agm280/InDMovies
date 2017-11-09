

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
 *      Definition of the class RespuestaCEN
 *
 */
public partial class RespuestaCEN
{
private IRespuestaCAD _IRespuestaCAD;

public RespuestaCEN()
{
        this._IRespuestaCAD = new RespuestaCAD ();
}

public RespuestaCEN(IRespuestaCAD _IRespuestaCAD)
{
        this._IRespuestaCAD = _IRespuestaCAD;
}

public IRespuestaCAD get_IRespuestaCAD ()
{
        return this._IRespuestaCAD;
}

public int New_ (string p_descripcion, int p_tema, string p_usuario)
{
        RespuestaEN respuestaEN = null;
        int oid;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Descripcion = p_descripcion;


        if (p_tema != -1) {
                // El argumento p_tema -> Property tema es oid = false
                // Lista de oids id
                respuestaEN.Tema = new DSMGitGenNHibernate.EN.DSMGit.TemaEN ();
                respuestaEN.Tema.Id = p_tema;
        }


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                respuestaEN.Usuario = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                respuestaEN.Usuario.Email = p_usuario;
        }

        //Call to RespuestaCAD

        oid = _IRespuestaCAD.New_ (respuestaEN);
        return oid;
}

public void Modify (int p_Respuesta_OID, string p_descripcion)
{
        RespuestaEN respuestaEN = null;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Id = p_Respuesta_OID;
        respuestaEN.Descripcion = p_descripcion;
        //Call to RespuestaCAD

        _IRespuestaCAD.Modify (respuestaEN);
}

public void Destroy (int id
                     )
{
        _IRespuestaCAD.Destroy (id);
}

public RespuestaEN ReadOID (int id
                            )
{
        RespuestaEN respuestaEN = null;

        respuestaEN = _IRespuestaCAD.ReadOID (id);
        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> list = null;

        list = _IRespuestaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorTema (int ? p_id)
{
        return _IRespuestaCAD.DameRespuestaPorTema (p_id);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorEmail (string p_email)
{
        return _IRespuestaCAD.DameRespuestaPorEmail (p_email);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorNick (string p_nick)
{
        return _IRespuestaCAD.DameRespuestaPorNick (p_nick);
}
}
}
