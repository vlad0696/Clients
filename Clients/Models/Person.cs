using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public DateTime Date { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }

    }
}