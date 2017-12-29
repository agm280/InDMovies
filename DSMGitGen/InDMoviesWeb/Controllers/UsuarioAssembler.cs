using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class UsuarioAssembler
    {
        public static UsuarioModel ConvertENToModel(UsuarioEN usuEN)
        {
            UsuarioModel usu = new UsuarioModel();

            usu.Nick = usuEN.Nick;
            usu.Email = usuEN.Email;
            usu.Nombre = usuEN.Nombre;
            usu.Apellidos = usuEN.Apellidos;
            try
            {
                string parsedDate = usuEN.Fecha_nac.ToString();
                string[] fecha = parsedDate.Split(' ');
                usu.Fecha_nac = fecha[0];

            }
            catch
            {
                usu.Fecha_nac = "NO hay fecha";
            }
            usu.Descripcion = usuEN.Descripcion;
            usu.Imagen = usuEN.Imagen;
            switch (usuEN.Rol)
            {
                case (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum)1:
                    usu.Rol = "Director";
                    break;
                case (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum)2:
                    usu.Rol = "Camara";
                    break;
                case (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum)3:
                    usu.Rol = "Guionista";
                    break;
                case (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum)4:
                    usu.Rol = "Actor";
                    break;
                case (DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum)5:
                    usu.Rol = "Editor";
                    break;
                default:
                    usu.Rol = "Ninguno";
                    break;
            }
            return usu;
        }
        public static IList<UsuarioModel> ConvertListENToModel(IList<UsuarioEN> usuEN)
        {
            IList<UsuarioModel> usu = new List<UsuarioModel>();
            foreach (UsuarioEN u in usuEN)
            {
                usu.Add(ConvertENToModel(u));
            }
            return usu;
        }
    }
}