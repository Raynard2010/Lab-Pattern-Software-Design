using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Models;

namespace ProjectLab.Views
{
    public partial class navbar : System.Web.UI.MasterPage
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            // kalau session kosong, tapi cookie masih ada
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
            }

            //kalau user gaada, ke login page
            //if (user == null) Response.Redirect("LoginPage.aspx");

            if (user != null)
            {
                HomeLink.Visible = (user.UserRole == "Admin" || user.UserRole == "Customer");
                LogoutBtn.Visible = (user.UserRole == "Admin" || user.UserRole == "Customer");

                OrderCardLink.Visible = (user.UserRole == "Customer");
                ProfileLink.Visible = (user.UserRole == "Customer");
                TransactionHistoryLink.Visible = (user.UserRole == "Customer" || user.UserRole == "Admin");
                CartLink.Visible = (user.UserRole == "Customer");

                ManageCardLink.Visible = (user.UserRole == "Admin");
                TransactionReportLink.Visible = (user.UserRole == "Admin");
                HandleTransactionLink.Visible = (user.UserRole == "Admin");

                UsernameLbl.Text = user.UserName;
            }


        }
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["user_cookie"] != null)
            {
                // bikin cookie baru untuk overwrite
                HttpCookie cookie = new HttpCookie("user_cookie");
                // bikin expiration date nya kemarin
                cookie.Expires = DateTime.Now.AddDays(-1);
                // tambahin cookie expired
                Response.Cookies.Add(cookie);
            }

            // Menghapus seluruh session dan membuat session baru
            Session.Abandon();
            // redirect ke login
            Response.Redirect("LoginPage.aspx");
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) return;

            var user = Session["user"] as User;

            if (user != null)
            {
                string encodedKeyword = HttpUtility.UrlEncode(keyword);

                if (user.UserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("~/Views/ManageCardPage.aspx?search=" + encodedKeyword);
                }
                else if (user.UserRole.Equals("Customer", StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("~/Views/OrderCard.aspx?search=" + encodedKeyword);
                }
            }
        }

    }
}