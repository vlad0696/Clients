using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class PersonInfo
    {
        public int PersonInfoID { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public int FamilyPositionID { get; set; }
        public int NationalityID { get; set; }
        public int DisabilityID { get; set; }
        public bool Pensioner { get; set; }
        public int Income { get; set; }
        public int Reservist { get; set; }
    }
}