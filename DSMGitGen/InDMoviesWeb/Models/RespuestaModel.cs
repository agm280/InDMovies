using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class RespuestaModel
    {
        [Key]
        public virtual int Id
        {
            get; set;
        }



        public virtual string Descripcion
        {
            get; set;
        }



        public virtual String Tema
        {
            get; set;
        }



        public virtual String Usuario
        {
            get; set;
        }

        public virtual DateTime fecha
        {
            get; set;
        }
    }
}