using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class ClientsDeposit
    {
        public int ClientsDepositID { get; set; }
        
        public int ClientID { get; set; }

        public int DepositID { get; set; }
            
        public string ClientDepositNumber { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public double Amount { get; set; }

        public int Period { get; set; }

       
    }
}