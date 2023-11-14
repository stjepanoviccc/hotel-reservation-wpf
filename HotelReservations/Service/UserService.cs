using HotelReservations.Model;
using HotelReservations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Service
{
    internal class UserService
    {
        IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return Hotel.GetInstance().Users;
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                user.Id = GetNextId();
                Hotel.GetInstance().Users.Add(user);
            }
            else
            {
                var index = Hotel.GetInstance().Users.FindIndex(u => u.Id == user.Id);
                Hotel.GetInstance().Users[index] = user;
               // DataUtil.PersistData();
               // DataUtil.LoadData();
            }
        }

        public int GetNextId()
        {
            return Hotel.GetInstance().Users.Max(u => u.Id) + 1;
        }

        public User GetUserByUsername(string username)
        {
            var selectedUser = Hotel.GetInstance().Users.Find(u => u.Username == username);
            return selectedUser;
        }

        public void MakeUserInactive(User user)
        {
            var makeUserInactive = Hotel.GetInstance().Users.Find(u => u.Id == user.Id);
            makeUserInactive.IsActive = false;
        }

        public bool NameExist(User user)
        {
            foreach (User u in Hotel.GetInstance().Users)
            {
                if (u.Name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
