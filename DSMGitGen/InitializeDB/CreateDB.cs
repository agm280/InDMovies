
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


                //CREACION DE OBJETOS CEN Y VARIOS OBJETOS DE LAS CLASES



                UsuarioCEN usuario = new UsuarioCEN ();
                usuario.New_ (p_email: "ejemplo2@gmail.com", p_nombre: "Juanito", p_apellidos: "Palotes Vidal", p_nick: "JuanitoPV", p_contrasenya: "4321", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 3, p_imagen: "/Images/Uploads/defaultUser.png", p_descripcion: "hola");
                usuario.New_ (p_email: "ejemplo@gmail.com", p_nombre: "Pepito", p_apellidos: "Palotes Vidal", p_nick: "JuanitoPeter", p_contrasenya: "1234", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 1, p_imagen: "/Images/Uploads/defaultUser.png", p_descripcion: "hola");

                VideoCEN video = new VideoCEN ();
                int idVideo1 = video.New_ (p_titulo: "Haz tu vida mas facil con GitHub", p_descripcion: "Amazing life Hacks", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2015, 1, 3), p_miniatura: "/Images/Uploads/Miniaturas/defaultUser.png", p_url: "https://www.youtube.com/embed/aJ7Tv6ukASw");
                int idVideo2 = video.New_ (p_titulo: "Investigacion de MAC", p_descripcion: "Mi proyecto de MAC", p_usuario: "ejemplo@gmail.com", p_fecha_subida: new DateTime (2015, 1, 3), p_miniatura: "/Images/Uploads/Miniaturas/defaultUser.png", p_url: "https://www.youtube.com/embed/aJ7Tv6ukASw");
                int idVideo3 = video.New_ (p_titulo: "Video de Investigacion", p_descripcion: "Me at the zoo", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2017, 1, 3), p_miniatura: "/Images/Uploads/Miniaturas/defaultUser.png", p_url: "https://www.youtube.com/embed/aJ7Tv6ukASw");
                int idVideo4 = video.New_ (p_titulo: "Video Terror Halloween", p_descripcion: "you WONT BELIEVE this. MUST WATCH. Best thing in ur life", p_usuario: "ejemplo2@gmail.com", p_fecha_subida: new DateTime (2017, 2, 3), p_miniatura: "/Images/Uploads/Miniaturas/defaultUser.png", p_url: "https://www.youtube.com/embed/aJ7Tv6ukASw");
                //Date time: year month day

                ValoracionCEN valoracion = new ValoracionCEN ();
                valoracion.New_ (p_valor: 5, p_usuario: "ejemplo@gmail.com", p_video: idVideo1);
                valoracion.New_ (p_valor: 4, p_usuario: "ejemplo2@gmail.com", p_video: idVideo1);


                IList<string> enviaUsu = new List<string>();
                enviaUsu.Add ("ejemplo@gmail.com");

                GrupoCEN grupo = new GrupoCEN ();
                grupo.New_ (p_nombre: "Grupo1", p_imagen: "/Images/Uploads/defaultGroup.png", p_descripcion: "El mejor grupo", p_miembros: enviaUsu, p_lider: "ejemplo@gmail.com", p_aceptaMiembros: true);
                grupo.New_ (p_nombre: "Grupo2", p_imagen: "/Images/Uploads/defaultGroup.png", p_descripcion: "El segundo mejor grupo", p_miembros: null, p_lider: "ejemplo@gmail.com", p_aceptaMiembros: true);
                //Grupo usado para la mayoria de ejemplos de cps:
                grupo.New_ (p_nombre: "Excalibur", p_imagen: "/Images/Uploads/defaultGroup.png", p_descripcion: "Grupo de fans de las espadas", p_miembros: null, p_lider: "ejemplo2@gmail.com", p_aceptaMiembros: true);


                InvitacionCEN invitacion = new InvitacionCEN ();
                invitacion.New_ (p_descripcion: "Invitacion 1", p_grupo: "Grupo1", p_invitador: "ejemplo2@gmail.com");
                invitacion.New_ (p_descripcion: "Invitacion 2", p_grupo: "Grupo2", p_invitador: "ejemplo@gmail.com");
                invitacion.New_ (p_descripcion: "Invitacion 3", p_grupo: "Grupo2", p_invitador: "ejemplo2@gmail.com");

                TemaCEN tema = new TemaCEN ();
                int idtema = tema.New_ (p_descripcion: "Hola, buenas tardes", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.cerrado, p_usuario: "ejemplo2@gmail.com", p_titulo: "Pregunta personal", p_fecha: new DateTime (2015, 1, 3));
                int idtema2 = tema.New_ (p_descripcion: "Como sacar un 10?", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.abierto, p_usuario: "ejemplo2@gmail.com", p_titulo: "Desesperacion", p_fecha: new DateTime (2017, 5, 1));
                int idtema3 = tema.New_ (p_descripcion: "Adios", p_estado: DSMGitGenNHibernate.Enumerated.DSMGit.EstadoTemaEnum.cerrado, p_usuario: "ejemplo@gmail.com", p_titulo: "Despedida", p_fecha: new DateTime (2017, 12, 3));



                RespuestaCEN respuesta = new RespuestaCEN ();
                respuesta.New_ (p_descripcion: "Buenas tardes", p_tema: idtema, p_usuario: "ejemplo2@gmail.com", p_fecha: new DateTime (2017, 9, 9));
                respuesta.New_ (p_descripcion: "Es imposible", p_tema: idtema2, p_usuario: "ejemplo@gmail.com", p_fecha: new DateTime (2017, 9, 9));
                respuesta.New_ (p_descripcion: "rt", p_tema: idtema2, p_usuario: "ejemplo2@gmail.com", p_fecha: new DateTime (2017, 9, 9));
                respuesta.New_ (p_descripcion: "Hasta luego", p_tema: idtema3, p_usuario: "ejemplo@gmail.com", p_fecha: new DateTime (2017, 9, 9));

                NotificacionCEN notificacion = new NotificacionCEN ();
                notificacion.New_ (p_descripcion: "Tienes una nueva invitacion de grupo", p_usuario: "ejemplo@gmail.com");
                notificacion.New_ (p_descripcion: "El usuario Pepito ha aceptado tu peticion", p_usuario: "ejemplo2@gmail.com");
                notificacion.New_ (p_descripcion: "Tienes una nueva valoracion en uno de tus videos", p_usuario: "ejemplo@gmail.com");


                SugerenciaCEN sugerencia = new SugerenciaCEN ();
                sugerencia.New_ (p_titulo: "Reproductor", p_descripcion: "El tama�o del reproductor esta un poco desproporcionado", p_usuario: "ejemplo@gmail.com");
                sugerencia.New_ (p_titulo: "Temas", p_descripcion: "Deberia haber mas control en los temas", p_usuario: "ejemplo2@gmail.com");
                sugerencia.New_ (p_titulo: "Grupos", p_descripcion: "Mejora en el manejo de las invitaciones porfa", p_usuario: "ejemplo@gmail.com");


                ValoracionCEN valoracion1 = new ValoracionCEN ();
                valoracion1.New_ (p_valor: 97, p_usuario: "ejemplo@gmail.com", p_video: idVideo4);
                valoracion1.New_ (p_valor: 65, p_usuario: "ejemplo2@gmail.com", p_video: idVideo2);
                valoracion1.New_ (p_valor: 32, p_usuario: "ejemplo2@gmail.com", p_video: idVideo3);



                ComentarioCEN comentario = new ComentarioCEN ();
                comentario.New_ (p_texto: "Me ha parecido que esta bastante guapa", p_usuario: "ejemplo@gmail.com", p_video: idVideo1);
                comentario.New_ (p_texto: "tbh me esperaba mas", p_usuario: "ejemplo2@gmail.com", p_video: idVideo2);
                comentario.New_ (p_texto: "un poco desagradable", p_usuario: "ejemplo@gmail.com", p_video: idVideo3);




                System.Console.WriteLine ("\n---------Sentencias HQLS / Readfilter ------------\n");


                //HQLS USUARIO
                System.Console.WriteLine ("*HQLS/ReadFilter DE USUARIO*");

                IList<UsuarioEN> usuarios = usuario.DameUsuarioPorNick ("Juan");
                System.Console.WriteLine ("DAME USUARIO POR NICK - Juan");
                foreach (UsuarioEN usu in usuarios) {
                        System.Console.WriteLine (usu.Nick);
                }

                IList<UsuarioEN> usuarios2 = usuario.DameUsuarioPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME USUARIO POR EMAIL - ejemplo2@gmail.com");
                foreach (UsuarioEN usu2 in usuarios2) {
                        System.Console.WriteLine (usu2.Email);
                }



                IList<UsuarioEN> usuarios3 = usuario.DameUsuarioPorNombreYApellidos ("Juan", "J");
                System.Console.WriteLine ("DAME USUARIO POR NOMBRE Y APELLIDOS - Juan, J");
                foreach (UsuarioEN usu in usuarios3) {
                        System.Console.WriteLine (usu.Nombre + " " + usu.Apellidos);
                }

                IList<UsuarioEN> usuarios6 = usuario.DameUsuarioPorNombreOApellidos ("Juan", "J");
                System.Console.WriteLine ("DAME USUARIO POR NOMBRE O APELLIDOS - Juan, J");
                foreach (UsuarioEN usu in usuarios6) {
                        System.Console.WriteLine (usu.Nombre + " " + usu.Apellidos);
                }

                IList<UsuarioEN> usuarios4 = usuario.DameUsuarioPorRol (3);
                System.Console.WriteLine ("DAME USUARIO POR ROL - 3 (3 seria Guionista)");
                foreach (UsuarioEN usu in usuarios4) {
                        System.Console.WriteLine (usu.Nombre);
                        //PUEDE DAR PROBLEMA
                        System.Console.WriteLine ("ROL=" + usu.Rol);
                }

                IList<UsuarioEN> usuarios5 = usuario.DameUsuarioPorDescripcion ("la");
                System.Console.WriteLine ("DAME USUARIO POR DESCRIPCION");
                foreach (UsuarioEN usu in usuarios5) {
                        System.Console.WriteLine (usu.Nombre);
                }

                //COMPROBACIONES DE HQL VIDEOS
                System.Console.WriteLine ("*HQLS/ReadFilter DE VIDEO*");
                IList<VideoEN> videos = video.DameVideoPorDescripcion ("life");
                System.Console.WriteLine ("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) - life");
                foreach (VideoEN vid in videos) {
                        System.Console.WriteLine (vid.Titulo);
                        System.Console.WriteLine ("Desripcion: " + vid.Descripcion);
                }
                IList<VideoEN> videos2 = video.DameVideoPorDescripcion ("hack");
                System.Console.WriteLine ("DAME VIDEO POR DESCRIPCION (AUTOCOMPLETA EL PR. Y EL FINAL) - hack");
                foreach (VideoEN vid in videos2) {
                        System.Console.WriteLine (vid.Titulo);
                        System.Console.WriteLine ("Descripcion: " + vid.Descripcion);
                }
                IList<VideoEN> videos3 = video.DameVideoPorTitulo ("Investigacion");
                System.Console.WriteLine ("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) - Investigacion");
                foreach (VideoEN vid in videos3) {
                        System.Console.WriteLine (vid.Titulo);
                }
                IList<VideoEN> videos4 = video.DameVideoPorTitulo ("Video");
                System.Console.WriteLine ("DAME VIDEO POR TITULO (AUTOCOMPLETA EL PR. Y EL FINAL) - Video");
                foreach (VideoEN vid in videos4) {
                        System.Console.WriteLine (vid.Titulo);
                }
                IList<VideoEN> videos5 = video.DameVideoPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME VIDEO POR EMAIL - Ejemplo2");
                foreach (VideoEN vid in videos5) {
                        System.Console.WriteLine (vid.Titulo);
                }

                //DateTime fecha1 = new DateTime(2017, 1, 3);
                //Date time: year month day

                IList<VideoEN> videos6 = video.DameVideoPorFecha (2017, 1, 3);
                System.Console.WriteLine ("DAME VIDEO POR FECHA - 2017 1 3");
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

                //HQLS Valoraciones
                System.Console.WriteLine ("*HQLS/ReadFilter DE VALORACIONES*");
                IList<ValoracionEN> valoraciones = valoracion.DameValoracionPorVideoID (idVideo1);
                System.Console.WriteLine ("DAME LA VALORACION MEDIANTE LA ID DEL VIDEO - idVideo1");
                foreach (ValoracionEN val in valoraciones) {
                        System.Console.WriteLine ("Valoracion: " + val.Valor);
                        System.Console.WriteLine ("Valorado por");
                        System.Console.WriteLine ("Usuario con email: " + val.Usuario.Email);
                }

                //HQLs Comentarios
                System.Console.WriteLine ("*HQLS/ReadFilter DE COMENTARIO*");
                IList<ComentarioEN> comentarios = comentario.DameComentarioPorVideoID (idVideo1);
                System.Console.WriteLine ("DAME LOS COMENTARIOS POR ID DE VIDEO - idVideo1");
                foreach (ComentarioEN com in comentarios) {
                        System.Console.WriteLine ("Comentarios: " + com.Texto);
                        System.Console.WriteLine ("Comentado por");
                        System.Console.WriteLine ("Usuario: " + com.Usuario.Email);
                }

                //HQLS Sugerencias
                System.Console.WriteLine ("*HQLS/ReadFilter DE SUGERENCIA*");
                IList<SugerenciaEN> sugerencias = sugerencia.DameSugerenciaPorEmail ("ejemplo@gmail.com");
                System.Console.WriteLine ("DAME SUGERENCIA POR EMAIL - ejemplo@gmail.com");
                foreach (SugerenciaEN vid in sugerencias) {
                        System.Console.WriteLine (vid.Descripcion);
                }

                //HQLs Notificaciones
                System.Console.WriteLine ("*HQLS/ReadFilter DE NOTIFICACION*");
                IList<NotificacionEN> notificaciones = notificacion.DameNotificacionPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME NOTIFICACION POR EMAIL - ejemplo2@gmail.com");
                foreach (NotificacionEN vid in notificaciones) {
                        System.Console.WriteLine (vid.Descripcion);
                }

                //HQLs Temas
                System.Console.WriteLine ("*HQLS/ReadFilter DE TEMAS*");
                IList<TemaEN> temas = tema.DameTemaPorNick ("PV");
                System.Console.WriteLine ("DAME TEMA POR NICK - PV");
                foreach (TemaEN tem in temas) {
                        System.Console.WriteLine (tem.Titulo);
                }


                IList<TemaEN> temas2 = tema.DameTemaPorEmail ("ejemplo@gmail.com");
                System.Console.WriteLine ("DAME TEMA POR EMAIL - ejemplo@gmail.com");
                foreach (TemaEN tem2 in temas2) {
                        System.Console.WriteLine (tem2.Titulo);
                }
                IList<TemaEN> temas3 = tema.DameTemaPorDesc ("ue");
                System.Console.WriteLine ("DAME TEMA POR DESCRIPCION - ue");
                foreach (TemaEN tem3 in temas3) {
                        System.Console.WriteLine (tem3.Titulo);
                }

                IList<TemaEN> temas4 = tema.DameTemaPorTitulo ("per");
                System.Console.WriteLine ("DAME TEMA POR TITULO - per");
                foreach (TemaEN tem4 in temas4) {
                        System.Console.WriteLine (tem4.Titulo);
                        System.Console.WriteLine (tem4.Fecha.ToString ());
                }


                IList<TemaEN> listaTemasAbiertos = tema.DameTemasAbiertos ();
                System.Console.WriteLine ("Dame Temas abiertos");
                foreach (TemaEN te in listaTemasAbiertos) {
                        System.Console.WriteLine (te.Titulo);
                }

                IList<TemaEN> listaTemasCerrados = tema.DameTemasCerrados ();
                System.Console.WriteLine ("Dame Temas cerrados");
                foreach (TemaEN te in listaTemasCerrados) {
                        System.Console.WriteLine (te.Titulo);
                }

                //hqls DE RESPUESTAS
                System.Console.WriteLine ("*HQLS/ReadFilter DE RESPUESTAS (a un tema)*");
                IList<RespuestaEN> respus = respuesta.DameRespuestaPorEmail ("ejemplo2@gmail.com");
                System.Console.WriteLine ("DAME RESPUESTA POR EMAIL - ejemplo2@gmail.com");
                foreach (RespuestaEN respu in respus) {
                        System.Console.WriteLine (respu.Descripcion);
                        System.Console.WriteLine ("Del tema: " + tema.ReadOID (respu.Tema.Id).Titulo);
                        System.Console.WriteLine ("Por el usuario: " + usuario.ReadOID (respu.Usuario.Email).Nick);
                }


                IList<RespuestaEN> respus2 = respuesta.DameRespuestaPorNick ("Pet");
                System.Console.WriteLine ("DAME RESPUESTA POR NICK - Pet");
                foreach (RespuestaEN respu2 in respus2) {
                        System.Console.WriteLine (respu2.Descripcion);
                        System.Console.WriteLine ("Del tema: " + tema.ReadOID (respu2.Tema.Id).Titulo);
                        System.Console.WriteLine ("Por el usuario: " + usuario.ReadOID (respu2.Usuario.Email).Nick);
                }

                IList<RespuestaEN> respus3 = respuesta.DameRespuestaPorTema (idtema2);
                System.Console.WriteLine ("DAME RESPUESTA POR TEMA - idtema2");
                foreach (RespuestaEN respu3 in respus3) {
                        System.Console.WriteLine (respu3.Descripcion);
                        System.Console.WriteLine ("Del tema: " + tema.ReadOID (respu3.Tema.Id).Titulo);
                        System.Console.WriteLine ("Por el usuario: " + usuario.ReadOID (respu3.Usuario.Email).Nick);
                }


                //HQLS DE INVITACIONES
                System.Console.WriteLine ("*HQLS/ReadFilter DE INVITACIONES (a 1 grupo)*");
                IList<InvitacionEN> invis = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo@gmail.com");
                System.Console.WriteLine ("DAME INVITACION POR EMAIL (INVITADOR) - ejemplo@gmail.com");
                foreach (InvitacionEN invi in invis) {
                        System.Console.WriteLine (invi.Descripcion);
                }

                IList<InvitacionEN> invis2 = invitacion.DameInvitacionEnviadaPorGrupo ("Grupo2");
                System.Console.WriteLine ("DAME INVITACION POR GRUPO - Grupo2");
                foreach (InvitacionEN invi2 in invis2) {
                        System.Console.WriteLine (invi2.Descripcion);
                        System.Console.WriteLine ("Del grupo: " + invi2.Grupo.Nombre);
                }



                //COMPROBACIONES METODOS

                System.Console.WriteLine ("\n------------------\n");
                System.Console.WriteLine ("\n---------CUSTOM---------\n");

                //Iniciar Sesion
                System.Console.WriteLine ("*INICIAR SESION*");
                System.Console.WriteLine ("Pruebas con el usuario ejemplo2@gmail.com");
                System.Console.WriteLine ("Con email ejemplo2@gmail.com y password 4321");



                System.Console.WriteLine ("Inicio de sesion: ejemplo2@gmail.com - 4321");

                System.Console.WriteLine (usuario.Iniciar_sesion ("ejemplo2@gmail.com", "4321"));
                System.Console.WriteLine ("Inicio de sesion: ejemplo2@gmail.com - 321");

                System.Console.WriteLine (usuario.Iniciar_sesion ("ejemplo2@gmail.com", "321"));


                System.Console.WriteLine ("\n*ABRIR Y CERRAR TEMAS*");

                listaTemasCerrados = tema.DameTemasCerrados ();
                System.Console.WriteLine ("Temas cerrados");
                foreach (TemaEN te in listaTemasCerrados) {
                        System.Console.WriteLine (te.Titulo);
                }
                System.Console.WriteLine ("");

                System.Console.WriteLine ("Ejecuto abrir de tema (metodo custom) y vuelvo a hacer la HQL:");
                IList<TemaEN> dameElTemaQueQuiero = tema.DameTemaPorTitulo ("Pregunta personal");
                int idQueQuiero = -1;
                foreach (TemaEN te in listaTemasCerrados) {
                        idQueQuiero = te.Id;
                }
                System.Console.WriteLine ("");

                System.Console.WriteLine ("Abro el tema");
                System.Console.WriteLine ("");

                tema.Abrir (idQueQuiero);

                listaTemasAbiertos = tema.DameTemasAbiertos ();

                System.Console.WriteLine ("Temas abiertos");
                foreach (TemaEN te in listaTemasAbiertos) {
                        System.Console.WriteLine (te.Titulo);
                }
                System.Console.WriteLine ("");

                listaTemasCerrados = tema.DameTemasCerrados ();
                System.Console.WriteLine ("Temas cerrados");
                foreach (TemaEN te in listaTemasCerrados) {
                        System.Console.WriteLine (te.Titulo);
                }
                System.Console.WriteLine ("");

                System.Console.WriteLine ("Ahora cierro el tema: Despedida");
                tema.Cerrar (idQueQuiero);
                System.Console.WriteLine ("");


                listaTemasAbiertos = tema.DameTemasAbiertos ();
                System.Console.WriteLine ("Temas abiertos");
                foreach (TemaEN te in listaTemasAbiertos) {
                        System.Console.WriteLine (te.Titulo);
                }
                System.Console.WriteLine ("");

                listaTemasCerrados = tema.DameTemasCerrados ();
                System.Console.WriteLine ("Temas cerrados");
                foreach (TemaEN te in listaTemasCerrados) {
                        System.Console.WriteLine (te.Titulo);
                }
                System.Console.WriteLine ("FIN COMPROBACIONES DE ABRIR-CERRAR TEMA");
                System.Console.WriteLine ("");


                System.Console.WriteLine ("\n------------------\n");

                System.Console.WriteLine ("\n---------CPs---------\n");

                //Grupo Excalibur creado por ejemplo2@gmail.com. Empieza sin miembros.
                DSMGitGenNHibernate.CP.DSMGit.InvitacionCP invitacionCP = new DSMGitGenNHibernate.CP.DSMGit.InvitacionCP ();

                DSMGitGenNHibernate.CP.DSMGit.GrupoCP grupoCP = new DSMGitGenNHibernate.CP.DSMGit.GrupoCP ();

                DSMGitGenNHibernate.CP.DSMGit.UsuarioCP usuarioCP = new DSMGitGenNHibernate.CP.DSMGit.UsuarioCP ();

                DSMGitGenNHibernate.CP.DSMGit.VideoCP videoCP = new DSMGitGenNHibernate.CP.DSMGit.VideoCP ();

                IList<UsuarioEN> listaUsuariosExcalibur = new List<UsuarioEN>();
                IList<ValoracionEN> listaValoraciones = new List<ValoracionEN>();



                //Salir del grupo. El usuario exige salir de un grupo. No puede salir de Excalibur porque no pertenece.
                System.Console.WriteLine ("ejemplo2@gmail.com - Salir de Excalibur");
                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("ejemplo2@gmail.com", "Excalibur") + "\n");

                //Alternativa agil a utilizar el Relationer, pues se le pasa un unico usuario, y no una lista.
                //Accion del grupo para meter a un usuario.
                System.Console.WriteLine ("Excalibur añade a ejemplo2@gmail.com");
                System.Console.WriteLine (grupoCP.AnadirUsuario ("Excalibur", "ejemplo2@gmail.com") + "\n");



                listaUsuariosExcalibur = usuario.DameUsuarioPorGrupo ("Excalibur");
                System.Console.WriteLine ("Veamos los usuarios de Excalibur:");
                foreach (UsuarioEN usu in listaUsuariosExcalibur) {
                        System.Console.WriteLine (usu.Nick);
                        System.Console.WriteLine ("Email: " + usu.Email);
                }


                //Expulsar Usuario. Accion del grupo para echar a uno de sus usuarios.
                System.Console.WriteLine (" ");
                System.Console.WriteLine ("\n Excalibur expulsa a su miembro ejemplo2@gmail.com");
                System.Console.WriteLine (grupoCP.ExpulsarUsuario ("Excalibur", "ejemplo2@gmail.com") + "\n");




                listaUsuariosExcalibur = usuario.DameUsuarioPorGrupo ("Excalibur");
                System.Console.WriteLine ("Veamos los usuarios de Excalibur:");
                foreach (UsuarioEN usu in listaUsuariosExcalibur) {
                        System.Console.WriteLine (usu.Nick);
                        System.Console.WriteLine ("Email: " + usu.Email);
                }


                //El usuario entra por su cuenta a Excalibur, que acepta nuevos miembros.
                System.Console.WriteLine (" ");
                System.Console.WriteLine ("ejemplo2@gmail.com - Entrar a Excalibur (peticion)");
                System.Console.WriteLine (usuarioCP.EntrarAGrupo ("ejemplo2@gmail.com", "Excalibur") + "\n");





                listaUsuariosExcalibur = usuario.DameUsuarioPorGrupo ("Excalibur");
                System.Console.WriteLine ("Veamos los usuarios de Excalibur:");
                foreach (UsuarioEN usu in listaUsuariosExcalibur) {
                        System.Console.WriteLine (usu.Nick);
                        System.Console.WriteLine ("Email: " + usu.Email);
                }


                //Salir del grupo. El usuario exige salir de un grupo. Pertenece a Excalibur por lo que puede salir. Sale sin problema de Excalibur
                System.Console.WriteLine (" ");
                System.Console.WriteLine ("ejemplo2@gmail.com - Salir de Excalibur");
                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("ejemplo2@gmail.com", "Excalibur") + "\n");




                listaUsuariosExcalibur = usuario.DameUsuarioPorGrupo ("Excalibur");
                System.Console.WriteLine ("Veamos los usuarios de Excalibur:");
                foreach (UsuarioEN usu in listaUsuariosExcalibur) {
                        System.Console.WriteLine (usu.Nick);
                        System.Console.WriteLine ("Email: " + usu.Email);
                }


                //Salir del grupo. El usuario exige salir de un grupo. No puede salir de Excalibur porque ya no pertenece.
                System.Console.WriteLine ("\n ejemplo2@gmail.com - Salir de Excalibur");
                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("ejemplo2@gmail.com", "Excalibur") + "\n");



                System.Console.WriteLine ("\n *Comprobaciones de errores en CP: no meten usuarios nulos o usuarios a grupos nulos, o usuarios/grupos inexistentes.*");
                System.Console.WriteLine ("Por lo que todos estos métodos deben dar FALSE.");
                System.Console.WriteLine (grupoCP.AnadirUsuario ("Excalibur", null));
                System.Console.WriteLine (grupoCP.AnadirUsuario ("Excalibur", "usuarioinexistente"));
                System.Console.WriteLine (grupoCP.AnadirUsuario ("grupoinexistente", "ejemplo2@gmail.com"));
                System.Console.WriteLine (grupoCP.AnadirUsuario ("grupoinexistente", "usuarioinexistente"));

                System.Console.WriteLine (usuarioCP.EntrarAGrupo (null, "Excalibur"));
                System.Console.WriteLine (usuarioCP.EntrarAGrupo ("ejemplo2@gmail.com", null));
                System.Console.WriteLine (usuarioCP.EntrarAGrupo ("ejemplo2@gmail.com", "Noexiste"));
                System.Console.WriteLine (usuarioCP.EntrarAGrupo ("noexisto", "Excalibur"));

                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("ejemplo2@gmail.com", null));
                System.Console.WriteLine (usuarioCP.SalirDeGrupo (null, "Excalibur"));
                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("noexisto", "Excalibur"));
                System.Console.WriteLine (usuarioCP.SalirDeGrupo ("ejemplo2@gmail.com", "noexisto"));

                System.Console.WriteLine (grupoCP.ExpulsarUsuario (null, null));
                System.Console.WriteLine (grupoCP.ExpulsarUsuario ("Excalibur", null));
                System.Console.WriteLine (grupoCP.ExpulsarUsuario (null, "ejemplo2@gmail.com"));
                System.Console.WriteLine (grupoCP.ExpulsarUsuario ("noexisto", "ejemplo2@gmail.com"));
                System.Console.WriteLine (grupoCP.ExpulsarUsuario ("Excalibur", "noexisto"));
                System.Console.WriteLine ("\n *Fin de metodos CP de Grupos/Usuarios que deben dar error*");

                System.Console.WriteLine ("\n---------CPs sobre Video/Valoracion------------\n");

                //Por aqui se pueden probar los metodos CrearInvitacion y AceptarInvitacion
                System.Console.WriteLine ("Comprobacion CrearInvitacion");
                System.Console.WriteLine ("INVITACIONES USUARIO 1 \n");
                IList<InvitacionEN> inviE1 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo@gmail.com");
                IList<InvitacionEN> inviR1 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo@gmail.com");
                System.Collections.Generic.IList<string> usuarios_invitados = new List<string>();;
                usuarios_invitados.Add ("ejemplo2@gmail.com");
                foreach (InvitacionEN invi in inviR1) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE1) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                System.Console.Write ("\n");
                System.Console.WriteLine ("INVITACIONES USUARIO 2 \n");
                IList<InvitacionEN> inviE2 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo2@gmail.com");
                IList<InvitacionEN> inviR2 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo2@gmail.com");
                foreach (InvitacionEN invi in inviR2) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE2) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                System.Console.Write ("\n");
                System.Console.WriteLine ("SE INVOCA A CREAR INVITACION, USUARIO 1 LE MANDA INVITACION A USUARIO 2 ");
                invitacionCP.CrearInvitacion (usuarios_invitados, "ejemplo@gmail.com", "Grupo1", "Invitacion hecha con el CP crear Invitacion \n");
                System.Console.WriteLine ("INVITACIONES USUARIO 1 \n");
                inviE1 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo@gmail.com");
                inviR1 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo@gmail.com");

                foreach (InvitacionEN invi in inviR1) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE1) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                System.Console.Write ("\n");
                System.Console.WriteLine ("INVITACIONES USUARIO 2 \n");
                inviE2 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo2@gmail.com");
                inviR2 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo2@gmail.com");
                foreach (InvitacionEN invi in inviR2) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE2) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                //comprobaciones Aceptar invitacion
                System.Console.Write ("\n");
                System.Console.WriteLine ("USUARIOS EN EL GRUPO 1 \n");
                IList<UsuarioEN> usuarios_grupo1 = usuario.DameUsuarioPorGrupo ("Grupo1");
                foreach (UsuarioEN u in usuarios_grupo1)
                        System.Console.WriteLine ("--Usuario: " + u.Email);

                System.Console.Write ("\n");
                System.Console.WriteLine ("INVITACIONES DEL GRUPO 1 \n");
                IList<InvitacionEN> invi1 = invitacion.DameInvitacionEnviadaPorGrupo ("Grupo1");
                foreach (InvitacionEN i in invi1)
                        System.Console.WriteLine ("--Usuario: " + i.Descripcion);


                System.Console.Write ("\n");
                System.Console.WriteLine ("SE INVOCA A ACEPTAR INVITACIÓN DEL USUARIO 2 ");
                invitacionCP.AceptarInvitacion (inviR2 [0].Id, "ejemplo2@gmail.com");

                System.Console.WriteLine ("INVITACIONES USUARIO 1 \n");
                inviE1 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo@gmail.com");
                inviR1 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo@gmail.com");

                foreach (InvitacionEN invi in inviR1) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE1) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                System.Console.Write ("\n");
                System.Console.WriteLine ("INVITACIONES USUARIO 2 \n");
                inviE2 = invitacion.DameInvitacionEnviadaPorEmail ("ejemplo2@gmail.com");
                inviR2 = invitacion.DameInvitacionRecibidaPorEmail ("ejemplo2@gmail.com");
                foreach (InvitacionEN invi in inviR2) {
                        System.Console.WriteLine ("--Recibida: " + invi.Descripcion);
                }
                foreach (InvitacionEN invi in inviE2) {
                        System.Console.WriteLine ("--Enviada: " + invi.Descripcion);
                }
                System.Console.Write ("\n");
                System.Console.WriteLine ("USUARIOS EN EL GRUPO 1 \n");
                usuarios_grupo1 = usuario.DameUsuarioPorGrupo ("Grupo1");
                foreach (UsuarioEN u in usuarios_grupo1)
                        System.Console.WriteLine ("--Usuario: " + u.Email);

                System.Console.Write ("\n");
                System.Console.WriteLine ("INVITACIONES DEL GRUPO 1 \n");
                invi1 = invitacion.DameInvitacionEnviadaPorGrupo ("Grupo1");
                foreach (InvitacionEN i in invi1)
                        System.Console.WriteLine ("--Usuario: " + i.Descripcion);


                //ValoracionMedia de un video. Tiene 2 valoraciones, 5 y 4.

                System.Console.WriteLine ("\n Valoracion media del video: " + video.ReadOID (idVideo1).Titulo);
                System.Console.WriteLine (videoCP.Calcular_valoracion (idVideo1));

                //Mostramos las valoraciones que tiene para comprobar que estamos en lo cierto:
                listaValoraciones = valoracion.DameValoracionPorVideoID (idVideo1);
                System.Console.WriteLine ("\n HQL - Comprobamos las valoraciones del video: " + video.ReadOID (idVideo1).Titulo);
                foreach (ValoracionEN val in listaValoraciones) {
                        System.Console.WriteLine (" Valoracion de: " + val.Usuario.Email);
                        System.Console.WriteLine ("Puntuacion: " + val.Valor);
                }

                System.Console.WriteLine ("*Comprobaciones Errores CP Valoraciones: Estos metodos deben dar 0 porque el video no tiene valoraciones, o no existe.");
                //En principio este id de video, no existe. Seria mucha casualidad.
                System.Console.WriteLine (videoCP.Calcular_valoracion (-1423798));

                System.Console.WriteLine ("*Fin Comprobaciones Errores CP Valoraciones");

                System.Console.WriteLine ("\n---------------------\n");

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
