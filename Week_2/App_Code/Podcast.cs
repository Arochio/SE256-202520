using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Week_2;

namespace Week_2.App_Code
{
    public class Podcast : Song
    {
        private int numberHosts;
        private int episodeNumber;
        private int podcastID;

        public int NumberHosts
        {
            get { return numberHosts; }
            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 1))
                {
                    numberHosts = value;
                }
                else
                {
                    feedback += "ERROR: Must have at least one host. ";
                }
            }
        }

        public int EpisodeNumber
        {
            get { return episodeNumber; }
            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 1))
                {
                    episodeNumber = value;
                }
                else
                {
                    feedback += "ERROR: Episode number must be at least 1. ";
                }
            }
        }

        public int PodcastID
        {
            get { return podcastID; }
            set { podcastID = value; }
        }

        private string GetConnected()
        {
            //left empty for github
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=dev_202510_cgraves;" +
                    "User Id=dev_202510_cgraves;Password=008006845";
        }

        public string AddARecord()
        {
            string strResult = "";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            string strSQL = "INSERT INTO PodCasts (Title, Artist, Album, Release, PlayTime, FirstWeekSales, NumberHosts, EpisodeNumber, Feedback)" +
                "VALUES (@Title, @Artist, @Album, @Release, @PlayTime, @FirstWeekSales, @NumberHosts, @EpisodeNumber, @Feedback)";

            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;
            comm.Connection = Conn;

            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@Artist", Artist);
            comm.Parameters.AddWithValue("@Album", Album);
            comm.Parameters.AddWithValue("@Release", Release);
            comm.Parameters.AddWithValue("@PlayTime", PlayTime);
            comm.Parameters.AddWithValue("@FirstWeekSales", FirstWeekSales);
            comm.Parameters.AddWithValue("@NumberHosts", NumberHosts);
            comm.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            comm.Parameters.AddWithValue("@Feedback", Feedback);

            try
            {
                Conn.Open();

                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";

                Conn.Close();
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }

            return strResult;
        }

        public DataSet SearchARecord(string titleText, string artistText)
        {
            DataSet ds = new DataSet();
            
            string strSQL = "SELECT ID, Title, Artist, Album, Release, PlayTime, FirstWeekSales, NumberHosts, EpisodeNumber, Feedback FROM Podcast WHERE 0=0";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            SqlCommand comm = new SqlCommand();
            

            if (titleText.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + titleText + "%");
            }
            if (artistText.Length > 0)
            {
                strSQL += " AND Artist LIKE @Artist";
                comm.Parameters.AddWithValue("@Artist", "%" + artistText + "%");
            }

            comm.Connection = Conn;
            comm.CommandText = strSQL;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            try
            {
                Conn.Open();

                da.Fill(ds, "Podcast_temp");

                Conn.Close();
            }
            catch (Exception err)
            {
                feedback += "ERROR: " + err.Message;
            }
            return ds;
        }

        public SqlDataReader SearchARecord_DR(string strTitle, string strArtist)
        {
            SqlDataReader dr = null;

            string strSQL = "SELECT ID, Title, Artist, Album, Release, PlayTime, FirstWeekSales, NumberHosts, EpisodeNumber, Feedback  FROM Podcast WHERE 0=0;";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            SqlCommand comm = new SqlCommand();
            comm.Connection= Conn;
            comm.CommandText= strSQL;

            if (strTitle.Length > 0)
            {
                strSQL += "AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", strTitle);
            }
            if (strArtist.Length > 0)
            {
                strSQL += "AND Artist LIKE @Artist";
                comm.Parameters.AddWithValue("@Artist", strArtist);
            }

            try
            {
                Conn.Open();

                dr = comm.ExecuteReader();

            }
            catch (Exception err)
            {
                Feedback += "ERROR: " + err.Message;
            }
            return dr;
        }
        
        public SqlDataReader FindOnePodcast(int intPodCastID)
        {
            Int32 intRecords = 0;

            string strSQL = "SELECT * FROM Podcast WHERE ID = @ID";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            SqlCommand comm = new SqlCommand();
            comm.Connection = Conn;
            comm.CommandText = strSQL;
            comm.Parameters.AddWithValue("@ID", intPodCastID);

            Conn.Open();
            return comm.ExecuteReader();
        }

        public string DeleteOnePodcast(int intPodcastID)
        {
            string strResult = "";

            string strSQL = "DELETE FROM Podcast WHERE ID = @intPodcastID";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            SqlCommand Comm = new SqlCommand();
            Comm.Connection = Conn;
            Comm.CommandText = strSQL;
            Comm.Parameters.AddWithValue("@Podcast_ID", intPodcastID);

            try
            {
                Conn.Open();

                int intRecs = Comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Deleted {intRecs} records.";

                Conn.Close();
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }
            return strResult;
        }

        public string UpdateARecord(int IntPodcastID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            string strSQL = "UPDATE Podcast SET Title = @Title, Artist = @Artist, Album = @Album, Release = @Release, PlayTime = @PlayTime, FirstWeekSales = @FirstWeekSales, NumberHosts = @NumberHosts, EpisodeNumber = @EpisodeNumber, Feedback = @Feedback WHERE ID = @IntPodcastID;";

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = GetConnected();

            SqlCommand comm = new SqlCommand();
            comm.Connection = Conn;
            comm.CommandText = strSQL;

            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@Artist", Artist);
            comm.Parameters.AddWithValue("@Album", Album);
            comm.Parameters.AddWithValue("@Release", Release);
            comm.Parameters.AddWithValue("@PlayTime", PlayTime);
            comm.Parameters.AddWithValue("@FirstWeekSales", FirstWeekSales);
            comm.Parameters.AddWithValue("@NumberHosts", NumberHosts);
            comm.Parameters.AddWithValue("@EpisodeNumber", EpisodeNumber);
            comm.Parameters.AddWithValue("@Feedback", Feedback);
            comm.Parameters.AddWithValue("@IntPodcastID", IntPodcastID);

            try
            {
                Conn.Open();

                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + "Updated";

                Conn.Close();
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;
            }
            return strResult;
        }

        public Podcast() : base()
        {
            numberHosts = 1;
            episodeNumber = 1;
        }
    }
}