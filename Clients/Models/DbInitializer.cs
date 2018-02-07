using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clients.Models
{
    public class DbInitializer: DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext db)
        {
            db.Persons.Add(new Person { Name = "Война и мир", SurName = "Л. Толстой", SecondName = "220", Gender = true, Email = "ad", Date = DateTime.Now });

            base.Seed(db);
        }
    }
}