using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Views
{
    public partial class HandleTransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Pastikan hanya admin yang bisa akses halaman ini
            var user = Session["user"] as User;
            if (user == null || user.UserRole != "Admin")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadTransactions();
            }
        }
        private void LoadTransactions()
        {
            var transactions = TransactionRepository.GetAllTransactions()
                .Where(t => t.Status == "Unhandled")
                .ToList();

            TransactionGridView.DataSource = transactions;
            TransactionGridView.DataBind();
        }

        protected void TransactionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "HandleTransaction")
            {
                int transactionId = Convert.ToInt32(e.CommandArgument);

                bool result = TransactionRepository.UpdateTransactionStatus(transactionId, "Handled");

                if (result)
                {
                    LblMessage.Text = "Transaction has been handled successfully.";
                    LblMessage.Visible = true;
                }
                else
                {
                    LblMessage.Text = "Failed to handle transaction.";
                    LblMessage.ForeColor = System.Drawing.Color.Red;
                    LblMessage.Visible = true;
                }

                LoadTransactions(); // refresh grid
            }
        
     }
    }
}