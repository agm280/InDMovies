using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InDMoviesWeb.Models;
using System.Globalization;

namespace InDMoviesWeb.Controllers
{
    public class UsuarioAssembler
    {

        public static UsuarioModel crearUsu(UsuarioEN usuEN) {

            UsuarioModel usu = new UsuarioModel();

            usu.Nick = usuEN.Nick;
            usu.Email = usuEN.Email;
            usu.Nombre = usuEN.Nombre;
            usu.Apellidos = usuEN.Apellidos;
            usu.Fecha_Nacimiento = usuEN.Fecha_nac??DateTime.Today;
            usu.Descripcion = usuEN.Descripcion;
            usu.Imagen = usuEN.Imagen;
            usu.Rol = usuEN.Rol;
            usu.Contrasenya = usuEN.Contrasenya;
            return usu;
        }

        public static IList<UsuarioModel> crearListaUsus(IList<UsuarioEN> usuEN)
        {

            IList<UsuarioModel> usu = new List<UsuarioModel>();

            foreach (UsuarioEN u in usuEN) {

                usu.Add(crearUsu(u));
            }

            return usu;
        }
    }
}