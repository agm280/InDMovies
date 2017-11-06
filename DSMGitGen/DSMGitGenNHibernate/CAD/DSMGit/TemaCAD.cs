
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
 * Clase Tema:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class TemaCAD : BasicCAD, ITemaCAD
{
public TemaCAD() : base ()
{
}

public TemaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TemaEN ReadOIDDefault (int id
                              )
{
        TemaEN temaEN = null;

        try
        {
                SessionInitializeTransaction ();
                temaEN = (TemaEN)session.Get (typeof(TemaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return temaEN;
}

public System.Collections.Generic.IList<TemaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TemaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TemaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TemaEN>();
                        else
                                result = session.CreateCriteria (typeof(TemaEN)).List<TemaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TemaEN tema)
{
        try
        {
                SessionInitializeTransaction ();
                TemaEN temaEN = (TemaEN)session.Load (typeof(TemaEN), tema.Id);

                temaEN.Descripcion = tema.Descripcion;



                temaEN.Estado = tema.Estado;



                temaEN.Titulo = tema.Titulo;


                temaEN.Etiquetas = tema.Etiquetas;

                session.Update (temaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (TemaEN tema)
{
        try
        {
                SessionInitializeTransaction ();
                if (tema.Usuario != null) {
                        // Argumento OID y no colección.
                        tema.Usuario = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), tema.Usuario.Email);

                        tema.Usuario.Temas
                        .Add (tema);
                }

                session.Save (tema);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tema.Id;
}

public void Modify (TemaEN tema)
{
        try
        {
                SessionInitializeTransaction ();
                TemaEN temaEN = (TemaEN)session.Load (typeof(TemaEN), tema.Id);

                temaEN.Descripcion = tema.Descripcion;


                temaEN.Estado = tema.Estado;


                temaEN.Titulo = tema.Titulo;

                session.Update (temaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
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
                TemaEN temaEN = (TemaEN)session.Load (typeof(TemaEN), id);
                session.Delete (temaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TemaEN
public TemaEN ReadOID (int id
                       )
{
        TemaEN temaEN = null;

        try
        {
                SessionInitializeTransaction ();
                temaEN = (TemaEN)session.Get (typeof(TemaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return temaEN;
}

public System.Collections.Generic.IList<TemaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TemaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TemaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TemaEN>();
                else
                        result = session.CreateCriteria (typeof(TemaEN)).List<TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasAbiertos ()
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Estado=abierto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemasAbiertosHQL");

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemasCerrados ()
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Estado=cerrado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemasCerradosHQL");

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorNick (string p_nick)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Usuario.Nick like '%:p_nick%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemaPorNickHQL");
                query.SetParameter ("p_nick", p_nick);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Usuario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemaPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorDesc (string p_desc)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Descripcion LIKE '%:p_desc%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemaPorDescHQL");
                query.SetParameter ("p_desc", p_desc);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> DameTemaPorTitulo (string p_titulo)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.TemaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM TemaEN self where FROM TemaEN as tem WHERE tem.Titulo LIKE '%:p_titulo%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("TemaENdameTemaPorTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.TemaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in TemaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
