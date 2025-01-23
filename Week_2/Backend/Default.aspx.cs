using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week_2.Backend
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //match username and password to (temp) manually set phrases, edit session variables and respond accordingly
            if (txtUsername.Text == "User" && txtPassword.Text == "Pass")
            {
                //Good
                Session["Username"] = txtUsername.Text;
                Session["LoggedIn"] = true;
                lblFeedback.Text = "You are logged in.";
                Response.Redirect("~/Backend/ControlPanel.aspx");
            }
            else
            {
                //Bad
                Session["LoggedIn"] = false;
                lblFeedback.Text = "ERROR: Bad Login";
            }
        }
    }
}