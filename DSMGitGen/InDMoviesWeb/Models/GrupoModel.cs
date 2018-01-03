using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class GrupoModel
    {

        [Key]
        public virtual string Nombre
        {
            get;set;
        }



        public virtual string Imagen
        {
            get; set;
        }



        public virtual string Descripcion
        {
            get; set;
        }



        public virtual string Lider
        {
            get; set;
        }



        public virtual bool Completo
        {
            get; set;
        }



        public virtual bool AceptaMiembros
        {
            get; set;
        }

    }
}