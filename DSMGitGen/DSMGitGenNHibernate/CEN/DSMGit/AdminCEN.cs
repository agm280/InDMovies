

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public string New_ (string p_email, string p_nombre, string p_apellidos, string p_nick, String p_contrasenya, Nullable<DateTime> p_fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum p_rol, string p_imagen, string p_descripcion)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_email;

        adminEN.Nombre = p_nombre;

        adminEN.Apellidos = p_apellidos;

        adminEN.Nick = p_nick;

        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        adminEN.Fecha_nac = p_fecha_nac;

        adminEN.Rol = p_rol;

        adminEN.Imagen = p_imagen;

        adminEN.Descripcion = p_descripcion;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (string p_Admin_OID, string p_nombre, string p_apellidos, string p_nick, String p_contrasenya, Nullable<DateTime> p_fecha_nac, DSMGitGenNHibernate.Enumerated.DSMGit.RolEnum p_rol, string p_imagen, string p_descripcion)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Apellidos = p_apellidos;
        adminEN.Nick = p_nick;
        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        adminEN.Fecha_nac = p_fecha_nac;
        adminEN.Rol = p_rol;
        adminEN.Imagen = p_imagen;
        adminEN.Descripcion = p_descripcion;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminCAD.Destroy (email);
}

public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        adminEN = _IAdminCAD.ReadOID (email);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminCAD.ReadAll (first, size);
        return list;
}
}
}
