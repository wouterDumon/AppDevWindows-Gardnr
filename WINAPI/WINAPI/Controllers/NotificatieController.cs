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
    public class NotificatieController : Controller
    {
        // GET: Notificatie
 
        [HttpGet]
        public ActionResult Index(int? Plantid, string a)
        {
            if (Plantid.HasValue)
            {
                if (a == "Plant")
                {
                    //   int ids = Int32.Parse(id);
                    List<Notificatie> p = new List<Notificatie>();
                    p = DA.GetNotificatieperPlant(Int32.Parse(Plantid.Value.ToString()));
                    ViewBag.Json = JsonConvert.SerializeObject(p);
                } else if(a=="Gebruiker") {
                    List<Notificatie> p = new List<Notificatie>();
                    p = DA.GetNotificatieperGebruiker(Int32.Parse(Plantid.Value.ToString()));
                    ViewBag.Json = JsonConvert.SerializeObject(p);
                }
                else {
                    Notificatie p = new Notificatie();
                    p = DA.GetNotificatieperID(Int32.Parse(Plantid.Value.ToString()));
                    ViewBag.Json = JsonConvert.SerializeObject(p);
                }
            }
            return View();
        }
        [HttpPut]
        public ActionResult Edit(Notificatie reg)
        {

            int rows = DA.AddNotificatie(reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int? id, Notificatie reg)
        {
            if (!id.HasValue) return RedirectToAction("Index");
            int ids = Convert.ToInt32(id);
            if (reg == null) RedirectToAction("Index");
            int rows = DA.Updatenotificatie(ids, reg);
            //     int rows = DA.Updateorg(id, organ);
            //   Console.WriteLine(rows + "affected");
            ViewBag.Json = rows;
            return View();
        }
    }
}