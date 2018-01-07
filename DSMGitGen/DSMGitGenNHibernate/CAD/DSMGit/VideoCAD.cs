
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
 * Clase Video:
 *
 */

namespace DSMGitGenNHibernate.CAD.DSMGit
{
public partial class VideoCAD : BasicCAD, IVideoCAD
{
public VideoCAD() : base ()
{
}

public VideoCAD(ISession sessionAux) : base (sessionAux)
{
}



public VideoEN ReadOIDDefault (int id
                               )
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VideoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                        else
                                result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), video.Id);

                videoEN.Titulo = video.Titulo;


                videoEN.Descripcion = video.Descripcion;


                videoEN.Etiquetas = video.Etiquetas;





                videoEN.Fecha_subida = video.Fecha_subida;


                videoEN.Miniatura = video.Miniatura;


                videoEN.Url = video.Url;

                session.Update (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                if (video.Usuario != null) {
                        // Argumento OID y no colección.
                        video.Usuario = (DSMGitGenNHibernate.EN.DSMGit.UsuarioEN)session.Load (typeof(DSMGitGenNHibernate.EN.DSMGit.UsuarioEN), video.Usuario.Email);

                        video.Usuario.Videos
                        .Add (video);
                }

                session.Save (video);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return video.Id;
}

public void Modify (VideoEN video)
{
        try
        {
                SessionInitializeTransaction ();
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), video.Id);

                videoEN.Titulo = video.Titulo;


                videoEN.Descripcion = video.Descripcion;


                videoEN.Fecha_subida = video.Fecha_subida;


                videoEN.Miniatura = video.Miniatura;


                videoEN.Url = video.Url;

                session.Update (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
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
                VideoEN videoEN = (VideoEN)session.Load (typeof(VideoEN), id);
                session.Delete (videoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: VideoEN
public VideoEN ReadOID (int id
                        )
{
        VideoEN videoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videoEN = (VideoEN)session.Get (typeof(VideoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videoEN;
}

public System.Collections.Generic.IList<VideoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<VideoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VideoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<VideoEN>();
                else
                        result = session.CreateCriteria (typeof(VideoEN)).List<VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorTitulo (string p_titulo)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN as vid WHERE vid.Titulo LIKE ('%'+:p_titulo+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENdameVideoPorTituloHQL");
                query.SetParameter ("p_titulo", p_titulo);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorNick (string p_nick)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN as vid WHERE vid.Usuario.Nick LIKE ('%'+:p_nick+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENdameVideoPorNickHQL");
                query.SetParameter ("p_nick", p_nick);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorFecha (int? p_anyo, int? p_mes, int ? p_dia)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN as vid WHERE day(vid.Fecha_subida)=:p_dia AND month(vid.Fecha_subida)=:p_mes AND year(vid.Fecha_subida)=:p_anyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENdameVideoPorFechaHQL");
                query.SetParameter ("p_anyo", p_anyo);
                query.SetParameter ("p_mes", p_mes);
                query.SetParameter ("p_dia", p_dia);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorEmail (string p_email)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN as vid WHERE vid.Usuario.Email=:p_email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENdameVideoPorEmailHQL");
                query.SetParameter ("p_email", p_email);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> DameVideoPorDescripcion (string p_descripcion)
{
        System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.VideoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideoEN self where FROM VideoEN as vid WHERE vid.Descripcion LIKE ('%'+:p_descripcion+'%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideoENdameVideoPorDescripcionHQL");
                query.SetParameter ("p_descripcion", p_descripcion);

                result = query.List<DSMGitGenNHibernate.EN.DSMGit.VideoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGitGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSMGitGenNHibernate.Exceptions.DataLayerException ("Error in VideoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
