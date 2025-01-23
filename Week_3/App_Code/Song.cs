using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Week_3.App_Code;
namespace Week_3.App_Code
{
    public class Song
    {
        private string title;
        private string artist;
        private string album;
        private DateTime release;
        private Double playTime;
        private Int32 firstWeekSales;

        protected string feedback;

        public string Title 
        {
            get { return title; }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    title = value;
                }
                else
                {
                    feedback += "ERROR: Song title contains bad word(s). ";
                }
            }
        }
        public string Artist
        {
            get { return artist; }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    artist = value;
                }
                else
                {
                    feedback += "ERROR: Artist name contains bad word(s). ";
                }
            }
        }
        public string Album
        {
            get { return album; }
            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    album = value;
                }
                else
                {
                    feedback += "ERROR: Album title contains bad word(s). ";
                }
            }
        }

        public DateTime Release
        {
            get { return release; }
            set
            {
                if (!ValidationLibrary.IsAFutureDate(value))
                {
                    release = value;
                }
                else
                {
                    feedback += "ERROR: Release date must be a past date. ";
                }
            }
        }

        public Double PlayTime
        {
            get { return playTime; }
            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 0.49))
                {
                    playTime = value;
                }
                else
                {
                    feedback += "ERROR: Play time must be at least 30 seconds";
                }
            }
        }

        public Int32 FirstWeekSales
        {
            get { return firstWeekSales; }
            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, -1))
                {
                    firstWeekSales = value;
                }
                else
                {
                    feedback += "ERROR: First week sales must at least 0";
                }
            }
        }
        public string Feedback
        {
            get { return feedback; }
            set { feedback = value; }
        }

        public Song()
        {
            title = string.Empty;
            artist = string.Empty;
            album = string.Empty;
            release = DateTime.Now;
            playTime = 0;
            firstWeekSales = 0;
        }
    }
}