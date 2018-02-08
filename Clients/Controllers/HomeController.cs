using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Clients.Models;
namespace Clients.Controllers
{
    public class HomeController : Controller
    {
        PersonContext context = new PersonContext();
        public ActionResult Index()
        {
            IEnumerable<Person> books = context.Persons;
            ViewBag.Books = books;
            return View();
        }

        [HttpGet]
        public JsonResult getCities()
        {

            var jsondata = context.Cities.ToList();
            List<Cities> list = new List<Cities>();
            foreach (Models.Cities obj in jsondata)
            {
                list.Add(new Cities(obj.CitiesID, obj.CityName));
            }
            DropDown dd = new DropDown(list);
                
            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        class Cities{

            public int value { get; set; }
            public string name { get; set; }

            public Cities(int Value, string Name)
            {
                this.value = Value;
                this.name = Name;
            }
        }
        class DropDown
        {
            public bool success=true;
            public List<Cities> results { get; set; }
            public DropDown(List<Cities> list)
            {
                this.results = list;
            }
        }
    }
}