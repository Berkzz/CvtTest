using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvtTest.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext()
            : base ("Contact")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
