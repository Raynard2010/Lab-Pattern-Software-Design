using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProjectLab.Models;
using ProjectLab.Handlers;
using ProjectLab.Repositories;

namespace ProjectLab.Views
{
    public partial class CheckOutPage : System.Web.UI.Page
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

            if (cart == null || cart.Count == 0)
            {
                GridViewCheckout.DataSource = null;
                GridViewCheckout.DataBind();
                lblTotalPrice.Text = "Your cart is empty.";
                btnConfirmCheckout.Enabled = false;
            }
            else
            {
                GridViewCheckout.DataSource = cart;
                GridViewCheckout.DataBind();

                decimal total = cart.Sum(item => (decimal)(item.Card.CardPrice ?? 0) * item.Quantity);
                lblTotalPrice.Text = $"Total Price: {total:C}";
                btnConfirmCheckout.Enabled = true;
            }
        }

        protected void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["user"];
            List<CartItem> cart = CartHandler.GetCart();

            if (cart == null || cart.Count == 0)
            {
                lblTotalPrice.Text = "Your cart is empty.";
                return;
            }

            TransactionHeader transaction = new TransactionHeader
            {
                CustomerID = currentUser.UserID,
                TransactionDate = DateTime.Now,
                Status = "Unhandled"
            };

            int transactionID = TransactionRepository.CreateTransaction(transaction);

            if (transactionID > 0)
            {
                foreach (var item in cart)
                {
                    TransactionDetail detail = new TransactionDetail
                    {
                        TransactionID = transactionID,
                        CardID = item.Card.CardId,
                        Quantity = item.Quantity,
                    };

                    TransactionDetailRepository.AddTransactionDetail(detail);
                }

                CartHandler.ClearCart();
                Response.Redirect($"~/Views/TransactionDetailPage.aspx?id={transactionID}");
            }
            else
            {
                lblTotalPrice.Text = "Error processing transaction.";
            }
        }
    }
}
