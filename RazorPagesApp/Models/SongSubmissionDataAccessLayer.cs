using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RazorPagesApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;

namespace RazorPagesApp.Models
{
    public class SongSubmissionDataAccessLayer
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public SongSubmissionDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(SongSubmission submission)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT Into SongSubmissions (Submission_Type, Submission_Song, Submission_Artist, Submission_Notes, Submission_Email, Submission_Time) VALUES (@Submission_Type, @Submission_Song, @Submission_Artist, @Submission_Notes, @Submission_Email, @Submission_Time);";

                submission.Feedback = "";

                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        command.CommandType = CommandType.Text;

                        command.Parameters.AddWithValue("@Submission_Type", submission.Submission_Type);
                        command.Parameters.AddWithValue("@Submission_Song", submission.Submission_Song);
                        command.Parameters.AddWithValue("@Submission_Artist", submission.Submission_Artist);
                        command.Parameters.AddWithValue("@Submission_Notes", submission.Submission_Notes);
                        command.Parameters.AddWithValue("@Submission_Email", submission.Submission_Email);
                        command.Parameters.AddWithValue("@Submission_Time", DateTime.Now);

                        connection.Open();
                        submission.Feedback = command.ExecuteNonQuery().ToString() + " Record Added";
                        connection.Close();
                    }
                }
                catch (Exception err)
                {
                    submission.Feedback = "ERROR: " + err.Message;
                }
            }
        }

        public IEnumerable<SongSubmission> GetActiveRecords()
        {
            List<SongSubmission> lstSub = new List<SongSubmission>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string strSql = "Select * FROM SongSubmissions ORDER BY Submission_Time;";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.Text;

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        SongSubmission submission = new SongSubmission();

                        submission.Submission_ID = Convert.ToInt32(rdr["Submission_ID"]);
                        submission.Submission_Type = rdr["Submission_Type"].ToString();
                        submission.Submission_Song = rdr["Submission_Song"].ToString();
                        submission.Submission_Artist = rdr["Submission_Artist"].ToString();
                        submission.Submission_Notes = rdr["Submission_Notes"].ToString();
                        submission.Submission_Email = rdr["Submission_Email"].ToString();

                        lstSub.Add(submission);
                    }
                    conn.Close();
                }
            }
            catch(Exception err)
            {

            }
            return lstSub;
        }

        public SongSubmission GetOneRecord(int? id)
        {

            SongSubmission submission = new SongSubmission();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    string strSql = "SELECT * FROM SongSubmissions WHERE Submission_ID = @Submission_ID;";

                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Submission_ID", id);

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        submission.Submission_ID = Convert.ToInt32(rdr["Submission_ID"]);
                        submission.Submission_Type = rdr["Submission_Type"].ToString();
                        submission.Submission_Song = rdr["Submission_Song"].ToString();
                        submission.Submission_Artist = rdr["Submission_Artist"].ToString();
                        submission.Submission_Notes = rdr["Submission_Notes"].ToString();
                        submission.Submission_Email = rdr["Submission_Email"].ToString();
                    }
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                submission.Feedback = "ERROR: " + ex.Message;
            }
            return submission;
        }

        public void UpdateRecord(SongSubmission submission)
        {
            try { 
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();

                    //string strSQL = "UPDATE SongSubmissions SET Submission_Type = @Submission_Type, Submission_Song = @Submission_Song, Submission_Artist = @Submission_Artist, Submission_Notes = @Submission_Notes, Submission_Email = @Submission_Email WHERE Submission_ID = @Submission_ID;";
                    string strSQL = "UPDATE SongSubmissions SET Submission_Notes = 'HOORAY!' WHERE Submission_ID = 1";

                    cmd.CommandText = strSQL;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Submission_ID", submission.Submission_ID);
                    cmd.Parameters.AddWithValue("@Submission_Type", submission.Submission_Type);
                    cmd.Parameters.AddWithValue("@Submission_Song", submission.Submission_Song);
                    cmd.Parameters.AddWithValue("@Submission_Artist", submission.Submission_Artist);
                    cmd.Parameters.AddWithValue("@Submission_Notes", submission.Submission_Notes);
                    cmd.Parameters.AddWithValue("@Submission_Email", submission.Submission_Email);
                    cmd.Parameters.AddWithValue("@Submission_Time", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                submission.Feedback = "ERROR: " + ex.Message;
            }
        }

        public SongSubmission DeleteRecord(int? id)
        {
            SongSubmission submission = new SongSubmission();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    string strSql = "DELETE FROM SongSubmissions WHERE Submission_ID = @Submission_ID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Submission_ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                submission.Feedback = "ERROR: " + ex.Message;
            }
            return submission;
        }
    }
}
