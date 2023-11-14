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
    public class ReservationRepository : IReservationRepository
    {
        private string ToCSV(Reservation res)
        {
            return $"{res.Id}";
        }

        private Reservation FromCSV(string csv)
        {
            string[] csvValues = csv.Split(',');

            var reservation = new Reservation();
            return reservation;
        }

        public void Save(List<Reservation> reservationList)
        {
            try
            {
                using (var streamWriter = new StreamWriter("reservations.txt"))
                {
                    foreach (var res in reservationList)
                    {
                        streamWriter.WriteLine(ToCSV(res));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CouldntPersistDataException(ex.Message);
            }
        }

        public List<Reservation> Load()
        {
            try
            {
                using (var streamReader = new StreamReader("reservations.txt"))
                {
                    List<Reservation> reservations = new List<Reservation>();
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var res = FromCSV(line);
                        reservations.Add(res);
                    }

                    return reservations;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CouldntLoadResourceException(ex.Message);
            }
        }
    }
}
