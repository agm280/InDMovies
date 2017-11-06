
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
 * Clase Publicacion:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class PublicacionCAD : BasicCAD, IPublicacionCAD
{
public PublicacionCAD() : base ()
{
}

public PublicacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public PublicacionEN ReadOIDDefault (int id
                                     )
{
        PublicacionEN publicacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                publicacionEN = (PublicacionEN)session.Get (typeof(PublicacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicacionEN;
}

public System.Collections.Generic.IList<PublicacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PublicacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PublicacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PublicacionEN>();
                        else
                                result = session.CreateCriteria (typeof(PublicacionEN)).List<PublicacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), publicacion.Id);

                publicacionEN.Titulo = publicacion.Titulo;


                publicacionEN.Fecha = publicacion.Fecha;


                publicacionEN.Imagen = publicacion.Imagen;


                session.Update (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (publicacion.Grupo != null) {
                        // Argumento OID y no colección.
                        publicacion.Grupo = (DSMGitGenNHibernate.EN.DSMGit.GrupoEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.GrupoEN), publicacion.Grupo.Nombre);

                        publicacion.Grupo.Publicaciones
                        .Add (publicacion);
                }

                session.Save (publicacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicacion.Id;
}

public void Modify (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), publicacion.Id);

                publicacionEN.Titulo = publicacion.Titulo;


                publicacionEN.Fecha = publicacion.Fecha;


                publicacionEN.Imagen = publicacion.Imagen;

                session.Update (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
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
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), id);
                session.Delete (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PublicacionEN
public PublicacionEN ReadOID (int id
                              )
{
        PublicacionEN publicacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                publicacionEN = (PublicacionEN)session.Get (typeof(PublicacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicacionEN;
}

public System.Collections.Generic.IList<PublicacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PublicacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PublicacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PublicacionEN>();
                else
                        result = session.CreateCriteria (typeof(PublicacionEN)).List<PublicacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> DamePublicacionesDelGrupo (string p_nombre)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PublicacionEN self where FROM PublicacionEN as pub WHERE pub.Grupo.Nombre=:p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PublicacionENdamePublicacionesDelGrupoHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.PublicacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
