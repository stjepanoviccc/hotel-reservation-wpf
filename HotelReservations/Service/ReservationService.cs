using HotelReservations.Model;
using HotelReservations.Repositories;
using HotelReservations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    internal class ReservationService
    {
        IReservationRepository reservationRepository;
        PriceService priceService;
        GuestService guestService;
        RoomService roomService;

        public ReservationService()
        {
            reservationRepository = new ReservationRepository();
            guestService = new GuestService();
            priceService = new PriceService();
            roomService = new RoomService();
        }

        public List<Reservation> GetAllReservations()
        {
            return Hotel.GetInstance().Reservations;
        }

        // add
        public void SaveReservation(Reservation reservation, Room room)
        {
            reservation.RoomNumber = room.RoomNumber;

            if (reservation.StartDateTime == reservation.EndDateTime)
            {
                reservation.ReservationType = ReservationType.Day;
            }
            else
            {
                reservation.ReservationType = ReservationType.Night;
            }

            if (reservation.Id == 0)
            {
                reservation.Id = GetNextId();
                Hotel.GetInstance().Reservations.Add(reservation);
            }
            else
            {
                var index = Hotel.GetInstance().Rooms.FindIndex(r => r.Id == reservation.Id);
                Hotel.GetInstance().Reservations[index] = reservation;
            }

            // this will rewrite guests ID!
            guestService.RewriteGuestIdAfterReservationIsCreated(reservation.Id);
            reservation.Guests = Hotel.GetInstance().Guests.Where(guest => guest.ReservationId == reservation.Id).ToList();
        }

        // delete;
        public void MakeReservationInactive(Reservation reservation)
        {
            var makeReservationInactive = Hotel.GetInstance().Reservations.Find(r => r.Id == reservation.Id);
            makeReservationInactive.IsActive = false;
        }

        public double FinishReservation(Reservation reservation)
        {
            var resType = reservation.ReservationType;
            int dateDifference = GetDateDifference(reservation.StartDateTime, reservation.EndDateTime);

            Room room = roomService.GetRoomByRoomNumber(reservation.RoomNumber);
            Price price = priceService.GetAllPrices().Find(price => price.RoomType.ToString() == room.RoomType.ToString() && price.ReservationType == resType);

            reservation.TotalPrice = dateDifference * price.PriceValue;

            MakeReservationInactive(reservation);

            return reservation.TotalPrice;
        }

        public int GetDateDifference(DateTime start, DateTime end)
        {
            if (start.Date == end.Date)
            {
                return 1;
            }
            
            TimeSpan difference = end.Date - start.Date;
            return (int)difference.TotalDays;
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().Reservations.Max(r => r.Id) + 1;
        }
    }
}
