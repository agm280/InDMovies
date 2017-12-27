using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class TemaModel
    {

        [Key]
        public virtual int Id
        {
            get;set;
        }

        public virtual string Titulo
        {
            get; set;
        }



        public virtual string Descripcion
        {
            get; set;
        }


        public virtual string Estado
        {
            get; set;
        }



        public virtual string Usuario
        {
            get; set;
        }

    }
}