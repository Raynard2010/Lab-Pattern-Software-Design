using System;
using System.Collections.Generic;
using System.Web.UI;
using ProjectLab.Models;
using ProjectLab.Handlers;
using ProjectLab.Dataset;
using ProjectLab.Report;

namespace ProjectLab.Views
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Session["user"] as User;
            if (user == null || user.UserRole != "Admin")
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                
                List<TransactionHeader> transactions = TransactionHandler.GetAllTransactions();

                
                DataSet1 data = GetData(transactions);

                if (data.Transaction_Header.Rows.Count == 0)
                {
                    Response.Write("No transaction data found!");
                    return;
                }

                
                var report = new CrystalReport1();
                report.SetDataSource(data);

                CrystalReportViewer1.ReportSource = report;
                CrystalReportViewer1.DataBind();
            }
        }

        private DataSet1 GetData(List<TransactionHeader> transactions)
        {
            var data = new DataSet1();
            var headerTable = data.Transaction_Header;
            var detailTable = data.Transaction_Detail;

            foreach (var t in transactions)
            {
                decimal grandTotal = 0m;

                var headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["TransactionDate"] = t.TransactionDate ?? DateTime.MinValue;
                headerRow["CustomerID"] = t.CustomerID ?? 0;
                headerRow["Status"] = t.Status ?? "";

                
                var details = TransactionHandler.GetTransactionDetails(t.TransactionID);
                foreach (var d in details)
                {
                    decimal subTotal = 0m;

                    decimal price = (decimal?)(d.Card?.CardPrice) ?? 0m;
                    int qty = d.Quantity ?? 0;
                    subTotal = price * qty;
                    grandTotal += subTotal;

                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = d.TransactionID;
                    detailRow["CardID"] = d.CardID;
                    detailRow["Quantity"] = qty;
                    detailRow["Sub_Total"] = subTotal;
                    detailTable.Rows.Add(detailRow);
                }

                headerRow["Grand_Total"] = grandTotal;
                headerTable.Rows.Add(headerRow);
            }

            System.Diagnostics.Debug.WriteLine($"Header rows: {data.Transaction_Header.Rows.Count}");
            System.Diagnostics.Debug.WriteLine($"Detail rows: {data.Transaction_Detail.Rows.Count}");


            return data;
        }

    }
}
