
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGitGenNHibernate.EN.DSMGit;
using DSMGitGenNHibernate.CAD.DSMGit;
using DSMGitGenNHibernate.CEN.DSMGit;



/*PROTECTED REGION ID(usingDSMGitGenNHibernate.CP.DSMGit_Video_calcular_valoracion) ENABLED START*/
//  references to other libraries
using System.Collections.Generic;

/*PROTECTED REGION END*/

namespace DSMGitGenNHibernate.CP.DSMGit
{
public partial class VideoCP : BasicCP
{
public double Calcular_valoracion (int p_oid)
{
        /*PROTECTED REGION ID(DSMGitGenNHibernate.CP.DSMGit_Video_calcular_valoracion) ENABLED START*/


        VideoCAD videoCAD = null;
        VideoCEN videoCEN = null;
        ValoracionCAD valoracionCAD = null;
        ValoracionCEN valoracionCEN = null;

        double media = 0;


        try
        {
                SessionInitializeTransaction ();
                videoCAD = new VideoCAD (session);
                videoCEN = new VideoCEN (videoCAD);
                valoracionCAD = new ValoracionCAD (session);
                valoracionCEN = new ValoracionCEN (valoracionCAD);

                double suma = 0;

                // Write here your custom transaction ...
                IList<ValoracionEN> lista = valoracionCEN.DameValoracionPorVideoID (p_oid);
                if (lista.Count > 0) {
                        foreach (ValoracionEN i in lista) {
                                suma = suma + i.Valor;
                        }

                        media = suma / lista.Count;
                }
                // throw new NotImplementedException ("Method Calcular_valoracion() not yet implemented.");


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return media;


        /*PROTECTED REGION END*/
}
}
}
