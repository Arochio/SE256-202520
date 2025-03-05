using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

namespace RazorPagesApp.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SongAdmin sAdmin { get; set; }
        private readonly IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IActionResult temp;

            List<SongAdmin> lstSongAdmin = new List<SongAdmin>();

            if (!ModelState.IsValid)
            {
                temp = Page();
            }
            else
            {
                if(sAdmin != null)
                {
                    //good login
                    SongAdminDataAccessLayer factory = new SongAdminDataAccessLayer(_configuration);

                    lstSongAdmin = factory.GetAdminLogin(sAdmin).ToList();

                    if(lstSongAdmin.Count > 0)
                    {

                        HttpContext.Session.SetInt32("SongAdmin_ID", lstSongAdmin[0].SongAdmin_ID);
                        HttpContext.Session.SetString("SongAdmin_Email", lstSongAdmin[0].SongAdmin_Email);

                        temp = Redirect("/Admin/ControlPanel");

                    }
                    else
                    {
                        //bad login
                        sAdmin.Feedback = "Login Failed";
                        temp = Page();
                    }
                }
                else
                {
                    //bad login
                    sAdmin.Feedback = "Login Failed";
                    temp = Page();
                }
            }
            return temp;
        }
    }
}
