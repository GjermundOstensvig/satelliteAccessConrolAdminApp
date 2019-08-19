using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteAccessControlAdmin
{
    public class person
    {
        public person(string PersonId, string FirstName, string LastName, string eMail, string PhoneNumber)
        {
            this.PersonId = PersonId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.eMail = eMail;
            this.PhoneNumber = PhoneNumber;
        }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string eMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
