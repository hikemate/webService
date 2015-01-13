using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HikeMateWebsite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult trackRecord()
        {
            return View();

        }

        public ActionResult GetLocations()
        {
            var locations = new List<Models.Locations>();
            using (hikeMateDBEntities context = new hikeMateDBEntities())
            {
                try
                {
                    var query = from category in context.Cordinates
                                select new
                                {
                                    latitude = category.latitude,
                                    longitude = category.longitude
                                };

                    foreach (var categoryInfo in query)
                    {
                        locations.Add(new Models.Locations(categoryInfo.latitude, categoryInfo.longitude));
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
         /*   var locations = new List<Models.Locations>()
            {
                new Models.Locations("6.9344", "79.8428")
            };*/

            return Json(locations, JsonRequestBehavior.AllowGet);
        }

    }
}
