using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ProjectLab.Factories;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Handlers
{
    public class UserHandler
    {
        public static Response<User> LoginUser(string username, string password)
        {
            User user = UserRepository.getUserByUsername(username);
            if (user == null)
            {
                return new Response<User> { Success = false, Message = "User not found" };
            }
            if (user.UserPassword != password)
            {
                return new Response<User> { Success = false, Message = "Invalid credentials" };
            }
            return new Response<User> { Success = true, Message = "", Payload = user };
        }

        public static Response<User> RegisterUser(string username, string email, string password, string gender, string role)
        {
            User user = UserFactory.Create(username, email, password, gender, role);
            UserRepository.createUser(user);
            return new Response<User> { Success = true, Message = " ", Payload = user };
        }

        public static Response<User> UpdateUser(int id, string newUsername, string newEmail, string newPassword, string newGender)
        {
            UserRepository.UpdateUser(id, newUsername, newEmail, newPassword, newGender);
            return new Response<User> { Success = true, Message = " " };
        }
    }
}