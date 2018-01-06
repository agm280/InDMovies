using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DSMGitGenNHibernate.Enumerated.DSMGit;

namespace InDMoviesWeb.Models
{
    public class UsuarioModel
    {
        [Key]
        public virtual string Email
        {
            get; set;
        }
        public virtual string Nombre
        {
            get; set;
        }
        public virtual string Apellidos
        {
            get; set;
        }
        [Required]
        [StringLength(16, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 4)]
        public virtual string Nick
        {
            get; set;
        }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        public virtual RolEnum Rol
        {
            get; set;
        }
        [Required]
        public virtual string Imagen
        {
            get; set;
        }
        public virtual string Descripcion
        {
            get; set;
        }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public virtual string Contrasenya
        {
            get; set;
        }

    }
}