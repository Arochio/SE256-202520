using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {

        private readonly IConfiguration _configuration;

        SongSubmissionDataAccessLayer factory;

        public List<SongSubmission> songs { get; set; }

        public ControlPanelModel(IConfiguration configuration)
        {
            _configuration = configuration;

            factory = new SongSubmissionDataAccessLayer(_configuration);
        }

        public IActionResult OnGet()
        {

            IActionResult temp;

            if (HttpContext.Session.GetString("SongAdmin_Email") is null)
            {
                temp = Redirect("/Admin/Index");
            }
            else
            {
                songs = factory.GetActiveRecords().ToList();

                temp = Page();
            }
            return temp;
        }
    }
}
