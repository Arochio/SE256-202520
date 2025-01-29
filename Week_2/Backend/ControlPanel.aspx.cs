using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week_2.Backend
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        //confirm correct login via session var, deny login if session var is null
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true)
            {

            }
            else
            {
                Response.Redirect("~/Backend");
            }
        }

        //delete saved session variables and redirect to login page
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Backend");
        }

        protected void btnAddSong_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Backend/AddSongs.aspx");
        }

        protected void btnAddAlbum_Click(object sender, EventArgs e)
        {

        }
    }
}