using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class PassportData
    {
        public int PassportDataID { get; set; }
        public string Number { get; set; }
        public string Series { get; set; }
        public string PassportID { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueAuthority { get; set; }
        public string BirthPlace { get; set; }
        public int ResidenceCityID { get; set; }
        public string Residenve { get; set; }
    }
}