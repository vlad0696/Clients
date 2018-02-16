using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Clients.Models
{
    public class Client
    {
        
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public String Gender { get; set; }
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Series { get; set; }
        [Required]
        public string PassportID { get; set; }
        [Required]
        public string IssueDate { get; set; }
        [Required]
        public int IssueAuthority { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        /// <summary>
        /// Город прописки
        /// </summary>
        [Required]
        public int ResidenceCityID { get; set; }
        /// <summary>
        /// Адрес прописки
        /// </summary>
        [Required]
        public string Residence { get; set; }
        /// <summary>
        /// Город проживания
        /// </summary>
        [Required]
        public int ActualCity { get; set; }
        /// <summary>
        /// Адрес проживания
        /// </summary>
        [Required]
        public string ActualAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        [Required]
        public int FamilyPositionID { get; set; }
        [Required]
        public int NationalityID { get; set; }
        [Required]
        public int DisabilityID { get; set; }
        public bool Pensioner { get; set; }
        public int Income { get; set; }
        public int Reservist { get; set; }
    }
}