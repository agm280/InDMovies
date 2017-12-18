using DSMGitGenNHibernate.EN.DSMGit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VideoAssembler
    {
        public static VideoModel convertENToModelUI(VideoEN videoEN) {

            VideoModel v = new VideoModel();

            v.Titulo = videoEN.Titulo;
            v.Id = videoEN.Id;
            v.Descripcion = videoEN.Descripcion;
            v.Etiquetas = videoEN.Etiquetas;
            v.Usuario = videoEN.Usuario.Nick;
            try
            {
                string parsedDate = videoEN.Fecha_subida.ToString();
                string[] fecha = parsedDate.Split(' ');
                v.Fecha_subida = fecha[0];

            }
            catch {
                v.Fecha_subida = "NO hay fecha";
            }
            

            return v;
        }

        public static IList<VideoModel> convertListENToModel(IList<VideoEN> videos) {

            IList<VideoModel> videoModels = new List<VideoModel>();

            foreach (VideoEN v in videos) {
        
                VideoModel videoM = convertENToModelUI(v);

                videoModels.Add(videoM);
            }

            return videoModels;
        }

    }
}