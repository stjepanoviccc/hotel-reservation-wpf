using HotelReservations.Model;
using HotelReservations.Repository;
using HotelReservations.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    public class RoomService
    {
        IRoomRepository roomRepository;
        public RoomService() 
        { 
            roomRepository = new RoomRepository();
        }

        public List<Room> GetAllRooms()
        {
            return Hotel.GetInstance().Rooms;
        }

        public List<Room> GetSortedRooms()
        {
            var rooms = Hotel.GetInstance().Rooms.Where(room => room.IsActive).ToList();
            rooms.Sort((r1, r2) => r1.RoomNumber.CompareTo(r2.RoomNumber));
            return rooms;
        }

        public List<Room> GetAllRoomsByRoomNumber(string startingWith)
        {
            var rooms = Hotel.GetInstance().Rooms;
            var filteredRooms = rooms.FindAll((r) => r.RoomNumber.StartsWith(startingWith));
            return filteredRooms;
        }

        public Room GetRoomByRoomNumber(string roomNumber)
        {
            Room room = Hotel.GetInstance().Rooms.Find(rn => rn.RoomNumber == roomNumber);
            return room;
        }

        // add
        public void SaveRoom(Room room)
        {
            if (room.Id == 0)
            {
                room.Id = GetNextId();
                Hotel.GetInstance().Rooms.Add(room);
            }
            else
            {
                var index = Hotel.GetInstance().Rooms.FindIndex(r => r.Id == room.Id);
                Hotel.GetInstance().Rooms[index] = room;
            }
        }

        // delete;
        public void MakeRoomInactive(Room room)
        {
            var makeRoomInactive = Hotel.GetInstance().Rooms.Find(r => r.Id == room.Id);
            makeRoomInactive.IsActive = false;
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().Rooms.Max(r => r.Id) + 1;
        }
    }
}
