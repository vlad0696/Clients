﻿using System;
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
    }
}