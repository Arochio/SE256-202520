using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Admin
{
    public class EditTicketModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public SongSubmission submission { get; set; }
        public SongSubmissionDataAccessLayer factory;

        public EditTicketModel(IConfiguration configuration)
        {
            _configuration = configuration;
            factory = new SongSubmissionDataAccessLayer(_configuration);
        }
        public ActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                submission = factory.GetOneRecord(id);
            }

            if(submission == null)
            {
                return NotFound();
            }

            return Page();
        }
        
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else 
            {
                factory.UpdateRecord(submission);
                return RedirectToPage("/Admin/ControlPanel");
            }
                
        }
    }
}
