using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class Contacts
    {
        public int ContactsID { get; set; }
        public int ActualCity { get; set; }
        public string ActualAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
    }
}