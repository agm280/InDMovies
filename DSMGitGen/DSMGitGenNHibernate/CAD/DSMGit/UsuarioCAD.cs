
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
 * Clase Usuario:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Contrasenya = usuario.Contrasenya;


                usuarioEN.Fecha_nac = usuario.Fecha_nac;


                usuarioEN.Rol = usuario.Rol;


                usuarioEN.Imagen = usuario.Imagen;













                usuarioEN.Descripcion = usuario.Descripcion;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Email;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Contrasenya = usuario.Contrasenya;


                usuarioEN.Fecha_nac = usuario.Fecha_nac;


                usuarioEN.Rol = usuario.Rol;


                usuarioEN.Imagen = usuario.Imagen;


                usuarioEN.Descripcion = usuario.Descripcion;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), email);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNick (string p_nick)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE usu.Nick like('%'+:p_nick+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorNickHQL");
                query.SetParameter ("p_nick", p_nick);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE usu.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNombreYApellidos (string p_nombre, string p_apellidos)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE usu.Nombre LIKE ('%'+:p_nombre+'%') AND usu.Apellidos LIKE ('%'+:p_apellidos+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorNombreYApellidosHQL");
                query.SetParameter ("p_nombre", p_nombre);
                query.SetParameter ("p_apellidos", p_apellidos);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorRol (int ? p_rol)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE usu.Rol=:p_rol";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorRolHQL");
                query.SetParameter ("p_rol", p_rol);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorDescripcion (string p_descripcion)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN as usu WHERE usu.Descripcion LIKE ('%'+:p_descripcion+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuarioPorDescripcionHQL");
                query.SetParameter ("p_descripcion", p_descripcion);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
