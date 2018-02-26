using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class InterestCredit
    {
        public int InterestCreditID { get; set; }

        public int ClientsCreditID { get; set; }

        public string InterestCreditNumber { get; set; }

        public double Amount { get; set; }

        public double MonthlyPayment { get; set; }

        public double LastMonthlyPayment { get; set; }

        public bool Active { get; set; }

        public int Period { get; set; }
        public int PayMonths { get; set;}
    }
}