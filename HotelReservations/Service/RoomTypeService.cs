using HotelReservations.Repositories;
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
                var index = Hotel.GetInstance().RoomTypes.FindIndex(r => r.Id == roomType.Id);
                Hotel.GetInstance().RoomTypes[index] = roomType;
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
