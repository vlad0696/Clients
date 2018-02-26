using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class ClientsCredit
    {
        public int ClientsCreditID { get; set; }

        public int ClientID { get; set; }

        public int CreditID { get; set; }

        public string ClientCreditNumber { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public double Amount { get; set; }

        public int Period { get; set; }

        public bool Diff { get; set; }

        public bool Active { get; set; }
    }
}