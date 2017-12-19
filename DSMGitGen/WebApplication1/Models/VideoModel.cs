using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VideoModel
    {

        public virtual string Titulo
        {
            get; set;
        }



        public virtual int Id
        {
            get; set;
        }



        public virtual string Descripcion
        {
            get; set;
        }



        public virtual System.Collections.Generic.IList<string> Etiquetas
        {
            get; set;
        }

        public virtual string Usuario
        {
            get; set;
        }


        public virtual string Fecha_subida
        {
            get; set;
        }

    }
}