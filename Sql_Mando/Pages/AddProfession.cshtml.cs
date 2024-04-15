using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class AddProfessionModel : PageModel
    {
        [BindProperty]
        public Profession profession { get; set; }

        [BindProperty]
        public string id { get; set; }

        private IProfessionService _professionservice;

        public AddProfessionModel(IProfessionService proservice)
        {
            _professionservice = proservice;

        }


        public async Task OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            _professionservice.Addtitle(id, profession);
            return RedirectToPage("NamePage");
        }
    }
}
