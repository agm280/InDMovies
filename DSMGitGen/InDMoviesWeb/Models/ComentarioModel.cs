using System;
using System.Collections.Generic;
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



        public virtual string Texto
        {
            get; set;
        }



        public virtual string Usuario
        {
            get; set;
        }



        public virtual int Video
        {
            get; set;
        }
    }
}