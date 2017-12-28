
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CEN.DSMGit_Usuario_registrarse) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CEN.DSMGit
{
public partial class UsuarioCEN
{
public string Registrarse (string p_email, string p_nombre, string p_apellidos, string p_nick, String p_contrasenya, Nullable<DateTime> p_fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum p_rol, string p_imagen, string p_descripcion)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CEN.DSMGit_Usuario_registrarse_customized) START*/

        UsuarioEN usuarioEN = null;

        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Nick = p_nick;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Fecha_nac = p_fecha_nac;

        usuarioEN.Rol = p_rol;

        usuarioEN.Imagen = p_imagen;

        usuarioEN.Descripcion = p_descripcion;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrarse (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
