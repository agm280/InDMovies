using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class NotificacionModel
    {
        [Key]
        public virtual int Id
         {
             get;
             set;
         }
 
 
 
         public virtual string Descripcion
         {
             get;
             set;
         }
 
 
        [Required]
         public virtual string Usuario
         {
             get;
             set;
         }
    }
}