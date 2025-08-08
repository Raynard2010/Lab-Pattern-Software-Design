using System;
using System.Linq;
using System.Web.UI;
using ProjectLab.Models;

namespace ProjectLab.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ambil user dari session atau cookie
            if (Session["user"] == null && Request.Cookies["user_cookie"] != null)
            {
                int userId = int.Parse(Request.Cookies["user_cookie"].Value);
                user = db.Users.Find(userId);
                Session["user"] = user;
            }
            else
            {
                user = (User)Session["user"];
            }

            UsernameLbl.Text = user?.UserName ?? "Guest";

            if (!IsPostBack)
            {
                string keyword = Request.QueryString["search"];

                if (!string.IsNullOrEmpty(keyword))
                {
                    // Filter berdasarkan nama card
                    var filtered = db.Cards
                        .Where(s => s.CardName.Contains(keyword))
                        .ToList();

                    ShowGridView.DataSource = filtered;
                }
                else
                {
                    // Tampilkan semua card
                    var all = db.Cards.ToList();
                    ShowGridView.DataSource = all;
                }

                ShowGridView.DataBind();
            }
        }
    }
}