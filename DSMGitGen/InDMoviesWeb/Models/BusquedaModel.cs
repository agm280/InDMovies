using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class BusquedaModel
    {
        [Key]
        public virtual int Id
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