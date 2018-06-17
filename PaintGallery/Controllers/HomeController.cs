using PaintGallery.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace PaintGallery.Controllers
{
    public class HomeController : Controller
    {


        public static string filepath = "~/JSON_files/PaintingInfo.Json";

        public ActionResult Index()
        {
            if (!System.IO.File.Exists(filepath))
            {
                createJSON();
            }


            return View(DeserializeJSON());
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Paint Gallery";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public void createJSON()
        {
            try
            {
                string path = Server.MapPath(filepath);
                using (StreamWriter file = System.IO.File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<Paintings> paintings = new List<Paintings> {
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/1.png",Name="Alex Ironman"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/2.png",Name="Rea"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/3.jpg",Name="Dreams"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/4.jpg",Name="Emotions Through My Smile"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/5.jpg",Name="I want to be Beautiful"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/6.jpg",Name="Snow White"},
                new Paintings(){author="Alchelle", Description="place holder description", ImageURL="~/Images/7.png",Name="Technology"}
            };
                    serializer.Serialize(file, paintings);
                }
            }
            catch (Exception e)
            {

            }
        }

        public List<Paintings> DeserializeJSON()
        {
            string path = Server.MapPath(filepath);
            List<Paintings> list = null;
            using (StreamReader file = System.IO.File.OpenText(path))
            {
                JsonSerializer ser = new JsonSerializer();
                list = (List<Paintings>)ser.Deserialize(file, typeof(List<Paintings>));
            }
            return list;
        }
    }
}