using HotelReservations.Repositories;
using HotelReservations.Service;
using HotelReservations.Exceptions;
using HotelReservations.Model;
using HotelReservations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations
{
    public class DataUtil
    {
        public static void LoadData()
        {
            Hotel hotel = Hotel.GetInstance();
            hotel.Id = 1;
            hotel.Name = "Hotel Park";
            hotel.Address = "Kod Futoskog parka...";

            var singleBedRoom = new RoomType()
            {
                Id = 1,
                Name = "Singe Bed"
            };

            var doubleBedRoom = new RoomType()
            {
                Id = 2,
                Name = "Double Bed"
            };

            var room1 = new Room()
            {
                Id = 1,
                RoomNumber = "02",
                HasTV = false,
                HasMiniBar = true,
                RoomType = singleBedRoom,
                IsActive = true
            };

            var room2 = new Room()
            {
                Id = 2,
                RoomNumber = "01",
                HasTV = true,
                HasMiniBar = true,
                RoomType = doubleBedRoom,
                IsActive = true
            };

            hotel.RoomTypes.Add(singleBedRoom);
            hotel.RoomTypes.Add(doubleBedRoom);

            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);

            try
            {
                IRoomRepository roomRepository = new RoomRepository();
                var loadedRooms = roomRepository.Load();

                if (loadedRooms != null)
                {
                    Hotel.GetInstance().Rooms = loadedRooms;
                }

            }
            catch (CouldntLoadResourceException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
            catch (Exception ex)
            {
                Console.Write("An unexpected error occured", ex.Message);
            }
            
            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
                var loadedRoomTypes = roomTypeRepository.Load();
                
                if (loadedRoomTypes != null)
                {
                    Hotel.GetInstance().RoomTypes = loadedRoomTypes;
                }


            } catch (CouldntLoadResourceException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            } catch (Exception ex)
            {
                Console.Write("Unexpected error", ex.Message);
            }
        }

        public static void PersistData()
        {
            try
            {
                IRoomRepository roomRepository = new RoomRepository();
                roomRepository.Save(Hotel.GetInstance().Rooms);
            }
            catch (CouldntPersistDataException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }

            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
                roomTypeRepository.Save(Hotel.GetInstance().RoomTypes);
            } catch (CouldntPersistDataException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
        }
    }
}
