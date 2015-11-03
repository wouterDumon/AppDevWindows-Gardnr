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
    public class PlantController : Controller
    {
        // GET: Plant
      /*  public ActionResult Index()
        {
            List<Plant> p = new List<Plant>();
            p = DA.getPlant();
           
            ViewBag.Json = JsonConvert.SerializeObject(p); 
            return View();
        }*/
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //   int ids = Int32.Parse(id);
            List<Plant> p = new List<Plant>();
            p = DA.getPlant();
            if (id.HasValue)
            {
                int ids = Convert.ToInt32(id);
                var a = p.Where(s => s.ID == ids);
                ViewBag.Json = JsonConvert.SerializeObject(a);
                return View();

            }
            else {
                ViewBag.Json = JsonConvert.SerializeObject(p);
                return View();
            }


            
        }
        [HttpPut]
        public ActionResult Edit(Plant reg)
        {

            int rows = DA.newplant(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }


        /**/
        [HttpPost]
        public ActionResult Edit(int? id, Plant reg)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            int ids = Convert.ToInt32(id);
            if (reg == null) RedirectToAction("Index");
            int rows = DA.Updateplant(ids, reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }

    }
}