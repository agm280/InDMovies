
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
                UsuarioCEN usuario = new UsuarioCEN ();
                usuario.New_ (p_email: "ejemplo@gmail.com", p_nombre: "Pepito", p_apellidos: "Palotes Vidal", p_nick: "PepitoPV", p_contrasenya: "1234", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 1, p_imagen: "imagen1.png", p_descripcion: "hola");
                usuario.New_ (p_email: "ejemplo2@gmail.com", p_nombre: "Juanito", p_apellidos: "Palotes Vidal", p_nick: "JuanitoPV", p_contrasenya: "4321", p_fecha_nac: new DateTime (1992, 2, 4), p_rol: (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum) 3, p_imagen: "imagen2.png", p_descripcion: "hola");

                VideoCEN video = new VideoCEN ();
                int a = video.New_ (p_titulo: "primer video", p_descripcion: "descripcion", p_usuario: "ejemplo@gmail.com", p_fecha_subida: new DateTime (2017, 1, 3));

                ValoracionCEN valoracion = new ValoracionCEN ();
                valoracion.New_ (p_valor: 97, p_usuario: "ejemplo@gmail.com", p_video: a);

                GrupoCEN grupo = new GrupoCEN ();
                grupo.New_ (p_nombre: "Grupo1", p_imagen: "imagen.png", p_descripcion: "El mejor grupo", p_miembros: null, p_lider: "ejemplo@gmail.com", p_completo: false);

                IList<UsuarioEN> pipas = usuario.DameUsuarioPorEmail("ejemplo2@gmail.com");
                System.Console.WriteLine(pipas[0].Nick);

                foreach (UsuarioEN adsfsdf in pipas)
                {
                    System.Console.WriteLine(adsfsdf.Nick);
                }
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
