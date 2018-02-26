using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PassportData> PassportData { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<PersonInfo> PersonInfo { get; set; }
        public DbSet<FamilyPosition> FamilyPosition{ get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Disability> Disability { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<ClientsDeposit> ClientsDeposits { get; set; }
        public DbSet<InterestDeposit> InterestDeposits { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<ClientsCredit> ClientsCredit { get; set; }
        public DbSet<InterestCredit> InterestCredit { get; set; }

    }
}