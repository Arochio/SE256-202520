using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Week_2.App_Code;

namespace Week_2.Backend
{
    public partial class SearchSongs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelSong_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateSong_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchSong_Click(object sender, EventArgs e)
        {
            string searchTitle = txtbxTitle.Text;
            string searchArtist = txtbxArtist.Text;

            Podcast searchPodcast = new Podcast();
            
            DataSet ds = searchPodcast.SearchARecord(searchTitle, searchArtist);
            
            dgResults.DataSource = ds;
            dgResults.DataMember = ds.Tables[0].TableName;
            dgResults.DataBind();

            SqlDataReader dr = null;
            dr = searchPodcast.SearchARecord_DR(searchTitle, searchArtist);

            rptSearch.DataSource = dr;
            rptSearch.DataBind();
        }
    }
}