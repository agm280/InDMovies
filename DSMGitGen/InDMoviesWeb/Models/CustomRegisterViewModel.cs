using DSMGitGenNHibernate.Enumerated.DSMGit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Models
{
    public class CustomRegisterViewModel : RegisterViewModel
    {
 
        public string Nombre { get; set; }
    
        public string Apellidos { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 4)]
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        public RolEnum Rol { get; set; }

        public string Descripcion { get; set; }

    }
}