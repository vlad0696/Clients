using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Clients.Models;
using System.IO;
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

        [HttpPost]
        public ActionResult saveClient(Client client)
        {
            try
            {
               Client thisClient = context.Clients.Where(c => c.Series == client.Series).Where(c => c.Number == client.Number).FirstOrDefault();
                if (thisClient== null)
                {
                    thisClient = context.Clients.Where(c => c.PassportID == client.PassportID).FirstOrDefault();
                    if (thisClient == null)
                    {
                        context.Clients.Add(client);
                        context.SaveChanges();

                        return Json(new AjaxResponse(new AjaxResponse()));
                    }
                    else
                    {
                        return Json(new AjaxResponse(new Exception("Пользователь с таким Идентификационным номером пасспорта существует")));
                    }

                } 
                else
                    return Json(new AjaxResponse(new Exception("Пользователь с таким номером пасспорта существует")));
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        public JsonResult getCities()
        {

            var jsondata = context.Cities.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.Cities obj in jsondata)
            {
                list.Add(new DropdownValues(obj.CitiesID, obj.CityName));
            }
            DropDown dd = new DropDown(list);
                
            return Json(dd, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public JsonResult getFamilyPosition()
        {

            var jsondata = context.FamilyPosition.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.FamilyPosition obj in jsondata)
            {
                list.Add(new DropdownValues(obj.FamilyPositionID, obj.Position));
            }
            DropDown dd = new DropDown(list);

            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getDisabilities()
        {
            var jsondata = context.Disability.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.Disability obj in jsondata)
            {
                list.Add(new DropdownValues(obj.DisabilityID, obj.DisabilityName));
            }
            DropDown dd = new DropDown(list);

            return Json(dd, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getNationalitiy()
        {
            var jsondata = context.Nationality.ToList();
            List<DropdownValues> list = new List<DropdownValues>();
            foreach (Models.Nationality obj in jsondata)
            {
                list.Add(new DropdownValues(obj.NationalityID, obj.NationalityName));
            }
            DropDown dd = new DropDown(list);

            return Json(dd, JsonRequestBehavior.AllowGet);
        }

        class DropdownValues{

            public int value { get; set; }
            public string name { get; set; }

            public DropdownValues(int Value, string Name)
            {
                this.value = Value;
                this.name = Name;
            }
        }
        class DropDown
        {
            public bool success=true;
            public List<DropdownValues> results { get; set; }
            public DropDown(List<DropdownValues> list)
            {
                this.results = list;
            }
        }

        public class AjaxResponse
        {
            public AjaxResponse()
            {
                Success = true;
                Data = new List<object>();
            }

            public AjaxResponse(Exception exception)
                : this()
            {
                Success = false;
                Errors = new[] { exception.Message };
            }

            public AjaxResponse(object data)
                : this()
            {
                Data = data;
            }

            public bool Success
            {
                get; set;
            }
            public object Data
            {
                get; set;
            }
            public string[] Errors
            {
                get; set;
            }
        }
    }
}