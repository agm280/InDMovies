using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class VideoModel
    {


        public virtual string Titulo
        {
            get;set;
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



        public virtual int Valoraciones
        {
            get; set;
        }



        public virtual string Fecha_subida
        {
            get; set;
        }



        public virtual string Miniatura
        {
            get; set;
        }



    }
}