using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week_2.App_Code;

namespace Week_2.Backend
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
            double minTemp = 0, secTemp = 0;
            int salesTemp = 0, hostsTemp = 0, episodeTemp = 0;
            Podcast temp = new Podcast();
            temp.Title = txtTitle.Text;
            temp.Artist = txtArtist.Text;
            temp.Album = txtAlbum.Text;
            temp.Release = calReleaseDate.SelectedDate;

            if (Int32.TryParse(txtFirstWeekSales.Text, out salesTemp))
            {
                temp.FirstWeekSales = salesTemp;
            }
            else
            {
                temp.FirstWeekSales = 0;
                temp.Feedback += "Error: incorrect data entry type. (FirstWeekSales) ";
            }

            if (Double.TryParse(txtPlaytimeMin.Text, out minTemp)&& Double.TryParse(txtPlaytimeSec.Text, out secTemp))
            {
                temp.PlayTime = (minTemp * 60) + secTemp;
            }
            else
            {
                temp.PlayTime = 0;
                temp.Feedback += "Error: incorrect data entry type. (PlayTime) ";
            }

            if (Int32.TryParse(txtNumberHosts.Text, out hostsTemp))
            {
                temp.NumberHosts = hostsTemp;
            }
            else
            {
                temp.NumberHosts = 0;
                temp.Feedback += "Error: incorrect data entry type. (Hosts) ";
            }

            if (Int32.TryParse(txtEpisodeNumber.Text, out episodeTemp))
            {
                temp.EpisodeNumber = episodeTemp;
            }
            else
            {
                temp.EpisodeNumber = 0;
                temp.Feedback += "Error: incorrect data entry type. (Episodes) ";
            }

            temp.Feedback += " " + temp.AddARecord();

            lblFeedback.Text = temp.Feedback;

            txtTitle.Text = "";
            txtArtist.Text = "";
            txtAlbum.Text = "";
            calReleaseDate.SelectedDate = DateTime.Now;
            txtEpisodeNumber.Text = "";
            txtFirstWeekSales.Text = "";
            txtNumberHosts.Text = "";
            txtPlaytimeMin.Text = "";
            txtPlaytimeSec.Text = "";

        }
    }
}