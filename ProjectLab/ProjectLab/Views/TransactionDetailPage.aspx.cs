using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Handlers;
using ProjectLab.Models;
using ProjectLab.Repositories;

namespace ProjectLab.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                var transaction = TransactionHandler.GetTransactionById(id);

                if (transaction != null)
                {
                    TransactionIdLbl.Text = $"Transaction ID: {transaction.TransactionID}";
                    CustomerLbl.Text = $"Customer: {transaction.User.UserName}";
                    DateLbl.Text = $"Date: {(transaction.TransactionDate.HasValue ? transaction.TransactionDate.Value.ToString("yyyy-MM-dd") : " - ")}";
                    StatusLbl.Text = $"Status: {transaction.Status}";

                    
                    var transactionDetails = TransactionDetailRepository.GetTransactionDetailsByTransactionId(transaction.TransactionID);

                   
                    var detailList = transactionDetails.Select(td => new
                    {
                        CardName = td.Card.CardName,
                        Price = td.Card.CardPrice,
                        Quantity = td.Quantity,
                        Subtotal = td.Quantity * td.Card.CardPrice
                    }).ToList();
                    TransactionDetailGv.DataSource = detailList;
                    TransactionDetailGv.DataBind();
                }
                else
                {
                    Response.Write("Transaction not found.");
                }
            }
        }
    }
}