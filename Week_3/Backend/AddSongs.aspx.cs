using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week_3;

namespace Week_3.Backend
{
    public partial class AddSongs : System.Web.UI.Page
    {
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

        protected void btnRecordSubmit_Click(object sender, EventArgs e)
        {
            Podcast temp = new Podcast();
        }
    }
}