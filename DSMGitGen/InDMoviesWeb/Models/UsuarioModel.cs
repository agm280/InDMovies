using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class UsuarioModel
    {
        [Key]
        public virtual string Email
        {
            get; set;
        }
        public virtual string Nombre
        {
            get; set;
        }
        public virtual string Apellidos
        {
            get; set;
        }
        public virtual string Nick
        {
            get; set;
        }

        public virtual string Fecha_nac
        {
            get; set;
        }
        public virtual string Rol
        {
            get; set;
        }
        public virtual string Imagen
        {
            get; set;
        }
        public virtual string Descripcion
        {
            get; set;
        }
    }
}