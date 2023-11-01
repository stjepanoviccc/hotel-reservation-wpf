using HotelReservations.Exceptions;
using HotelReservations.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private string ToCSV(Room room)
        {
            return $"{room.Id},{room.RoomNumber},{room.HasTV},{room.HasMiniBar},{room.RoomType.Id},{room.IsActive}";
        }

        private Room FromCSV(string csv)
        {
            string[] csvValues = csv.Split(',');

            var room = new Room();
            room.Id = int.Parse(csvValues[0]);
            room.RoomNumber = csvValues[1];
            room.HasTV = bool.Parse(csvValues[2]);
            room.HasMiniBar = bool.Parse(csvValues[3]);
            var roomTypeId = int.Parse(csvValues[4]);
            room.RoomType = Hotel.GetInstance().RoomTypes.Find(rt => rt.Id == roomTypeId);
            room.IsActive = bool.Parse(csvValues[5]);

            return room;
        }

        public void Save(List<Room> roomList)
        {
            try
            {
                using (var streamWriter = new StreamWriter("rooms.txt"))
                {
                    foreach (var room in roomList)
                    {
                        streamWriter.WriteLine(ToCSV(room));
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new CouldntPersistDataException(ex.Message);
            }
            
        }

        public List<Room> Load()
        {

            try
            {
                using (var streamReader = new StreamReader("rooms.txt"))
                {
                    List<Room> rooms = new List<Room>();
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var room = FromCSV(line);
                        if (room.IsActive)
                        {
                            rooms.Add(room);
                        }
                        
                    }

                    return rooms;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CouldntLoadResourceException(ex.Message);
            }
        }
    }
}
