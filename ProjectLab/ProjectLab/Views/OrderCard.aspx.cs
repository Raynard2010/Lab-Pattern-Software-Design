using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Models;
using ProjectLab.Handlers;
using ProjectLab.Repositories;
using System.Collections.Generic;

namespace ProjectLab.Views
{
    public partial class OrderCard : System.Web.UI.Page
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            // Jika tidak login, redirect
            if (user == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string keyword = Request.QueryString["search"];
                LoadCards(keyword);
            }
        }

        private void LoadCards(string keyword)
        {
            List<Card> cards = CardRepository.getAllCards();

            if (!string.IsNullOrEmpty(keyword))
            {
                cards = cards
                    .Where(c => c.CardName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            GridViewCards.DataSource = cards;
            GridViewCards.DataBind();
        }

        protected void GridViewCards_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCards.Rows[rowIndex];

                int cardId = Convert.ToInt32(GridViewCards.DataKeys[rowIndex].Value);
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                int quantity = 1;
                if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
                {
                    quantity = 1;
                }

                Card selectedCard = CardHandler.GetCardById(cardId);

                if (selectedCard != null)
                {
                    CartHandler.AddToCart(selectedCard, quantity);
                    
                }
            }
            else if (e.CommandName == "ViewDetail")
            {
                int cardId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Views/CardDetailPage.aspx?CardId=" + cardId);
            }
        }
    }
}
