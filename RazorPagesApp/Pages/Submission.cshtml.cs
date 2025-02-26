using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using Microsoft.Extensions.Configuration;

namespace RazorPagesApp.Pages
{
    public class SubmissionModel : PageModel
    {

        [BindProperty]
        public SongSubmission tempSubmission {  get; set; }

        private readonly IConfiguration _configuration;

        public SubmissionModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
                if (tempSubmission is null == false)
                {
                    SongSubmissionDataAccessLayer factory = new SongSubmissionDataAccessLayer(_configuration);

                    factory.Create(tempSubmission);
                }
                temp = Page();
            }

            return temp;

        }

    }
}
