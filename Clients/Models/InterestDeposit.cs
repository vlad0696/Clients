using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class InterestDeposit
    {
        public int InterestDepositID { get; set; }

        public int ClientsDepositID { get; set; }

        public string InterestDepositNumber { get; set; }
        
        public double Amount { get; set; }

        public double InitialAmount { get; set; }

        public int Percent { get; set; }

        public bool Active { get; set; }

    }
}