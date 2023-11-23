﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Model
{
    public class User
    {
        public int Id { get; set; }
        private string name = string.Empty;
        private string surname = string.Empty;
        private string jmbg = string.Empty;
        private string password = string.Empty;
        private string username = string.Empty;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is required");
                }

                name = value;
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Surname is required");
                }
                surname = value;
            }
        }
        public string JMBG
        {
            get { return jmbg; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("JMBG is required");
                }
                jmbg = value;
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username is required");
                }

                username = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password is required");
                }

                password = value;
            }
        }

        public UserType UserType { get; set; }

        public bool IsActive { get; set; } = true;

        public User Clone()
        {
            var clone = new User();
            clone.Id = Id;
            clone.Username = Username;
            clone.Name = Name;
            clone.Surname = Surname;
            clone.JMBG = JMBG;
            clone.Password = Password;
            clone.UserType = UserType;
            return clone;
        }
    }
}
