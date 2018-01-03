﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class SugerenciaModel
    {
        public virtual string Id
        {
            get; set;
        }

        public virtual string Titulo
        {
            get; set;
        }

        public virtual string Descripcion
        {
            get; set;
        }

        public virtual string Usuario
        {
            get; set;
        }
    }
}