

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.Exceptions;

using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;


namespace DSMGitGenNHibernate.CEN.DSMGit
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_email, string p_nombre, string p_apellidos, string p_nick, String p_contrasenya, Nullable<DateTime> p_fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum p_rol, string p_imagen, string p_descripcion)
{
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

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, string p_apellidos, string p_nick, String p_contrasenya, Nullable<DateTime> p_fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum p_rol, string p_imagen, string p_descripcion)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Nick = p_nick;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.Fecha_nac = p_fecha_nac;
        usuarioEN.Rol = p_rol;
        usuarioEN.Imagen = p_imagen;
        usuarioEN.Descripcion = p_descripcion;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNick (string p_nick)
{
        return _IUsuarioCAD.DameUsuarioPorNick (p_nick);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorEmail (string p_email)
{
        return _IUsuarioCAD.DameUsuarioPorEmail (p_email);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorNombreYApellidos (string p_nombre, string p_apellidos)
{
        return _IUsuarioCAD.DameUsuarioPorNombreYApellidos (p_nombre, p_apellidos);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorRol (int ? p_rol)
{
        return _IUsuarioCAD.DameUsuarioPorRol (p_rol);
}
public System.Collections.Generic.IList<DSMGitGenNHibernate.EN.DSMGit.UsuarioEN> DameUsuarioPorDescripcion (string p_descripcion)
{
        return _IUsuarioCAD.DameUsuarioPorDescripcion (p_descripcion);
}
}
}
