using HotelReservations.Model;
using HotelReservations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    public class GuestService
    {
        IGuestRepository guestRepository;
        public GuestService()
        {
            guestRepository = new GuestRepository();
        }

        public List<Guest> GetAllGuests()
        {
            return Hotel.GetInstance().Guests;
        }

        public void SaveGuest(Guest guest, bool editing=false)
        {
            if (guest.Id == 0)
            {
                guest.Id = GetNextId();

                // if im adding because res isnt created yet
                if (!editing)
                {
                    guest.ReservationId = 0;
                }

                Hotel.GetInstance().Guests.Add(guest);
            }
            else
            {
                var index = Hotel.GetInstance().Guests.FindIndex(g => g.Id == guest.Id);
                Hotel.GetInstance().Guests[index] = guest;
                // DataUtil.PersistData();
                // DataUtil.LoadData();
            }
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().Guests.Max(g => g.Id) + 1;
        }

        public void MakeGuestInactive(Guest guest)
        {
            var makeGuestInactive = Hotel.GetInstance().Guests.Find(g => g.Id == guest.Id);
            makeGuestInactive.IsActive = false;
        }
    }
}
