using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Controllers;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PasswordTb.Text;

            var response = UserController.LoginUser(username, password);

            if (response.Success)
            {
                User user = response.Payload;

                // bikin session baru dengan key 'user' dan value user
                Session["user"] = user;

                // kalau checkbox remember me ke check, masuk kesini
                if (RememberMeCb.Checked)
                {
                    // bikin new cookie namanya user_cookie
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    // bikin value cookienya itu id
                    cookie.Value = user.UserID.ToString();
                    // set expiration jadi 5 hari setelah cookie dibuat
                    cookie.Expires = DateTime.Now.AddDays(5);

                    // Response: HTTP response sent from the server to the client (browser)
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                ErrorLbl.Text = response.Message;
            }

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");

        }

        
    }
}