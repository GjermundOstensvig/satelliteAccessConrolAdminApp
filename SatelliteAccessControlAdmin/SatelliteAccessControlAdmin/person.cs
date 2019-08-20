namespace SatelliteAccessControlAdmin
{
    //The person class is used to make a Collection of person objects that we can use as a source for ListView
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
