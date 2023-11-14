﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public ReservationType ReservationType { get; set; }
        public List<Guest> Guests { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; }
        public Reservation Clone()
        {
            var clone = new Reservation();
            clone.Id = Id;
            clone.RoomNumber = RoomNumber;
            clone.ReservationType = ReservationType;
            clone.Guests = Guests;
            clone.StartDateTime = StartDateTime;
            clone.EndDateTime = EndDateTime;
            clone.TotalPrice = TotalPrice;
            clone.IsActive = IsActive;

            return clone;
        }
    }
}