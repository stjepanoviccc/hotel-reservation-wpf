using HotelReservations.Repositories;
using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    public class RoomTypeService
    {

        IRoomTypeRepository roomTypeRepository;

        public RoomTypeService() 
        {
            roomTypeRepository = new RoomTypeRepository();

        }

        public List<RoomType> GetAllRoomTypes()
        {
            return Hotel.GetInstance().RoomTypes;
        }

        public void SaveRoomType(RoomType roomType)
        {
            Hotel.GetInstance().RoomTypes.Add(roomType);
        } 

        public int GetNextRoomTypeId(int roomTypeId)
        {
            return Hotel.GetInstance().RoomTypes.Max(r => r.Id) + 1;
        }

        public RoomType GetRoomTypeByName(string roomTypeName)
        {
            var selectedRoomType = Hotel.GetInstance().RoomTypes.Find(rt => rt.Name == roomTypeName);
            return selectedRoomType!;
        }
       
    }
}
