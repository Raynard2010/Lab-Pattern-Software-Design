using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLab.Controllers;

namespace ProjectLab.Views
{
    public partial class EditCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string name = TbName.Text;
            string price = TbPrice.Text;
            string description = TbDescription.Text;
            string type = RblType.SelectedValue;
            string foil = RblFoil.SelectedValue;
            string oldName = Request.QueryString["oldName"];

            var response = CardController.EditCard(oldName, name, price, description, type, foil);

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