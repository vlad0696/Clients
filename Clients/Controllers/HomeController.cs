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
    }
}