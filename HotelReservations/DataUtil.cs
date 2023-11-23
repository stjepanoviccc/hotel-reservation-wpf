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
                Name = "Singe Bed",
                IsActive = true
            };

            var doubleBedRoom = new RoomType()
            {
                Id = 2,
                Name = "Double Bed",
                IsActive = true
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

            var resTypeDay = ReservationType.Day;
            var resTypeNight = ReservationType.Night;

            var userTypeAdministrator = UserType.Administrator;
            var userTypeReceptionist = UserType.Receptionist;

            Price price1 = new Price()
            {
                Id = 1,
                RoomType = singleBedRoom,
                ReservationType = resTypeDay,
                PriceValue = 2000,
                IsActive = true
            };

            Price price2 = new Price()
            {
                Id = 2,
                RoomType = singleBedRoom,
                ReservationType = resTypeNight,
                PriceValue = 3000,
                IsActive = true
            };

            hotel.UserTypes.Add(userTypeAdministrator);
            hotel.UserTypes.Add(userTypeReceptionist);

            hotel.ReservationTypes.Add(resTypeDay);
            hotel.ReservationTypes.Add(resTypeNight);

            hotel.RoomTypes.Add(singleBedRoom);
            hotel.RoomTypes.Add(doubleBedRoom);

            hotel.Prices.Add(price1);
            hotel.Prices.Add(price2);

            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);

            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
                IUserRepository usersRepository = new UserRepository();
                IRoomRepository roomRepository = new RoomRepository();
                IPriceRepository priceRepository = new PriceRepository();

                var loadedRoomTypes = roomTypeRepository.Load();                
                var loadedUsers = usersRepository.Load();
                var loadedRooms = roomRepository.Load();
                var loadedPriceRepository = priceRepository.Load();

                if (loadedRoomTypes != null && loadedRooms != null && loadedUsers != null && loadedPriceRepository != null)
                {
                    Hotel.GetInstance().RoomTypes = loadedRoomTypes;
                    Hotel.GetInstance().Users = loadedUsers;
                    Hotel.GetInstance().Rooms = loadedRooms;
                    Hotel.GetInstance().Prices = loadedPriceRepository;
                }
            }
            catch (CouldntLoadResourceException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
            catch (Exception ex)
            {
                Console.Write("Unexpected error", ex.Message);
            }
        }

        public static void PersistData()
        {
            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
                IUserRepository usersRepository = new UserRepository();
                IRoomRepository roomRepository = new RoomRepository();
                IPriceRepository priceRepository = new PriceRepository();

                usersRepository.Save(Hotel.GetInstance().Users);
                roomTypeRepository.Save(Hotel.GetInstance().RoomTypes);
                roomRepository.Save(Hotel.GetInstance().Rooms);
                priceRepository.Save(Hotel.GetInstance().Prices);
            }
            catch (CouldntPersistDataException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
        }
    }
}
