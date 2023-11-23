using HotelReservations.Exceptions;
using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        public string ToCSV(Guest guest)
        {
            return $"{guest.Id},{guest.ReservationId},{guest.Name},{guest.Surname},{guest.JMBG},{guest.IsActive}";
        }
        private Guest FromCSV(string csv)
        {
            string[] csvValues = csv.Split(',');
            var guest = new Guest();
            guest.Id = int.Parse(csvValues[0]);
            guest.ReservationId = int.Parse(csvValues[1]);
            guest.Name = csvValues[2];
            guest.Surname = csvValues[3];
            guest.JMBG = csvValues[4];
            guest.IsActive = bool.Parse(csvValues[5]);
            return guest;
        }
        public List<Guest> Load()
        {
            try
            {
                using (var StreamReader = new StreamReader("guests.txt"))
                {
                    List<Guest> guestsList = new List<Guest>();
                    string line;
                    while ((line = StreamReader.ReadLine()) != null)
                    {
                        var guest = FromCSV(line);
                        guestsList.Add(guest);
                    }
                    return guestsList;
                }
            }
            catch (Exception ex)
            {
                throw new CouldntLoadResourceException(ex.Message);
            }
        }

        public void Save(List<Guest> guestsList)
        {
            try
            {
                using (var streamWriter = new StreamWriter("guests.txt"))
                {
                    foreach (var guest in guestsList)
                    {
                        streamWriter.WriteLine(ToCSV(guest));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CouldntPersistDataException(ex.Message);
            }
        }
    }
}
