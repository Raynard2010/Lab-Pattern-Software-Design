using ProjectLab.Handlers;
using ProjectLab.Models;
using ProjectLab.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLab.Views
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            List<CartItem> cart = CartHandler.GetCart();
            decimal totalPrice = 0;
            foreach (var item in cart)
            {
                totalPrice += (decimal)(item.Card.CardPrice ?? 0) * item.Quantity;
            }
            CartGridView.DataSource = cart;
            CartGridView.DataBind();

            LblTotalPrice.Text = string.Format("Total Price: {0:C}", totalPrice);

            CheckoutBtn.Enabled = cart.Count > 0;
        }

        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                int cardId = Convert.ToInt32(e.CommandArgument);
                CartHandler.RemoveFromCart(cardId);
                LoadCart();
            }
            else if (e.CommandName == "UpdateQuantity")
            {
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                int cardId = Convert.ToInt32(CartGridView.DataKeys[row.RowIndex].Value);
                TextBox txtQuantity = (TextBox)row.FindControl("TxtQuantity");

                if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                {
                    CartHandler.UpdateCartQuantity(cardId, quantity);
                    LoadCart();
                }
                else
                {
                    LblMessage.Text = "Invalid quantity.";
                    LblMessage.Visible = true;
                }
            }
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CheckOutPage.aspx");
        }


        protected void BtnClearCart_Click(object sender, EventArgs e)
        {
            CartHandler.ClearCart();
            LoadCart();
        }
    }
}
