using HotelReservations.Repositories;
using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservations.Windows;

namespace HotelReservations.Service
{
    public class RoomTypeService
    {

        IRoomTypeRepository roomTypeRepository;
        RoomService roomService;

        public RoomTypeService()
        {
            roomTypeRepository = new RoomTypeRepository();
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
                roomType.Id = GetNextId();
                Hotel.GetInstance().RoomTypes.Add(roomType);
            }
            else
            {
                var index = Hotel.GetInstance().RoomTypes.FindIndex(r => r.Id == roomType.Id);
                Hotel.GetInstance().RoomTypes[index] = roomType;
                DataUtil.PersistData();
                DataUtil.LoadData();
            }
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().RoomTypes.Max(r => r.Id) + 1;
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
        }

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
