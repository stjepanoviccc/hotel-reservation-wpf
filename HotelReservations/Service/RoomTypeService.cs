﻿using HotelReservations.Repositories;
using HotelReservations.Model;
using System.Collections.Generic;

namespace HotelReservations.Service
{
    public class RoomTypeService
    {

        IRoomTypeRepository roomTypeRepository;
        RoomService roomService;

        public RoomTypeService()
        {
            roomTypeRepository = new RoomTypeRepositoryDB();
            roomService = new RoomService();

        }

        public List<RoomType> GetAllRoomTypes()
        {
            return Hotel.GetInstance().RoomTypes;
        }

        public void SaveRoomType(RoomType roomType)
        {
            if (roomType.Id == 0)
            {
                roomType.Id = roomTypeRepository.Insert(roomType);
                Hotel.GetInstance().RoomTypes.Add(roomType);
            }
            else
            {
                var rooms = Hotel.GetInstance().Rooms;
                var index = Hotel.GetInstance().RoomTypes.FindIndex(r => r.Id == roomType.Id);
                Hotel.GetInstance().RoomTypes[index] = roomType;

                // just in memory refresher.
                foreach (var room in rooms)
                {
                    if(room.RoomType.Id == roomType.Id)
                    {
                        room.RoomType = roomType;
                    }
                }

                // database update
                roomTypeRepository.Update(roomType);
            }
        }

        public RoomType GetRoomTypeByName(string roomTypeName)
        {
            var selectedRoomType = Hotel.GetInstance().RoomTypes.Find(rt => rt.Name == roomTypeName);
            return selectedRoomType!;
        }

        public void MakeRoomTypeInactive(RoomType roomType)
        {
            var makeRoomTypeInactive = Hotel.GetInstance().RoomTypes.Find(r => r.Id == roomType.Id);
            makeRoomTypeInactive.IsActive = false;
            roomTypeRepository.Delete(roomType.Id);
        }

        // validation method for checking does roomtype already exist ( i could do that in validate block but i wanted to make it more clean
        public bool IsRoomTypeInUse(RoomType roomType)
        {
            foreach (Room room in Hotel.GetInstance().Rooms)
            {
                if (room.RoomType == roomType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
