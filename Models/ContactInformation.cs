using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvtTest.Models
{
    public class ContactInformation
    {
        public List<string> PhoneNumber { get; set; }
        public List<string> Email { get; set; }
        public List<string> Skype { get; set; }
        public string Other { get; set; }
    }
}
