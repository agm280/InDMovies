
using System;
using System.Text;
using DSMGitGenNHibernate.CEN.DSMGit;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.Exceptions;


/*
 * Clase Respuesta:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class RespuestaCAD : BasicCAD, IRespuestaCAD
{
public RespuestaCAD() : base ()
{
}

public RespuestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RespuestaEN ReadOIDDefault (int id
                                   )
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RespuestaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RespuestaEN>();
                        else
                                result = session.CreateCriteria (typeof(RespuestaEN)).List<RespuestaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), respuesta.Id);

                respuestaEN.Descripcion = respuesta.Descripcion;




                respuestaEN.Fecha = respuesta.Fecha;

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (respuesta.Tema != null) {
                        // Argumento OID y no colección.
                        respuesta.Tema = (DSMGitGenNHibernate.EN.DSMGit.TemaEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.TemaEN), respuesta.Tema.Id);

                        respuesta.Tema.Respuestas
                        .Add (respuesta);
                }
                if (respuesta.Usuario != null) {
                        // Argumento OID y no colección.
                        respuesta.Usuario = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), respuesta.Usuario.Email);

                        respuesta.Usuario.Respuestas
                        .Add (respuesta);
                }

                session.Save (respuesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuesta.Id;
}

public void Modify (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), respuesta.Id);

                respuestaEN.Descripcion = respuesta.Descripcion;


                respuestaEN.Fecha = respuesta.Fecha;

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), id);
                session.Delete (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RespuestaEN
public RespuestaEN ReadOID (int id
                            )
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}

public System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RespuestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RespuestaEN>();
                else
                        result = session.CreateCriteria (typeof(RespuestaEN)).List<RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorTema (int ? p_id)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as res WHERE res.Tema.Id=:p_id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENdameRespuestaPorTemaHQL");
                query.SetParameter ("p_id", p_id);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as res WHERE res.Usuario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENdameRespuestaPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorNick (string p_nick)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as res WHERE res.Usuario.Nick LIKE ('%'+:p_nick+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENdameRespuestaPorNickHQL");
                query.SetParameter ("p_nick", p_nick);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> DameRespuestaPorTemaTitulo (string p_titulo)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where FROM RespuestaEN as res WHERE res.Tema.Titulo=:p_titulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENdameRespuestaPorTemaTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
