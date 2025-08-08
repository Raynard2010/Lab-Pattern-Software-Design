using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Controllers;

namespace ProjectLab.Views
{
    public partial class AddCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = TbName.Text;
            string price = TbPrice.Text;
            string description = TbDescription.Text;
            string type = RblType.SelectedValue;
            string foil = RblFoil.SelectedValue;

            var response = CardController.AddCard(name, price, description, type, foil);

            if (response.Success)
            {
                Response.Redirect("ManageCardPage.aspx");
            }
            else
            {
                LblError.Text = response.Message;
            }
        }
    }
}