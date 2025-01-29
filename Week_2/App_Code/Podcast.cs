using System;
using System.Collections.Generic;
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

        private string GetConnected()
        {
            //left empty for github
            return @"Server=;Database=;" +
                    "User Id=;Password=";
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
        public Podcast() : base()
        {
            numberHosts = 1;
            episodeNumber = 1;
        }
    }
}