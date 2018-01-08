
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
 * Clase Busqueda:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class BusquedaCAD : BasicCAD, IBusquedaCAD
{
public BusquedaCAD() : base ()
{
}

public BusquedaCAD(ISession sessionAux) : base (sessionAux)
{
}



public BusquedaEN ReadOIDDefault (int id
                                  )
{
        BusquedaEN busquedaEN = null;

        try
        {
                SessionInitializeTransaction ();
                busquedaEN = (BusquedaEN)session.Get (typeof(BusquedaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return busquedaEN;
}

public System.Collections.Generic.IList<BusquedaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BusquedaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BusquedaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<BusquedaEN>();
                        else
                                result = session.CreateCriteria (typeof(BusquedaEN)).List<BusquedaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (BusquedaEN busqueda)
{
        try
        {
                SessionInitializeTransaction ();
                BusquedaEN busquedaEN = (BusquedaEN)session.Load (typeof(BusquedaEN), busqueda.Id);

                busquedaEN.Texto = busqueda.Texto;

                session.Update (busquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (BusquedaEN busqueda)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (busqueda);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return busqueda.Id;
}

public void Modify (BusquedaEN busqueda)
{
        try
        {
                SessionInitializeTransaction ();
                BusquedaEN busquedaEN = (BusquedaEN)session.Load (typeof(BusquedaEN), busqueda.Id);

                busquedaEN.Texto = busqueda.Texto;

                session.Update (busquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
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
                BusquedaEN busquedaEN = (BusquedaEN)session.Load (typeof(BusquedaEN), id);
                session.Delete (busquedaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: BusquedaEN
public BusquedaEN ReadOID (int id
                           )
{
        BusquedaEN busquedaEN = null;

        try
        {
                SessionInitializeTransaction ();
                busquedaEN = (BusquedaEN)session.Get (typeof(BusquedaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return busquedaEN;
}

public System.Collections.Generic.IList<BusquedaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BusquedaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(BusquedaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<BusquedaEN>();
                else
                        result = session.CreateCriteria (typeof(BusquedaEN)).List<BusquedaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in BusquedaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
