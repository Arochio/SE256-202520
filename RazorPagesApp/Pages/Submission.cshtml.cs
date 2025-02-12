using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages
{
    public class SubmissionModel : PageModel
    {

        [BindProperty]
        public SongSubmission tempSubmision {  get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            IActionResult temp;

            if(ModelState.IsValid == false)
            {
                temp = Page();
            }
            else
            {
                temp = Page();
            }

            return temp;

        }

    }
}
