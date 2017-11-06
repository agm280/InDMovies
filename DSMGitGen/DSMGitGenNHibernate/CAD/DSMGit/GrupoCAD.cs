
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
 * Clase Grupo:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class GrupoCAD : BasicCAD, IGrupoCAD
{
public GrupoCAD() : base ()
{
}

public GrupoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GrupoEN ReadOIDDefault (string nombre
                               )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GrupoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                        else
                                result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Nombre);

                grupoEN.Imagen = grupo.Imagen;


                grupoEN.Descripcion = grupo.Descripcion;






                grupoEN.Completo = grupo.Completo;

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                if (grupo.Miembros != null) {
                        for (int i = 0; i < grupo.Miembros.Count; i++) {
                                grupo.Miembros [i] = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), grupo.Miembros [i].Email);
                                grupo.Miembros [i].Grupos.Add (grupo);
                        }
                }
                if (grupo.Lider != null) {
                        // Argumento OID y no colección.
                        grupo.Lider = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), grupo.Lider.Email);

                        grupo.Lider.Grupos_lidera
                        .Add (grupo);
                }

                session.Save (grupo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupo.Nombre;
}

public void Modify (GrupoEN grupo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), grupo.Nombre);

                grupoEN.Imagen = grupo.Imagen;


                grupoEN.Descripcion = grupo.Descripcion;


                grupoEN.Completo = grupo.Completo;

                session.Update (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string nombre
                     )
{
        try
        {
                SessionInitializeTransaction ();
                GrupoEN grupoEN = (GrupoEN)session.Load (typeof(GrupoEN), nombre);
                session.Delete (grupoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: GrupoEN
public GrupoEN ReadOID (string nombre
                        )
{
        GrupoEN grupoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoEN = (GrupoEN)session.Get (typeof(GrupoEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoEN;
}

public System.Collections.Generic.IList<GrupoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GrupoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GrupoEN>();
                else
                        result = session.CreateCriteria (typeof(GrupoEN)).List<GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposNoLlenos ()
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Completo=false";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposNoLlenosHQL");

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLlenos ()
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Completo=true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposLlenosHQL");

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorNick (string p_nick)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Lider.Nick LIKE '%:p_nick%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposLideradosPorNickHQL");
                query.SetParameter ("p_nick", p_nick);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposLideradosPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Lider.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposLideradosPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Nombre LIKE '%:p_nombre%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> DameGruposPorDesc (string p_desc)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.GrupoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoEN self where FROM GrupoEN as gru WHERE gru.Descripcion LIKE '%:p_desc%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoENdameGruposPorDescHQL");
                query.SetParameter ("p_desc", p_desc);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.GrupoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in GrupoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
