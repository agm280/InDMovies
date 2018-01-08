using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class VideoModel
    {

        [Required]
        public virtual string Titulo
        {
            get;set;
        }



        public virtual int Id
        {
            get; set;
        }


        [Required]
        public virtual string Descripcion
        {
            get; set;
        }



        public virtual string Etiquetas
        {
            get; set;
        }


        [Required]
        public virtual string Usuario
        {
            get; set;
        }



        public virtual int Valoraciones
        {
            get; set;
        }

        [Required]
        public virtual String Fecha_subida
        {
            get; set;
        }


        [Required]
        public virtual string Miniatura
        {
            get; set;
        }

        [Required]
        public virtual string Url
        {
            get; set;
        }

        [Required]
        public virtual string Texto
        {
            get; set;
        }

    }
}