using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ProjectLab.Models;
using ProjectLab.Handlers;

namespace ProjectLab.Views
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionGrid();
            }
        }

        private void BindTransactionGrid()
        {
            var user = Session["User"] as User;
            if (user == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            List<TransactionHeader> transactionList;

            if (user.UserRole == "Admin")
            {
                transactionList = TransactionHandler.GetAllTransactions();
            }
            else
            {
                transactionList = TransactionHandler.GetTransactionsByUserId(user.UserID);
            }

            var result = transactionList.Select(t => new
            {
                TransactionID = t.TransactionID,
                Date = t.TransactionDate.HasValue ? t.TransactionDate.Value.ToString("yyyy-MM-dd") : "-",
                CustomerName = t.User.UserName
            }).ToList();

            TransactionGv.DataSource = result;
            TransactionGv.DataBind();
        }

        protected void TransactionGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                string transactionID = e.CommandArgument.ToString();
                Response.Redirect($"TransactionDetailPage.aspx?id={transactionID}");
            }
        }
    }
}
