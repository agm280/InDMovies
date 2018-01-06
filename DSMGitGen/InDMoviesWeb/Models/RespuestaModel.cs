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


        [Required]
        public virtual string Descripcion
        {
            get; set;
        }



        public virtual string Tema
        {
            get; set;
        }



        public virtual string Usuario
        {
            get; set;
        }

        public virtual DateTime Fecha
        {
            get; set;
        }
    }
}