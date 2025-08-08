using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ProjectLab.Handlers;
using ProjectLab.Models;

namespace ProjectLab.Controllers
{
    public class UserController
    {
        public static Response<User> LoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new Response<User> { Success = false, Message = "All fields required" };
            }

            return UserHandler.LoginUser(username, password);
        }

        public static Response<User> RegisterUser(string username, string email, string password, string gender, string passwordConfirm, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(passwordConfirm))
            {
                return new Response<User> { Success = false, Message = "All fields required" };
            }

            if (username.Length < 5 || username.Length > 30)
            {
                return new Response<User> { Success = false, Message = "Username must be between 5 and 30 characters" };
            }

            if (!IsValidUsername(username))
            {
                return new Response<User> { Success = false, Message = "Username must be alphabet with space only" };
            }

            if (!email.Contains("@"))
            {
                return new Response<User> { Success = false, Message = "Invalid email format" };
            }

            if (password.Length < 8)
            {
                return new Response<User> { Success = false, Message = "Password must be at least 8 characters" };
            }

            if (!IsValidPassword(password))
            {
                return new Response<User> { Success = false, Message = "Password must be alphanumeric" };
            }

            if(passwordConfirm != password)
            {
                return new Response<User> { Success = false, Message = "Confirmation password is not the same as password" };
            }

            return UserHandler.RegisterUser(username, email, password, gender, role);
        }

        public static Response<User> UpdateUser(User user, string newUsername, string newEmail, string oldPassword, string newPassword, string passwordConfirm, string newGender)
        {
            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(passwordConfirm) || string.IsNullOrWhiteSpace(newGender))
            {
                return new Response<User> { Success = false, Message = "All fields required" };
            }

            if (newUsername.Length < 5 || newUsername.Length > 30)
            {
                return new Response<User> { Success = false, Message = "Username must be between 5 and 30 characters" };
            }

            if (!IsValidUsername(newUsername))
            {
                return new Response<User> { Success = false, Message = "Username must be alphabet with space only" };
            }

            if (!newEmail.Contains("@"))
            {
                return new Response<User> { Success = false, Message = "Invalid email format" };
            }

            if(!string.Equals(oldPassword, user.UserPassword))
            {
                return new Response<User> { Success = false, Message = "Old password is not correct" };
            }

            if (newPassword.Length < 8)
            {
                return new Response<User> { Success = false, Message = "Password must be at least 8 characters" };
            }

            if (!IsValidPassword(newPassword))
            {
                return new Response<User> { Success = false, Message = "Password must be alphanumeric" };
            }

            if (passwordConfirm != newPassword)
            {
                return new Response<User> { Success = false, Message = "Confirmation password is not the same as password" };
            }

            return UserHandler.UpdateUser(user.UserID, newUsername, newEmail, newPassword, newGender);
        }

        private static bool IsValidUsername(string username)
        {
            bool isLetterOrWhiteSpace = true;

            foreach(char c in username)
            {
                if(!char.IsLetter(c) && c != ' ')
                {
                    isLetterOrWhiteSpace = false;
                }
            }

            return isLetterOrWhiteSpace;

        }

        private static bool IsValidPassword(string password)
        {
            bool hasDigit = false;
            bool hasAlphabet = false;

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (!char.IsLetter(c))
                {
                    hasAlphabet = true;
                }

                if (hasDigit && hasAlphabet)
                {
                    return true;
                }
            }

            return hasAlphabet && hasDigit;
        }
    }
}