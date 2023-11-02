using HotelReservations.Model;
using HotelReservations.Repository;
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
            return Hotel.GetInstance().Rooms.Where(room => room.IsActive).ToList(); ;
        }

        public List<Room> GetSortedRooms()
        {
            var rooms = Hotel.GetInstance().Rooms;
            rooms.Sort((r1, r2) => r1.RoomNumber.CompareTo(r2.RoomNumber));
            return rooms;
        }

        public List<Room> GetAllRoomsByRoomNumber(string startingWith)
        {
            var rooms = Hotel.GetInstance().Rooms;
            var filteredRooms = rooms.FindAll((r) => r.RoomNumber.StartsWith(startingWith));
            return filteredRooms;
        }

        public void SaveRoom(Room newRoom)
        {
            Hotel.GetInstance().Rooms.Add(newRoom);
        }

        public void OverwriteRoom(Room newRoomData)
        {
            var existingRoom = Hotel.GetInstance().Rooms.Find(room => room.Id == newRoomData.Id);
            existingRoom.RoomNumber = newRoomData.RoomNumber;
            existingRoom.HasTV = newRoomData.HasTV;
            existingRoom.HasMiniBar = newRoomData.HasMiniBar;
            existingRoom.IsActive = newRoomData.IsActive;
            existingRoom.RoomType = newRoomData.RoomType;
            // OBAVEZNO PITATI PROFESORA!!!
            DataUtil.PersistData();
        }

        // make room inactive (logical delete);
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
