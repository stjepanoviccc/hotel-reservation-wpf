using HotelReservations.Model;
using HotelReservations.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservations.Service
{
    public class GuestService
    {
        IGuestRepository guestRepository;
        int contextLastId = 0;
        public GuestService()
        {
            guestRepository = new GuestRepositoryDB();
        }

        public List<Guest> GetAllGuests()
        {
            return Hotel.GetInstance().Guests;
        }

        public void SaveGuest(Guest guest, bool editing = false)
        {
            if (guest.Id == 0 && editing == false)
            {
                guest.ReservationId = 0;

                Hotel.GetInstance().Guests.Add(guest);
            }

            else
            {
                int resId = Hotel.GetInstance().Guests.Find(g => g.Id == guest.Id).ReservationId;
                guest.ReservationId = resId;
                var index = Hotel.GetInstance().Guests.FindIndex(g => (g.Id == guest.Id)&&(g.JMBG == guest.JMBG));
                Hotel.GetInstance().Guests[index] = guest;
                guestRepository.Update(guest);
            }
        }

        public void RewriteGuestIdAfterReservationIsCreated(int newReservationId)
        {
            var guestsToRewriteId = Hotel.GetInstance().Guests.Where(guest => guest.ReservationId == 0);
            foreach (Guest guest in guestsToRewriteId)
            {
                guest.ReservationId = newReservationId;
                // it will be added to database after getting real res id, not fake for in-memory.
                guestRepository.Insert(guest);
            }
        }

        public void MakeGuestInactive(Guest guest)
        {
            /*
            var index = Hotel.GetInstance().Guests.FindIndex(g => g.Id == guest.Id);
            guest.IsActive = false;
            Hotel.GetInstance().Guests[index] = guest; */
            var makeGuestInactive = Hotel.GetInstance().Guests.Find(g => (g.Id == guest.Id) && (g.JMBG == guest.JMBG));
            makeGuestInactive.IsActive = false;
            guestRepository.Delete(guest.Id);
        }
    }
}
