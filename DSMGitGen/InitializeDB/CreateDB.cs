
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CP.DSMGit;
using System.Collections;

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

                IList<UsuarioEN> usuarios = usuario.DameUsuarioPorNick ("Juan");
                System.Console.WriteLine ("DAME USUARIO POR NICK");
                foreach (UsuarioEN usu in usuarios) {
                        System.Console.WriteLine (usu.Nick);
                }

                IList<UsuarioEN> usuarios2 = usuario.DameUsuarioPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME USUARIO POR EMAIL");
                foreach (UsuarioEN usu2 in usuarios2) {
                        System.Console.WriteLine (usu2.Email);
                }



                IList<UsuarioEN> usuarios3 = usuario.DameUsuarioPorNombreYApellidos ("Juan", "J");
                System.Console.WriteLine ("DAME USUARIO POR NOMBRE Y APELLIDOS");
                foreach (UsuarioEN usu in usuarios3) {
                        System.Console.WriteLine (usu.Nombre + usu.Apellidos);
                }

                IList<UsuarioEN> usuarios6 = usuario.DameUsuarioPorNombreOApellidos ("Juan", "J");
                System.Console.WriteLine ("DAME USUARIO POR NOMBRE O APELLIDOS");
                foreach (UsuarioEN usu in usuarios6) {
                        System.Console.WriteLine (usu.Nombre + usu.Apellidos);
                }

                IList<UsuarioEN> usuarios4 = usuario.DameUsuarioPorRol (3);
                System.Console.WriteLine ("DAME USUARIO POR ROL");
                foreach (UsuarioEN usu in usuarios4) {
                        System.Console.WriteLine (usu.Nombre);
                }

                IList<UsuarioEN> usuarios5 = usuario.DameUsuarioPorDescripcion ("la");
                System.Console.WriteLine ("DAME USUARIO POR DESCRIPCION");
                foreach (UsuarioEN usu in usuarios5) {
                        System.Console.WriteLine (usu.Nombre);
                }


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

                IList<string> enviaUsu = new List<string>();
                enviaUsu.Add ("ejemplo@gmail.com");

                grupo.New_ (p_nombre: "Grupo1", p_imagen: "imagen.png", p_descripcion: "El mejor grupo", p_miembros: enviaUsu, p_lider: "ejemplo@gmail.com", p_completo: false);
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

                NotificacionCEN notificacion = new NotificacionCEN ();
                notificacion.New_ (p_id: "1234", p_descripcion: "Tienes una nueva invitacion de grupo", p_usuario: "ejemplo@gmail.com");
                NotificacionCEN notificacion2 = new NotificacionCEN ();
                notificacion2.New_ (p_id: "5678", p_descripcion: "El usuario Pepito ha aceptado tu peticion", p_usuario: "ejemplo2@gmail.com");
                NotificacionCEN notificacion3 = new NotificacionCEN ();
                notificacion3.New_ (p_id: "9876", p_descripcion: "Tienes una nueva valoracion en uno de tus videos", p_usuario: "ejemplo@gmail.com");


                IList<NotificacionEN> notificaciones = notificacion.DameNotificacionPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME NOTIFICACION POR EMAIL");
                foreach (NotificacionEN vid in notificaciones) {
                        System.Console.WriteLine (vid.Descripcion);
                }


                SugerenciaCEN sugerencia = new SugerenciaCEN ();
                sugerencia.New_ (p_id: "S1", p_titulo: "Reproductor", p_descripcion: "El tama�o del reproductor esta un poco desproporcionado", p_usuario: "ejemplo@gmail.com");
                SugerenciaCEN sugerencia2 = new SugerenciaCEN ();
                sugerencia2.New_ (p_id: "S2", p_titulo: "Temas", p_descripcion: "Deberia haber mas control en los temas", p_usuario: "ejemplo2@gmail.com");
                SugerenciaCEN sugerencia3 = new SugerenciaCEN ();
                sugerencia3.New_ (p_id: "S3", p_titulo: "Grupos", p_descripcion: "Mejora en el manejo de las invitaciones porfa", p_usuario: "ejemplo@gmail.com");

                IList<SugerenciaEN> sugerencias = sugerencia.DameSugerenciaPorEmail ("ejemplo@gmail.com");
                System.Console.WriteLine ("DAME SUGERENCIA POR EMAIL");
                foreach (SugerenciaEN vid in sugerencias) {
                        System.Console.WriteLine (vid.Descripcion);
                }

                ValoracionCEN valoracion1 = new ValoracionCEN ();
                valoracion1.New_ (p_valor: 97, p_usuario: "ejemplo@gmail.com", p_video: idVideo1);
                valoracion1.New_ (p_valor: 65, p_usuario: "ejemplo2@gmail.com", p_video: idVideo2);
                valoracion1.New_ (p_valor: 32, p_usuario: "ejemplo2@gmail.com", p_video: idVideo3);

                IList<ValoracionEN> valoraciones = valoracion.DameValoracionPorVideoID (idVideo1);
                System.Console.WriteLine ("DAME LA VALORACION MEDIANTE LA ID DEL VIDEO");
                foreach (ValoracionEN val in valoraciones) {
                        System.Console.WriteLine ("Valoracion: " + val.Valor);
                    System.Console.WriteLine("Valorado por");
                    System.Console.WriteLine ("Usuario con email: " + val.Usuario.Email);
                }

                ComentarioCEN comentario = new ComentarioCEN ();
                comentario.New_ (p_texto: "Me ha parecido que esta bastante guapa", p_usuario: "ejemplo@gmail.com", p_video: idVideo1);
                comentario.New_ (p_texto: "tbh me esperaba mas", p_usuario: "ejemplo2@gmail.com", p_video: idVideo2);
                comentario.New_ (p_texto: "un poco desagradable", p_usuario: "ejemplo@gmail.com", p_video: idVideo3);

                IList<ComentarioEN> comentarios = comentario.DameComentarioPorVideoID (idVideo1);
                System.Console.WriteLine ("DAME LOS COMENTARIOS POR ID DE VIDEO");
                foreach (ComentarioEN com in comentarios) {
                        System.Console.WriteLine ("Comentarios: " + com.Texto);
                    System.Console.WriteLine("Comentado por");
                    System.Console.WriteLine ("Usuario: " + com.Usuario.Email);
                }



                GrupoCEN grupo3 = new GrupoCEN ();

                grupo3.New_ (p_nombre: "Excalibur", p_imagen: "http...etc", p_descripcion: "Grupo de fans de las espadas", p_miembros: null, p_lider: "ejemplo2@gmail.com", p_completo: false);

               







                //Comprobaciones CP: Salir de grupo. Entrar de grupo. Metodos de usuario.
                //(No funciona, no se como invocar a un CP desde createdb, y no me deja acceder desde el cen.)
                /*
                 * System.Console.WriteLine("Entrar a excalibur. Metodo de ejemplo@gmail.com");
                 * UsuarioCP userCP = null;
                 * userCP.EntrarAGrupo("ejemplo@gmail.com", "Excalibur");
                 *
                 * System.Console.WriteLine("Miembros de excalibur");
                 * foreach (UsuarioEN miembro in grupo3.ReadOID("Excalibur").Miembros)
                 * {
                 *  System.Console.WriteLine(miembro.Nick);
                 *  System.Console.WriteLine("Email: " + miembro.Email);
                 * }
                 *
                 * System.Console.WriteLine("Salir de Excalibur. Metodo de ejemplo@gmail.com");
                 * userCP.SalirDeGrupo("ejemplo@gmail.com", "Excalibur");
                 * System.Console.WriteLine("Miembros de excalibur");
                 *
                 * foreach (UsuarioEN miembro in grupo3.ReadOID("Excalibur").Miembros)
                 * {
                 *  System.Console.WriteLine(miembro.Nick);
                 *  System.Console.WriteLine("Email: " + miembro.Email);
                 * }
                 */




                //COMPROBACIONES DE HQL VIDEOS
                IList<VideoEN> videos = video.DameVideoPorDescripcion ("life");
                System.Console.WriteLine ("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) life");
                foreach (VideoEN vid in videos) {
                        System.Console.WriteLine (vid.Titulo);
                        System.Console.WriteLine ("Desripcion: " + vid.Descripcion);
                }
                IList<VideoEN> videos2 = video.DameVideoPorDescripcion ("hack");
                System.Console.WriteLine ("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) hack");
                foreach (VideoEN vid in videos2) {
                        System.Console.WriteLine (vid.Titulo);
                        System.Console.WriteLine ("Descripcion: " + vid.Descripcion);
                }
                IList<VideoEN> videos3 = video.DameVideoPorTitulo ("Investigacion");
                System.Console.WriteLine ("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) Investigacion");
                foreach (VideoEN vid in videos3) {
                        System.Console.WriteLine (vid.Titulo);
                }
                IList<VideoEN> videos4 = video.DameVideoPorTitulo ("Video");
                System.Console.WriteLine ("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) Video");
                foreach (VideoEN vid in videos4) {
                        System.Console.WriteLine (vid.Titulo);
                }
                IList<VideoEN> videos5 = video.DameVideoPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME VIDEO POR EMAIL Ejemplo2");
                foreach (VideoEN vid in videos5) {
                        System.Console.WriteLine (vid.Titulo);
                }

                //DateTime fecha1 = new DateTime(2017, 1, 3);
                //Date time: year month day

                IList<VideoEN> videos6 = video.DameVideoPorFecha (2017, 1, 3);
                System.Console.WriteLine ("DAME VIDEO POR FECHA 2017 1 3");
                foreach (VideoEN vid in videos6) {
                        System.Console.WriteLine (vid.Titulo);
                }

                IList<VideoEN> videos7 = video.DameVideoPorNick ("Juanito");
                System.Console.WriteLine ("DAME VIDEO POR NICK DE USER (se autocompleta, me va a dar todos los videos de todos los juanitos) - Juanito");
                foreach (VideoEN vid in videos7) {
                        System.Console.WriteLine (vid.Titulo);
                }


                IList<VideoEN> videos8 = video.DameVideoPorNick ("JuanitoPV");
                System.Console.WriteLine ("DAME VIDEO POR NICK DE USER (se autocompleta) - JuanitoPV");
                foreach (VideoEN vid in videos8) {
                        System.Console.WriteLine (vid.Titulo);
                }

                System.Console.WriteLine ("3");






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
                 * 
                 * 
                 * 
                 */


                System.Console.WriteLine("\n---------CPs---------\n");

                //Grupo Excalibur creado por ejemplo2@gmail.com. Empieza sin miembros.


                DSMGitGenNHibernate.CP.DSMGit.GrupoCP grupoCP = new DSMGitGenNHibernate.CP.DSMGit.GrupoCP();

                DSMGitGenNHibernate.CP.DSMGit.UsuarioCP usuarioCP = new DSMGitGenNHibernate.CP.DSMGit.UsuarioCP();


                //Salir del grupo. El usuario exige salir de un grupo. No puede salir de Excalibur porque no pertenece.
                System.Console.WriteLine(usuarioCP.SalirDeGrupo("ejemplo2@gmail.com", "Excalibur") + "\n");
                //El lider del grupo desea meter a un usuario en el grupo. 
                //Alternativa agil a utilizar el Relationer, pues se le pasa un unico usuario, y no una lista.
                System.Console.WriteLine(grupoCP.AnadirUsuario("Excalibur", "ejemplo2@gmail.com") + "\n");
                //Salir del grupo. El usuario exige salir del grupo. Pertenece a Excalibur por lo que puede salir.
                System.Console.WriteLine(usuarioCP.SalirDeGrupo("ejemplo2@gmail.com", "Excalibur") + "\n");


                //System.Console.WriteLine(usuarioCP.SalirDeGrupo("ejemplo2@gmail.com", "Excalibur") + "\n");

                System.Console.WriteLine("La HQL esta peta:");

                //Es interesante, porque si ningun usuario ejecuta AnadirUsuario, la hql no peta:
                //Me imagino que sera porque ningun usuario estaria relacionado con Excalibur.

                
                 //IList<UsuarioEN> lista = usuario.DameUsuarioPorGrupo("Excalibur");
                 
                  //System.Console.WriteLine(lista != null);
                 
                 
                  //foreach (UsuarioEN usu in lista)
                 //{
                 //System.Console.WriteLine(usu.Email);
                 //}
                 


                System.Console.WriteLine("\n---------------------\n");

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
