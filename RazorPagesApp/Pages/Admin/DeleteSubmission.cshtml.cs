using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Admin
{
    public class DeleteSubmissionModel : PageModel
    {

        private readonly IConfiguration _configuration;

        SongSubmissionDataAccessLayer factory;

        [BindProperty]
        public SongSubmission delSubmission { get; set; }


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
                delSubmission = factory.GetOneRecord(id);
            }

            if (delSubmission == null)
            {
                return NotFound();
            }

            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            factory.DeleteRecord(id);
            return Redirect("/Admin/ControlPanel");
        }
    }
}
