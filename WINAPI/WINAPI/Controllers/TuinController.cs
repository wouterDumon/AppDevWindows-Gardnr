using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WINAPI.helper;
using WINAPI.Models;

namespace WINAPI.Controllers
{
    public class TuinController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //   int ids = Int32.Parse(id);
            List<Tuin> p = new List<Tuin>();
            ViewBag.Json = JsonConvert.SerializeObject(DA.GetTuin(id.Value));
            return View();


        }
        [HttpPut]
        public ActionResult Edit(Tuin reg)
        {

            int rows = DA.Voegnieuweplantaantuin(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }


        /**/
        [HttpPost]
        public ActionResult Editme(Tuin reg)
        {
            
            int rows = DA.Pastuinaan(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }
    }
}