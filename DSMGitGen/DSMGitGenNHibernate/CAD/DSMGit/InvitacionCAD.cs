
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
 * Clase Invitacion:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class InvitacionCAD : BasicCAD, IInvitacionCAD
{
public InvitacionCAD() : base ()
{
}

public InvitacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public InvitacionEN ReadOIDDefault (int id
                                    )
{
        InvitacionEN invitacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                invitacionEN = (InvitacionEN)session.Get (typeof(InvitacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return invitacionEN;
}

public System.Collections.Generic.IList<InvitacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<InvitacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(InvitacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<InvitacionEN>();
                        else
                                result = session.CreateCriteria (typeof(InvitacionEN)).List<InvitacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (InvitacionEN invitacion)
{
        try
        {
                SessionInitializeTransaction ();
                InvitacionEN invitacionEN = (InvitacionEN)session.Load (typeof(InvitacionEN), invitacion.Id);

                invitacionEN.Descripcion = invitacion.Descripcion;




                session.Update (invitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (InvitacionEN invitacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (invitacion.Grupo != null) {
                        // Argumento OID y no colección.
                        invitacion.Grupo = (DSMGitGenNHibernate.EN.DSMGit.GrupoEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.GrupoEN), invitacion.Grupo.Nombre);

                        invitacion.Grupo.Invitaciones
                        .Add (invitacion);
                }
                if (invitacion.Invitador != null) {
                        // Argumento OID y no colección.
                        invitacion.Invitador = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), invitacion.Invitador.Email);

                        invitacion.Invitador.Invitaciones_enviadas
                        .Add (invitacion);
                }

                session.Save (invitacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return invitacion.Id;
}

public void Modify (InvitacionEN invitacion)
{
        try
        {
                SessionInitializeTransaction ();
                InvitacionEN invitacionEN = (InvitacionEN)session.Load (typeof(InvitacionEN), invitacion.Id);

                invitacionEN.Descripcion = invitacion.Descripcion;

                session.Update (invitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
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
                InvitacionEN invitacionEN = (InvitacionEN)session.Load (typeof(InvitacionEN), id);
                session.Delete (invitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: InvitacionEN
public InvitacionEN ReadOID (int id
                             )
{
        InvitacionEN invitacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                invitacionEN = (InvitacionEN)session.Get (typeof(InvitacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return invitacionEN;
}

public System.Collections.Generic.IList<InvitacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<InvitacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(InvitacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<InvitacionEN>();
                else
                        result = session.CreateCriteria (typeof(InvitacionEN)).List<InvitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM InvitacionEN self where FROM InvitacionEN as inv WHERE inv.Invitador.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("InvitacionENdameInvitacionEnviadaPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnadirUsuario (int p_Invitacion_OID, System.Collections.Generic.IList<string> p_usuario_invitado_OIDs)
{
        DSMGitGenNHibernate.EN.DSMGit.InvitacionEN invitacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                invitacionEN = (InvitacionEN)session.Load (typeof(InvitacionEN), p_Invitacion_OID);
                DSMGitGenNHibernate.EN.DSMGit.UsuarioEN usuario_invitadoENAux = null;
                if (invitacionEN.Usuario_invitado == null) {
                        invitacionEN.Usuario_invitado = new System.Collections.Generic.List<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN>();
                }

                foreach (string item in p_usuario_invitado_OIDs) {
                        usuario_invitadoENAux = new DSMGitGenNHibernate.EN.DSMGit.UsuarioEN ();
                        usuario_invitadoENAux = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), item);
                        usuario_invitadoENAux.Invitaciones_recibidas.Add (invitacionEN);

                        invitacionEN.Usuario_invitado.Add (usuario_invitadoENAux);
                }


                session.Update (invitacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> DameInvitacionEnviadaPorGrupo (string p_grupo)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM InvitacionEN self where FROM InvitacionEN as inv WHERE inv.Grupo.Nombre=:p_grupo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("InvitacionENdameInvitacionEnviadaPorGrupoHQL");
                query.SetParameter ("p_grupo", p_grupo);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.InvitacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in InvitacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
