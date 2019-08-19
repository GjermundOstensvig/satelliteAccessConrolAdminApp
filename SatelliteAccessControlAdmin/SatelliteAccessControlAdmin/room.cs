using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatelliteAccessControlAdmin
{
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
