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
    public class InstellingenController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //   int ids = Int32.Parse(id);
            List<Instellingen> p = new List<Instellingen>();
            ViewBag.Json = JsonConvert.SerializeObject(DA.GetInstellingen(id.Value));
            return View();


        }
        [HttpPut]
        public ActionResult Edit(Instellingen reg)
        {

            int rows = DA.newInstellingen(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }


        /**/
        [HttpPost]
        public ActionResult Editme(Instellingen reg)
        {

            int rows = DA.UpdateInstellingen(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }
    }
}