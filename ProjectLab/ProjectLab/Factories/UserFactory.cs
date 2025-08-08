using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Factories
{
    public class UserFactory
    {
        public static User Create(string username, string email, string password, string gender, string role)
        {
            return new User
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserGender = gender,
                UserRole = role
            };
        }
    }
}