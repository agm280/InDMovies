

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
 *      Definition of the class BusquedaCEN
 *
 */
public partial class BusquedaCEN
{
private IBusquedaCAD _IBusquedaCAD;

public BusquedaCEN()
{
        this._IBusquedaCAD = new BusquedaCAD ();
}

public BusquedaCEN(IBusquedaCAD _IBusquedaCAD)
{
        this._IBusquedaCAD = _IBusquedaCAD;
}

public IBusquedaCAD get_IBusquedaCAD ()
{
        return this._IBusquedaCAD;
}

public int New_ (string p_Texto)
{
        BusquedaEN busquedaEN = null;
        int oid;

        //Initialized BusquedaEN
        busquedaEN = new BusquedaEN ();
        busquedaEN.Texto = p_Texto;

        //Call to BusquedaCAD

        oid = _IBusquedaCAD.New_ (busquedaEN);
        return oid;
}

public void Modify (int p_Busqueda_OID, string p_Texto)
{
        BusquedaEN busquedaEN = null;

        //Initialized BusquedaEN
        busquedaEN = new BusquedaEN ();
        busquedaEN.Id = p_Busqueda_OID;
        busquedaEN.Texto = p_Texto;
        //Call to BusquedaCAD

        _IBusquedaCAD.Modify (busquedaEN);
}

public void Destroy (int id
                     )
{
        _IBusquedaCAD.Destroy (id);
}

public BusquedaEN ReadOID (int id
                           )
{
        BusquedaEN busquedaEN = null;

        busquedaEN = _IBusquedaCAD.ReadOID (id);
        return busquedaEN;
}

public System.Collections.Generic.IList<BusquedaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BusquedaEN> list = null;

        list = _IBusquedaCAD.ReadAll (first, size);
        return list;
}
}
}
