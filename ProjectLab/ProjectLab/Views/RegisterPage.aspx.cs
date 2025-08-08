using System;
using ProjectLab.Controllers;

namespace ProjectLab.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if session masih ada atau cookie masih ada, maka langsung redirect ke home page
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = TbUsername.Text;
            string email = TbEmail.Text;
            string password = TbPassword.Text;
            string gender = RblGender.SelectedValue;
            string passwordConfirm = TbPasswordConfirm.Text;
            string role = RblRole.SelectedValue;

            var response = UserController.RegisterUser(username, email, password, gender, passwordConfirm, role);

            if (response.Success)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                LblError.Text = response.Message;
            }
        }
    }
}