
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");
                //CREACION DE OBJETOS DE LAS CLASES
                UsuarioCEN usuario = new UsuarioCEN ();
                usuario.New_ (p_email: "ejemplo2@gmail.com", p_nombre: "Juanito", p_apellidos: "Palotes Vidal", p_nick: "JuanitoPV", p_contrasenya: "4321", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 3, p_imagen: "imagen2.png", p_descripcion: "hola");
                UsuarioCEN usuario2 = new UsuarioCEN ();
                usuario2.New_ (p_email: "ejemplo@gmail.com", p_nombre: "Pepito", p_apellidos: "Palotes Vidal", p_nick: "JuanitoPeter", p_contrasenya: "1234", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 1, p_imagen: "imagen1.png", p_descripcion: "hola");

                VideoCEN video = new VideoCEN ();
                int idVideo1 = video.New_ (p_titulo: "Haz tu vida mas facil con GitHub", p_descripcion: "Amazing life Hacks", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2015, 1, 3));
                VideoCEN video2 = new VideoCEN ();
                int idVideo2 = video.New_ (p_titulo: "Investigacion de MAC", p_descripcion: "Mi proyecto de MAC", p_usuario: "ejemplo@gmail.com", p_fecha_subida: new DateTime (2015, 1, 3));
                VideoCEN video3 = new VideoCEN ();
                int idVideo3 = video.New_ (p_titulo: "Video de Investigacion", p_descripcion: "Me at the zoo", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2017, 1, 3));
                VideoCEN video4 = new VideoCEN ();
                int idVideo4 = video.New_ (p_titulo: "Video Terror Halloween", p_descripcion: "you WONT BELIEVE this. MUST WATCH. Best thing in ur life", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2017, 2, 3));
                //Date time: year month day



                ValoracionCEN valoracion = new ValoracionCEN ();
                valoracion.New_ (p_valor: 97, p_usuario: "ejemplo@gmail.com", p_video: idVideo1);

                GrupoCEN grupo = new GrupoCEN ();
                grupo.New_ (p_nombre: "Grupo1", p_imagen: "imagen.png", p_descripcion: "El mejor grupo", p_miembros: null, p_lider: "ejemplo@gmail.com", p_completo: false);
                GrupoCEN grupo2 = new GrupoCEN ();
                grupo.New_ (p_nombre: "Grupo2", p_imagen: "imagen.png", p_descripcion: "El segundo mejor grupo", p_miembros: null, p_lider: "ejemplo@gmail.com", p_completo: false);

                InvitacionCEN invitacion = new InvitacionCEN ();
                invitacion.New_ (p_descripcion: "Invitacion 1", p_grupo: "Grupo1", p_invitador: "ejemplo2@gmail.com");
                InvitacionCEN invitacion2 = new InvitacionCEN ();
                invitacion2.New_ (p_descripcion: "Invitacion 2", p_grupo: "Grupo2", p_invitador: "ejemplo@gmail.com");
                InvitacionCEN invitacion3 = new InvitacionCEN ();
                invitacion3.New_ (p_descripcion: "Invitacion 3", p_grupo: "Grupo2", p_invitador: "ejemplo2@gmail.com");

                TemaCEN tema = new TemaCEN ();
                int idtema = tema.New_ (p_descripcion: "Hola, buenas tardes", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.cerrado, p_usuario: "ejemplo2@gmail.com", p_titulo: "Pregunta personal");
                TemaCEN tema2 = new TemaCEN ();
                int idtema2 = tema2.New_ (p_descripcion: "Como sacar un 10 en esto?", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.abierto, p_usuario: "ejemplo2@gmail.com", p_titulo: "Desesperacion");
                TemaCEN tema3 = new TemaCEN ();
                int idtema3 = tema3.New_ (p_descripcion: "Adios", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.cerrado, p_usuario: "ejemplo@gmail.com", p_titulo: "Despedida");

                RespuestaCEN respuesta = new RespuestaCEN ();
                respuesta.New_ (p_descripcion: "Buenas tardes", p_tema: idtema, p_usuario: "ejemplo2@gmail.com");
                RespuestaCEN respuesta2 = new RespuestaCEN ();
                respuesta2.New_ (p_descripcion: "Es imposible", p_tema: idtema2, p_usuario: "ejemplo@gmail.com");
                RespuestaCEN respuesta3 = new RespuestaCEN ();
                respuesta3.New_ (p_descripcion: "rt", p_tema: idtema2, p_usuario: "ejemplo2@gmail.com");
                RespuestaCEN respuesta4 = new RespuestaCEN ();
                respuesta4.New_ (p_descripcion: "Hasta luego", p_tema: idtema3, p_usuario: "ejemplo@gmail.com");

                 //COMPROBACIONES DE HQL VIDEOS
                 IList<VideoEN> videos = video.DameVideoPorDescripcion("life");
                 System.Console.WriteLine("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) life");
                  foreach (VideoEN vid in videos)
                  {
                   System.Console.WriteLine(vid.Titulo);
                   System.Console.WriteLine("Desripcion: " + vid.Descripcion);
                  }
                  IList<VideoEN> videos2 = video.DameVideoPorDescripcion("hack");
                  System.Console.WriteLine("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) hack");
                  foreach (VideoEN vid in videos2)
                  {
                   System.Console.WriteLine(vid.Titulo);
                   System.Console.WriteLine("Descripcion: " + vid.Descripcion);
                  }
                  IList<VideoEN> videos3 = video.DameVideoPorTitulo("Investigacion");
                  System.Console.WriteLine("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) Investigacion");
                  foreach (VideoEN vid in videos3)
                  {
                   System.Console.WriteLine(vid.Titulo);
                  }
                  IList<VideoEN> videos4 = video.DameVideoPorTitulo("Video");
                 System.Console.WriteLine("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) Video");
                  foreach (VideoEN vid in videos4)
                  {
                   System.Console.WriteLine(vid.Titulo);
                  }
                  IList<VideoEN> videos5 = video.DameVideoPorEmail("ejemplo2@gmail.com");
                  System.Console.WriteLine("DAME VIDEO POR EMAIL Ejemplo2");
                  foreach (VideoEN vid in videos5)
                  {
                   System.Console.WriteLine(vid.Titulo);
                  }
                 
                  //DateTime fecha1 = new DateTime(2017, 1, 3);
                 //Date time: year month day
                 /*
                 IList<VideoEN> videos6 = video.DameVideoPorFecha(2017, 1, 3);
                 System.Console.WriteLine("DAME VIDEO POR FECHA 2017 1 3");
                 foreach (VideoEN vid in videos6)
                 {
                 System.Console.WriteLine(vid.Titulo);
                 }
                 
                 IList<VideoEN> videos7 = video.DameVideoPorNick("Juanito");
                 System.Console.WriteLine("DAME VIDEO POR NICK DE USER (se autocompleta, me va a dar todos los videos de todos los juanitos) - Juanito");
                 foreach (VideoEN vid in videos7)
                 {
                    System.Console.WriteLine(vid.Titulo);
                 }
                 
                 
                 IList<VideoEN> videos8 = video.DameVideoPorNick("JuanitoPV");
                 System.Console.WriteLine("DAME VIDEO POR NICK DE USER (se autocompleta) - JuanitoPV");
                 foreach (VideoEN vid in videos8)
                 {
                 System.Console.WriteLine(vid.Titulo);
                 }
                 
                 //

                //COMPROBACIONES
                /*
                 * COMPROBACIONES DE USUARIOS
                 * IList<UsuarioEN> pipas = usuario.DameUsuarioPorEmail ("ejemplo2@gmail.com");
                 * System.Console.WriteLine("DAME USUARIO POR EMAIL");
                 * foreach (UsuarioEN usus in pipas) {
                 * System.Console.WriteLine (usus.Nick);
                 * }
                 * System.Console.WriteLine("DAME USUARIO POR NICK");
                 * IList<UsuarioEN> listajuanito = usuario.DameUsuarioPorNick ("uanito");
                 *
                 * foreach (UsuarioEN usuarios in listajuanito) {
                 * System.Console.WriteLine (usuarios.Nick);
                 * }
                 * System.Console.WriteLine("INICIAR SESION");
                 * System.Console.WriteLine(usuario.Iniciar_sesion("ejemplo2@gmail.com", "4321"));
                 * System.Console.WriteLine(usuario.Iniciar_sesion("ejemplo2@gmail.com", "321"));
                 *
                 */



                //La siguiente lista la hago porque no tengo ni idea de como coger el id de TemaEn desde temaCEN.
                //Creo que es porque el id de tema es 'autogenerated", asi que cuando se crea en el cen no
                //deja especificar ningun valor.
                */

                /*COMPROBACIONES DE TEMAS
                 * IList<TemaEN> temas = tema.DameTemaPorNick("PV");
                 * System.Console.WriteLine("DAME TEMA POR NICK");
                 * foreach (TemaEN tem in temas)
                 * {
                 * System.Console.WriteLine(tem.Titulo);
                 * }
                 *
                 * IList<TemaEN> temas2 = tema.DameTemaPorEmail("ejemplo@gmail.com");
                 * System.Console.WriteLine("DAME TEMA POR EMAIL");
                 * foreach (TemaEN tem2 in temas2)
                 * {
                 * System.Console.WriteLine(tem2.Titulo);
                 * }
                 * IList<TemaEN> temas3 = tema.DameTemaPorDesc("ue");
                 * System.Console.WriteLine("DAME TEMA POR DESCRIPCION");
                 * foreach (TemaEN tem3 in temas3)
                 * {
                 * System.Console.WriteLine(tem3.Titulo);
                 * }
                 *
                 * IList<TemaEN> temas4 = tema.DameTemaPorTitulo("per");
                 * System.Console.WriteLine("DAME TEMA POR TITULO");
                 * foreach (TemaEN tem4 in temas4)
                 * {
                 * System.Console.WriteLine(tem4.Titulo);
                 * }
                 *
                 *
                 * IList<TemaEN> listaTemasAbiertos = tema.DameTemasAbiertos ();
                 * System.Console.WriteLine ("Temas abiertos");
                 * foreach (TemaEN te in listaTemasAbiertos) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 * IList<TemaEN> listaTemasCerrados = tema.DameTemasCerrados ();
                 * System.Console.WriteLine ("Temas cerrados");
                 * foreach (TemaEN te in listaTemasCerrados) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 * System.Console.WriteLine ("Ejecuto abrir de tema (metodo custom) y vuelvo a hacer la HQL:");
                 * IList<TemaEN> dameElTemaQueQuiero = tema.DameTemaPorTitulo ("Pregunta personal");
                 * int idQueQuiero = -1;
                 * foreach (TemaEN te in listaTemasCerrados) {
                 * idQueQuiero = te.Id;
                 * }
                 *
                 * tema.Abrir (idQueQuiero);
                 *
                 * listaTemasAbiertos = tema.DameTemasAbiertos ();
                 * System.Console.WriteLine ("Temas abiertos");
                 * foreach (TemaEN te in listaTemasAbiertos) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 * listaTemasCerrados = tema.DameTemasCerrados ();
                 * System.Console.WriteLine ("Temas cerrados");
                 * foreach (TemaEN te in listaTemasCerrados) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 * System.Console.WriteLine ("Ahora cerramos el tema");
                 *
                 * tema.Cerrar (idQueQuiero);
                 *
                 * listaTemasAbiertos = tema.DameTemasAbiertos ();
                 * System.Console.WriteLine ("Temas abiertos");
                 * foreach (TemaEN te in listaTemasAbiertos) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 * listaTemasCerrados = tema.DameTemasCerrados ();
                 * System.Console.WriteLine ("Temas cerrados");
                 * foreach (TemaEN te in listaTemasCerrados) {
                 * System.Console.WriteLine (te.Titulo);
                 * }
                 *
                 */


                /* COMPROBACIONES DE INVITACIONES
                 * IList<InvitacionEN> invis = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo@gmail.com");
                 * System.Console.WriteLine ("DAME INVITACION POR EMAIL (INVITADOR)");
                 * foreach (InvitacionEN invi in invis) {
                 *    System.Console.WriteLine (invi.Descripcion);
                 * }
                 *
                 * IList<InvitacionEN> invis2 = invitacion.DameInvitacionEnviadaPorGrupo("Grupo2");
                 * System.Console.WriteLine("DAME INVITACION POR GRUPO");
                 * foreach (InvitacionEN invi2 in invis2)
                 * {
                 * System.Console.WriteLine(invi2.Descripcion);
                 * }*/

                /* COMPROBACIONES DE RESPUESTAS
                 * IList<RespuestaEN> respus = respuesta.DameRespuestaPorEmail ("ejemplo2@gmail.com");
                 * System.Console.WriteLine ("DAME RESPUESTA POR EMAIL");
                 * foreach (RespuestaEN respu in respus) {
                 *    System.Console.WriteLine (respu.Descripcion);
                 * }
                 *
                 *
                 * IList<RespuestaEN> respus2 = respuesta.DameRespuestaPorNick ("Pet");
                 * System.Console.WriteLine ("DAME RESPUESTA POR NICK");
                 * foreach (RespuestaEN respu2 in respus2) {
                 *    System.Console.WriteLine (respu2.Descripcion);
                 * }
                 *
                 * IList<RespuestaEN> respus3 = respuesta.DameRespuestaPorTema (idtema2);
                 * System.Console.WriteLine ("DAME RESPUESTA POR TEMA");
                 * foreach (RespuestaEN respu3 in respus3) {
                 *  System.Console.WriteLine (respu3.Descripcion);
                 * }
                 */
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
