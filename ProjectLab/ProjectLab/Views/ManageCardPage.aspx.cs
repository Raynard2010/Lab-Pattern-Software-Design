using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Repositories;
using ProjectLab.Models;
using ProjectLab.Handlers;

namespace ProjectLab.Views
{
    public partial class ManageCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyword = Request.QueryString["search"];
                refreshGrid(keyword);
            }
        }

        public void refreshGrid(string keyword)
        {
            List<Card> cardList = CardHandler.getAllCards();

            if (!string.IsNullOrEmpty(keyword))
            {
                cardList = cardList
                    .Where(c => c.CardName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            if (cardList != null && cardList.Count > 0)
            {
                CardGv.DataSource = cardList;
                CardGv.DataBind();
                CardGv.Visible = true;
            }
            else
            {
                CardGv.Visible = false;
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCardPage.aspx");
        }

        protected void CardGv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // ambil row yang kita mau edit
            GridViewRow row = CardGv.Rows[e.NewEditIndex];

            // ambil name
            string name = row.Cells[0].Text;

            Response.Redirect("EditCardPage.aspx?oldName=" + name);
        }

        protected void CardGv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // ambil row yang kita mau delete
            GridViewRow row = CardGv.Rows[e.RowIndex];

            // ambil name
            string name = row.Cells[0].Text;

            // REPO panggil deleteCard
            CardHandler.deleteCard(name);

            CardGv.EditIndex = -1;
            string keyword = Request.QueryString["search"];
            refreshGrid(keyword);
        }
    }
}