
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
 * Clase Sugerencia:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class SugerenciaCAD : BasicCAD, ISugerenciaCAD
{
public SugerenciaCAD() : base ()
{
}

public SugerenciaCAD(ISession sessionAux) : base (sessionAux)
{
}



public SugerenciaEN ReadOIDDefault (int id
                                    )
{
        SugerenciaEN sugerenciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                sugerenciaEN = (SugerenciaEN)session.Get (typeof(SugerenciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sugerenciaEN;
}

public System.Collections.Generic.IList<SugerenciaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SugerenciaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SugerenciaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SugerenciaEN>();
                        else
                                result = session.CreateCriteria (typeof(SugerenciaEN)).List<SugerenciaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SugerenciaEN sugerencia)
{
        try
        {
                SessionInitializeTransaction ();
                SugerenciaEN sugerenciaEN = (SugerenciaEN)session.Load (typeof(SugerenciaEN), sugerencia.Id);

                sugerenciaEN.Titulo = sugerencia.Titulo;


                sugerenciaEN.Descripcion = sugerencia.Descripcion;


                session.Update (sugerenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SugerenciaEN sugerencia)
{
        try
        {
                SessionInitializeTransaction ();
                if (sugerencia.Usuario != null) {
                        // Argumento OID y no colección.
                        sugerencia.Usuario = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), sugerencia.Usuario.Email);

                        sugerencia.Usuario.Sugerencias
                        .Add (sugerencia);
                }

                session.Save (sugerencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sugerencia.Id;
}

public void Modify (SugerenciaEN sugerencia)
{
        try
        {
                SessionInitializeTransaction ();
                SugerenciaEN sugerenciaEN = (SugerenciaEN)session.Load (typeof(SugerenciaEN), sugerencia.Id);

                sugerenciaEN.Titulo = sugerencia.Titulo;


                sugerenciaEN.Descripcion = sugerencia.Descripcion;

                session.Update (sugerenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
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
                SugerenciaEN sugerenciaEN = (SugerenciaEN)session.Load (typeof(SugerenciaEN), id);
                session.Delete (sugerenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: SugerenciaEN
public SugerenciaEN ReadOID (int id
                             )
{
        SugerenciaEN sugerenciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                sugerenciaEN = (SugerenciaEN)session.Get (typeof(SugerenciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sugerenciaEN;
}

public System.Collections.Generic.IList<SugerenciaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SugerenciaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SugerenciaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SugerenciaEN>();
                else
                        result = session.CreateCriteria (typeof(SugerenciaEN)).List<SugerenciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> DameSugerenciaPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SugerenciaEN self where FROM SugerenciaEN as sug WHERE sug.Usuario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SugerenciaENdameSugerenciaPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.SugerenciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in SugerenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
