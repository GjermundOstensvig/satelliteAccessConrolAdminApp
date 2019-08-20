namespace SatelliteAccessControlAdmin
{
    //The room class is used to make a Collection of room objects that we can use as a source for ListView
    public class room
    {
        public room(string RoomNumber, string Floor)
        {
            this.RoomNumber = RoomNumber;
            this.Floor = Floor;
        }
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
    }
}
