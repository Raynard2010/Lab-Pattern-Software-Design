using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Controllers;
using ProjectLab.Models;

namespace ProjectLab.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] != null)
            {
                int userId = int.Parse(Request.Cookies["user_cookie"].Value); // Cookie stores UserID
                user = db.Users.Find(userId);  // Look up user by ID
                Session["user"] = user;  // Store user in session
            }
            else
            {
                // kalau session ada, ambil user dari session
                user = (User)Session["user"];

                OldUsernameLbl.Text = "Old username: " + user.UserName;
                OldEmailLbl.Text = "Old email: " + user.UserEmail;
                OldPasswordLbl.Text = "Old password: " + user.UserPassword;
                OldGenderLbl.Text = "Old gender: " + user.UserGender;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string newUsername = TbNewUsername.Text;
            string newEmail = TbNewEmail.Text;
            string oldPassword = TbOldPassword.Text;
            string newPassword = TbNewPassword.Text;
            string passwordConfirm = TbConfirmationPassword.Text;
            string newGender = RblNewGender.SelectedValue;

            var response = UserController.UpdateUser(user, newUsername, newEmail, oldPassword, newPassword, passwordConfirm, newGender);

            if (response.Success)
            {
                Response.Redirect("ProfilePage.aspx");
            }
            else
            {
                LblError.Text = response.Message;
            }
        }
    }
}