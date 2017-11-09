using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParksDAL dal;
        
        public HomeController(IParksDAL parkDAL)
        {
            this.dal = parkDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Park> model = dal.GetAllParks();
            return View("Index",model);
        }

        public ActionResult ParkDetails(string parkID)
        {
            Park park = dal.GetAPark(parkID);
            List<Weather> weather = dal.GetParkWeather(parkID);
            ParkWeather model = new ParkWeather(park, weather);

            if (Session["tempPreference"] == null)
            {
                Session["tempPreference"] = true;
                model.isFahrenheit = (bool)Session["tempPreference"];                
            }
            else
            {
                model.isFahrenheit = (bool)Session["tempPreference"];
            }

            return View("ParkDetails", model);
        }

 
        public ActionResult ParkDetailsCelsius(string parkID)
        {
            Park park = dal.GetAPark(parkID);
            List<Weather> weather = dal.GetParkWeather(parkID);
            ParkWeather model = new ParkWeather(park, weather);

            if ( (bool)Session["tempPreference"] == false)
            {
                Session["tempPreference"] = true;
                model.isFahrenheit = (bool)Session["tempPreference"];
            } else
            {
                Session["tempPreference"] = false;
                model.isFahrenheit = (bool)Session["tempPreference"];
            }


            return View("ParkDetails", model);
        }

        public ActionResult CompanionApp()
        {
            return View("CompanionApp");
        }

        public ActionResult ContactUs()
        {
            return View("ContactUs");
        }

        public ActionResult EducationPartnership()
        {
            return View("EducationPartnership");
        }
       
    }
}