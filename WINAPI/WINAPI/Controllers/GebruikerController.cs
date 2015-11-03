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
    public class GebruikerController : Controller
    {
        // GET: Gebruiker
        [HttpGet]
        public ActionResult Index(string Gebruikernaam)
        {
            Gebruiker geb = DA.GetGebruiker(Gebruikernaam);
            ViewBag.Json = JsonConvert.SerializeObject(geb);
         
            return View();
        }

        /**/
        [HttpPut]
        public ActionResult Edit(Gebruiker reg)
        {
           
            int rows = DA.newgebruiker(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }
        [HttpPost]
        public ActionResult Editme(Gebruiker reg)
        {

            int rows = DA.UpdateGebruiker(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }
    }
}