using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
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

            string strPodcastID = "";
            int intPodcastID = 0;

            if (Request.QueryString["ID"] != null)
            {
                strPodcastID = Request.QueryString["ID"].ToString();
                lblIDHolder.Text = strPodcastID;

                intPodcastID = Int32.Parse(strPodcastID);

                Podcast temp = new Podcast();
                SqlDataReader dr = temp.FindOnePodcast(intPodcastID);

                while (dr.Read())
                {
                    int intMins, intSecs;
                    DateTime dtRelease;
                    txtTitle.Text = dr["Title"].ToString();
                    txtArtist.Text = dr["Artist"].ToString();
                    txtAlbum.Text = dr["Album"].ToString();
                    intSecs = Convert.ToInt32(dr["PlayTime"].ToString()) % 60;
                    txtPlaytimeSec.Text = intSecs.ToString(); 
                    intMins = (Convert.ToInt32(dr["PlayTime"].ToString()) - intSecs) / 60;
                    txtPlaytimeMin.Text = intMins.ToString();
                    txtFirstWeekSales.Text = dr["FirstWeekSales"].ToString();
                    txtNumberHosts.Text = dr["NumberHosts"].ToString();
                    txtEpisodeNumber.Text = dr["EpisodeNumber"].ToString();
                    if (DateTime.TryParse(dr["Release"].ToString(), out dtRelease))
                    {
                        calReleaseDate.SelectedDate = dtRelease;
                        calReleaseDate.VisibleDate = dtRelease;
                    }
                    else
                    {
                        calReleaseDate.SelectedDate = DateTime.Now;
                        lblFeedback.Text += "ERROR: Release date unable to parse. ";
                    }
                }
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
            temp.Feedback = "";

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

            if (lblIDHolder.Text == "")
            {
                temp.Feedback += " " + temp.AddARecord();
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
            else
            {
                temp.PodcastID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                temp.Feedback += " " + temp.UpdateARecord(Convert.ToInt32(Request.QueryString["ID"].ToString()));
                lblFeedback.Text = temp.Feedback;
            }

            lblFeedback.Text = temp.Feedback;
        }

        protected void btnControlPanel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Backend/ControlPanel.aspx");
        }
    }
}