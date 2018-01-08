using DSMGitGenNHibernate.EN.DSMGit;
using InDMoviesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InDMoviesWeb.Controllers
{
    public class VideoAssembler
    {
        public static VideoModel convertENToModelUI(VideoEN videoEN) {

            VideoModel v = new VideoModel();

            v.Titulo = videoEN.Titulo;
            v.Id = videoEN.Id;
            v.Descripcion = videoEN.Descripcion;
            //v.Etiquetas = videoEN.Etiquetas;
            v.Usuario = videoEN.Usuario.Nick;
            

            try
            {
                string parseDate = videoEN.Fecha_subida.ToString();
                string[] fecha = parseDate.Split(' ');
                v.Fecha_subida = fecha[0];
            }
            catch {
                v.Fecha_subida = "No hay fecha";
            }

            v.Miniatura = videoEN.Miniatura;
            v.Url = videoEN.Url;
            v.Texto = "";

            return v;

        }

        public static IList<VideoModel> convertListENToModel(IList<VideoEN> videos)
        {

            IList<VideoModel> videoModels = new List<VideoModel>();

            foreach (VideoEN v in videos)
            {

                VideoModel videoM = convertENToModelUI(v);

                videoModels.Add(videoM);
            }

            return videoModels;
        }
    }
}