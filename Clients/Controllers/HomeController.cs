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

            return View();
        }


        public ActionResult Clients(int sort =0)
        {
            List<Client> Clients = context.Clients.ToList();
            if (sort == 1)
            {
                Clients.Sort(delegate (Client cl1, Client cl2) { return cl1.SurName.CompareTo(cl2.SurName); });
            }
            ViewBag.Clients = Clients;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            Client Client = context.Clients.Where(c=>c.ClientID==id).First();
            ViewBag.Clients = Client;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            Client Client = context.Clients.Where(c => c.ClientID == client.ClientID).First();
            context.Entry(Client).CurrentValues.SetValues(client);
            context.SaveChanges();
            ViewBag.Clients = Client;
            return Json(new AjaxResponse(new AjaxResponse()));
        }

        public void Delete(int id)
        {
            Client Client = context.Clients.Where(c => c.ClientID == id).First();
            context.Clients.Remove(Client);
            context.SaveChanges();
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

    }
}