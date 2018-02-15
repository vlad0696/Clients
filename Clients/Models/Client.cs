using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public string DOB { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Series { get; set; }
        public string PassportID { get; set; }
        public string IssueDate { get; set; }
        public int IssueAuthority { get; set; }
        public string BirthPlace { get; set; }
        public int ResidenceCityID { get; set; }
        public string Residence { get; set; }
        public int ActualCity { get; set; }
        public string ActualAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
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