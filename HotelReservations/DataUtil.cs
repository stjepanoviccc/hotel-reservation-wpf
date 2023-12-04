using HotelReservations.Repositories;
using HotelReservations.Exceptions;
using HotelReservations.Model;
using HotelReservations.Repository;
using System;

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
            /*
            var singleBedRoom = new RoomType()
            {
                Id = 1,
                Name = "Single Bed",
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
                RoomType = singleBedRoom,
                IsActive = true
            }; 

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

            Guest testGuest = new Guest()
            {
                Id = 1,
                // -1 when making to make sure reservation isnt added yet.
                ReservationId = 1,
                Name = "Guest",
                Surname = "Guest",
                JMBG = "0000000000001",
                IsActive = true
            };

            List<Guest> initialGuests = new List<Guest>();
            Reservation res = new Reservation()
            {
                Id = 1,
                RoomNumber = "01",
                ReservationType = ReservationType.Day,
                Guests = initialGuests,
                StartDateTime = DateTime.Now,
                EndDateTime = DateTime.Now,
                TotalPrice = 0,
                IsActive = true
            };

            hotel.Reservations.Add(res);

            hotel.Guests.Add(testGuest);

            hotel.RoomTypes.Add(singleBedRoom);
            hotel.RoomTypes.Add(doubleBedRoom);

            hotel.Prices.Add(price1);
            hotel.Prices.Add(price2);

          
            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            */


            var resTypeDay = ReservationType.Day;
            var resTypeNight = ReservationType.Night;

            var userTypeAdministrator = UserType.Administrator;
            var userTypeReceptionist = UserType.Receptionist;

            hotel.UserTypes.Add(userTypeAdministrator);
            hotel.UserTypes.Add(userTypeReceptionist);

            hotel.ReservationTypes.Add(resTypeDay);
            hotel.ReservationTypes.Add(resTypeNight);

            try
            {
                IRoomTypeRepository roomTypeRepository = new RoomTypeRepositoryDB();
                IUserRepository usersRepository = new UserRepositoryDB();
                IRoomRepository roomRepository = new RoomRepositoryDB();
                IPriceRepository priceRepository = new PriceRepository();
                IGuestRepository guestRepository = new GuestRepository();
                IReservationRepository reservationRepository = new ReservationRepository();

                var loadedRoomTypes = roomTypeRepository.GetAll();
                if (loadedRoomTypes != null)
                {
                    Hotel.GetInstance().RoomTypes = loadedRoomTypes;
                }

                var loadedRooms = roomRepository.GetAll();
                if (loadedRooms != null)
                {
                    Hotel.GetInstance().Rooms = loadedRooms;
                }

                var loadedUsers = usersRepository.GetAll();
                if (loadedUsers != null)
                {
                    Hotel.GetInstance().Users = loadedUsers;
                }

                var loadedPriceRepository = priceRepository.Load();
                if (loadedPriceRepository != null)
                {
                    Hotel.GetInstance().Prices = loadedPriceRepository;
                }

                var loadedGuestsRepository = guestRepository.Load();
                if (loadedGuestsRepository != null)
                {
                    Hotel.GetInstance().Guests = loadedGuestsRepository;
                }

                var loadedReservationRepository = reservationRepository.Load();
                if (loadedReservationRepository != null)
                {
                    Hotel.GetInstance().Reservations = loadedReservationRepository;
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
                IPriceRepository priceRepository = new PriceRepository();
                IGuestRepository guestRepository = new GuestRepository();
                IReservationRepository reservationRepository = new ReservationRepository();

                priceRepository.Save(Hotel.GetInstance().Prices);
                guestRepository.Save(Hotel.GetInstance().Guests);
                reservationRepository.Save(Hotel.GetInstance().Reservations);
            }
            catch (CouldntPersistDataException)
            {
                Console.WriteLine("Call an administrator, something weird is happening with the files");
            }
        }
    }
}
