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

            Receptionist receptionist1 = new Receptionist()
            {
                Id = 1,
                JMBG = "1212121212121",
                Name = "Petar",
                Surname = "Perić",
                Username = "pera",
                Password = "password",
                IsActive = true
            };
            Receptionist receptionist2 = new Receptionist()
            {
                Id = 2,
                JMBG = "2323232323232",
                Name = "Marko",
                Surname = "Marković",
                Username = "marko",
                Password = "password",
                IsActive = true
            };
            Administrator administrator1 = new Administrator()
            {
                Id = 3,
                JMBG = "3434343434343",
                Name = "Marija",
                Surname = "Marić",
                Username = "marija",
                Password = "password",
                IsActive = true
            };
            User user1 = new User()
            {
                Id = 4,
                JMBG = "2211000181755",
                Name = "Andrej",
                Surname = "Stjepanovic",
                Username = "andrej",
                Password = "password",
                IsActive = true
            };

            var resTypeDay = ReservationType.Day;
            var resTypeNight = ReservationType.Night;

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

            hotel.ReservationTypes.Add(resTypeDay);
            hotel.ReservationTypes.Add(resTypeNight);

            hotel.RoomTypes.Add(singleBedRoom);
            hotel.RoomTypes.Add(doubleBedRoom);

            hotel.Prices.Add(price1);
            hotel.Prices.Add(price2);

            hotel.Users.Add(administrator1);
            hotel.Users.Add(receptionist1);
            hotel.Users.Add(receptionist2);
            hotel.Users.Add(user1);

            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);

            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepository();
                IUserRepository usersRepository = new UserRepository();
                IRoomRepository roomRepository = new RoomRepository();

                var loadedRoomTypes = roomTypeRepository.Load();                
                var loadedUsers = usersRepository.Load();                
                var loadedRooms = roomRepository.Load();

                if (loadedRoomTypes != null && loadedRooms != null && loadedUsers != null)
                {
                    Hotel.GetInstance().RoomTypes = loadedRoomTypes;
                    Hotel.GetInstance().Users = loadedUsers;
                    Hotel.GetInstance().Rooms = loadedRooms;
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

                usersRepository.Save(Hotel.GetInstance().Users);
                roomTypeRepository.Save(Hotel.GetInstance().RoomTypes);
                roomRepository.Save(Hotel.GetInstance().Rooms);                
                
            }
            catch (CouldntPersistDataException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
        }
    }
}
