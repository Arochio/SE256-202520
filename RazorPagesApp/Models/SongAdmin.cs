using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models
{
    public class SongAdmin
    {

        [Required]
        public int SongAdmin_ID { get; set; }

        [Required, EmailAddress, StringLength(75)]
        public string SongAdmin_Email { get; set; }

        [Required, StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SongAdmin_PW { get; set; }

        public string? Feedback { get; set; }
    }
}
