using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class ComentarioModel
    {
        public virtual int Id
        {
            get; set;
        }


        [Required]
        public virtual string Texto
        {
            get; set;
        }


        [Required]
        public virtual string Usuario
        {
            get; set;
        }


        [Required]
        public virtual int Video
        {
            get; set;
        }

        
        public virtual string Email
        {
            get; set;
        }
    }
}