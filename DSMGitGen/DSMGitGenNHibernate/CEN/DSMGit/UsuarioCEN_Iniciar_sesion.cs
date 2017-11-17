
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


/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CEN.DSMGit_Usuario_iniciar_sesion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CEN.DSMGit
{
public partial class UsuarioCEN
{
        public bool Iniciar_sesion(string email, String contrasenya)
        {
            /*PROTECTED REGION ID(DSMGitGenNHibernate.CEN.DSMGit_Usuario_iniciar_sesion) ENABLED START*/

            // Write here your custom code...
            bool result = false;

            if (email != null && contrasenya != null) { 

            UsuarioEN usu = _IUsuarioCAD.ReadOID(email);

            if (usu != null) {
                if (Utils.Util.GetEncondeMD5(contrasenya).Equals(usu.Contrasenya)) {
                    result = true;
                }
            }
            _IUsuarioCAD.Modify(usu);
        }
        return result;
        //throw new NotImplementedException ("Method Iniciar_sesion() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
