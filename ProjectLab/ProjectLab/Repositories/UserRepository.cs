using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Repositories
{
    public class UserRepository
    {
        private static DatabaseEntities1 db = new DatabaseEntities1();

        public static void createUser(User user)
        {
            db.Users.Add(user); 
            db.SaveChanges();
        }

        public static User getUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public static User getUserByUserID(int userid)
        {
            return db.Users.FirstOrDefault(u => u.UserID == userid);
        }


        public static void UpdateUser(int id, string newUsername, string newEmail, string newPassword, string newGender)
        {
            User updatedUser = db.Users.Find(id);
            updatedUser.UserName = newUsername;
            updatedUser.UserEmail = newEmail;
            updatedUser.UserPassword = newPassword; 
            updatedUser.UserGender = newGender;

            db.SaveChanges();
        }
    }
}