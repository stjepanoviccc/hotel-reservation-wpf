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
    public class UserRepository : IUserRepository
    {
        public string ToCSV(User user)
        { 
            return $"{user.Id},{user.Username},{user.Name},{user.Surname},{user.Password},{user.JMBG},{user.UserType},{user.IsActive}";
        }
        private User FromCSV(string csv)
        {
            string[] csvValues = csv.Split(',');
            var user = new User();
            user.Id = int.Parse(csvValues[0]);
            user.Username = csvValues[1];
            user.Name = csvValues[2];
            user.Surname = csvValues[3];
            user.Password = csvValues[4];
            user.JMBG = csvValues[5];
            var userType = csvValues[6];
            user.UserType = Hotel.GetInstance().UserTypes.Find(res => res.ToString() == userType);
            user.IsActive = bool.Parse(csvValues[7]);
            return user;
        }
        public List<User> Load()
        {
            try
            {
                using (var StreamReader = new StreamReader("users.txt"))
                {
                    List<User> userList = new List<User>();
                    string line;
                    while ((line = StreamReader.ReadLine()) != null)
                    {
                        var user = FromCSV(line);
                        userList.Add(user);
                    }
                    return userList;
                }
            }
            catch (Exception ex)
            {
                throw new CouldntLoadResourceException(ex.Message);
            }
        }

        public void Save(List<User> userList)
        {
            try
            {
                using (var streamWriter = new StreamWriter("users.txt"))
                {
                    foreach (var user in userList)
                    {
                        streamWriter.WriteLine(ToCSV(user));
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
