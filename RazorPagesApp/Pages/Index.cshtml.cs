using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using Microsoft.Extensions.Configuration;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public String FName { get; set; }

        private readonly IConfiguration _configuration;

        SongSubmissionDataAccessLayer factory;
        public List<SongSubmission> submissions { get; set; }
        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;

            factory = new SongSubmissionDataAccessLayer(_configuration);
        }
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "User!";
            }

            submissions = factory.GetActiveRecords().ToList();
        }
    }
}
