using HotelReservations.Windows;
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
    public class RoomTypeRepository : IRoomTypeRepository
    {

        public string ToCSV(RoomType roomType) 
        {
            return $"{roomType.Id},{roomType.Name},{roomType.IsActive}";
        }
        private RoomType FromCSV(string csv) 
        {
            string[] csvValues = csv.Split(',');
            var roomType = new RoomType();
            roomType.Id = int.Parse(csvValues[0]);
            roomType.Name = csvValues[1];
            roomType.IsActive = bool.Parse(csvValues[2]);
            return roomType;
        }
        public List<RoomType> Load()
        {
            try
            {
                using (var StreamReader = new StreamReader("roomTypes.txt")) 
                {
                    List<RoomType> roomTypesList = new List<RoomType>();
                    string line;
                    while ((line = StreamReader.ReadLine()) != null) 
                    {
                        var roomType = FromCSV(line);
                        roomTypesList.Add(roomType);
                    }
                    return roomTypesList;
                }

            } catch (Exception ex)
            {
                throw new CouldntLoadResourceException(ex.Message);
            }
        }

        public void Save(List<RoomType> roomTypeList) 
        {
            try
            {
                using (var streamWriter = new StreamWriter("roomTypes.txt")) 
                { 
                    foreach(var roomType in roomTypeList)
                    {
                        streamWriter.WriteLine(ToCSV(roomType));
                    }
                }

            } catch (Exception ex)
            {
                throw new CouldntPersistDataException(ex.Message);
            }
        }
    }
}