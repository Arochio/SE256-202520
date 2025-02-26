using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesApp.Models
{
    public class SongSubmission
    {
        public int Submission_ID { get; set; }

        [Required, StringLength(255)]
        public string Submission_Type {  get; set; }

        [Required]
        public string Submission_Song { get; set; }

        [Required]
        public string Submission_Artist { get; set; }

        [StringLength(255)]
        public string? Submission_Notes { get; set; }

        [Required, EmailAddress]
        public string Submission_Email { get; set; }

        public string? Feedback { get; set; }
    }
}
