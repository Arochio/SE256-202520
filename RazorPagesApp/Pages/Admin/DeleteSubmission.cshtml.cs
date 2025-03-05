using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Admin
{
    public class DeleteSubmissionModel : PageModel
    {

        private readonly IConfiguration _configuration;

        SongSubmissionDataAccessLayer factory;

        public SongSubmission submission { get; set; }

        public DeleteSubmissionModel(IConfiguration configuration)
        {
            _configuration = configuration;

            factory = new SongSubmissionDataAccessLayer(_configuration);
        }
        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                submission = factory.GetOneRecord(id);
            }

            if (submission == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            factory.DeleteRecord(id);
            return RedirectToPage("/Admin/ControlPanel");
        }
    }
}
