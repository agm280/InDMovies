using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class ValoracionModel
    {
        public virtual int Id
        {
            get;set;
        }



        public virtual int Valor
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