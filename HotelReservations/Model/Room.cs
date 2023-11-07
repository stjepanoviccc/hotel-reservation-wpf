﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Model
{
    [Serializable]
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public bool HasTV { get; set; }
        public bool HasMiniBar { get; set; }
        public RoomType? RoomType { get; set; } = null;
        public bool IsActive { get; set; } = true;

        public override string ToString()
        {
            //return "Room number: " + RoomNumber; // ...
            return $"Room number: {RoomNumber}";
        }

        public Room Clone()
        {
            var clone = new Room();
            clone.Id = Id;
            clone.RoomNumber = RoomNumber;
            clone.HasTV = HasTV;
            clone.HasMiniBar = HasMiniBar;
            clone.RoomType = RoomType;
            clone.IsActive = IsActive;

            return clone;
        }
    }
}