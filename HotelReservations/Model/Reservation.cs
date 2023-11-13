using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public Room Room { get; set; } // iz room moram izvuci roomType, da bi odredio TotalPrice formulom sa ResType(tako vucem sta treba iz roomType cjenovnika) i startdate i enddate
        public ReservationType ReservationType { get; set; }
        public List<Guest> Guests { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double TotalPrice { get; set; }

    }
}