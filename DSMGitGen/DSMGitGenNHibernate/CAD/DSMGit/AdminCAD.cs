
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
 * Clase Admin:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class AdminCAD : BasicCAD, IAdminCAD
{
public AdminCAD() : base ()
{
}

public AdminCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdminEN ReadOIDDefault (string email
                               )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdminEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                        else
                                result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Email);
                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (admin);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return admin.Email;
}

public void Modify (AdminEN admin)
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), admin.Email);

                adminEN.Nombre = admin.Nombre;


                adminEN.Apellidos = admin.Apellidos;


                adminEN.Nick = admin.Nick;


                adminEN.Contrasenya = admin.Contrasenya;


                adminEN.Fecha_nac = admin.Fecha_nac;


                adminEN.Rol = admin.Rol;


                adminEN.Imagen = admin.Imagen;


                adminEN.Descripcion = admin.Descripcion;

                session.Update (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                AdminEN adminEN = (AdminEN)session.Load (typeof(AdminEN), email);
                session.Delete (adminEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AdminEN
public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        try
        {
                SessionInitializeTransaction ();
                adminEN = (AdminEN)session.Get (typeof(AdminEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdminEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdminEN>();
                else
                        result = session.CreateCriteria (typeof(AdminEN)).List<AdminEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in AdminCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
