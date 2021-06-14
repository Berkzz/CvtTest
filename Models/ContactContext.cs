using System.Data.Entity;

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
