using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week_2.App_Code;

namespace Week_2.Backend
{
    public partial class EditSongs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strPodcastID = "";
            int intPodcastID = 0;

            if((!IsPostBack) && Request.QueryString[ID] != null)
            {
                strPodcastID = Request.QueryString[ID].ToString();
                lblID.Text = strPodcastID;

                intPodcastID = Int32.Parse(strPodcastID);

                Podcast temp = new Podcast();
                SqlDataReader dr = temp.FindOnePodcast(intPodcastID);

                while (dr.Read())
                {
                    int intMins, intSecs, intMinsRound, intSecsRound;
                    txtTitle.Text = dr["Title"].ToString();
                    txtArtist.Text = dr["Title"].ToString();
                    txtAlbum.Text = dr["Title"].ToString();
                    intMins = Int32.Parse(dr["Title"].ToString());
                    txtTitle.Text = dr["Title"].ToString();
                    txtTitle.Text = dr["Title"].ToString();
                    txtTitle.Text = dr["Title"].ToString();
                    txtTitle.Text = dr["Title"].ToString();
                }
        }
    }
}