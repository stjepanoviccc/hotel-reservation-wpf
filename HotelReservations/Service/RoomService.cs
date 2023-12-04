﻿using HotelReservations.Model;
using HotelReservations.Repository;
using System.Collections.Generic;

namespace HotelReservations.Service
{
    public class RoomService
    {
        IRoomRepository roomRepository;
        public RoomService() 
        { 
            roomRepository = new RoomRepositoryDB();
        }

        public List<Room> GetAllRooms()
        {
            return Hotel.GetInstance().Rooms;
        }

        public Room GetRoomByRoomNumber(string roomNumber)
        {
            Room room = Hotel.GetInstance().Rooms.Find(rn => rn.RoomNumber == roomNumber);
            return room;
        }

        public void SaveRoom(Room room)
        {
            if (room.Id == 0)
            {
                Hotel.GetInstance().Rooms.Add(room);
                room.Id = roomRepository.Insert(room);
            }
            else
            {
                var index = Hotel.GetInstance().Rooms.FindIndex(r => r.Id == room.Id);
                Hotel.GetInstance().Rooms[index] = room;
                roomRepository.Update(room);
            }
        }

        public void MakeRoomInactive(Room room)
        {
            var makeRoomInactive = Hotel.GetInstance().Rooms.Find(r => r.Id == room.Id);
            makeRoomInactive.IsActive = false;
            roomRepository.Delete(room.Id);
        }
    }
}
