using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class Credit
    {
        public int CreditID { get; set; }

        public int BalanceId { get; set; }

        public bool Diff { get; set; }

        public int Percent { get; set; }

        public string DepositName { get; set; }

        public int CurrencyID { get; set; }

        public int Period { get; set; }
    }
}