using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvtTest.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string DayOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public ContactInformation Contacts { get; set; }
    }
}
