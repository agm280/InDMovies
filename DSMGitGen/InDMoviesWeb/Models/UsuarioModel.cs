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
        public virtual string Nick
        {
            get;set;
        }

    }
}