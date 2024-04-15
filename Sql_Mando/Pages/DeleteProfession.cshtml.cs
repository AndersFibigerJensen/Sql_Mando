using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class DeleteProfessionModel : PageModel
    {
        [BindProperty]
        public Profession Profession { get; set; }

        private IProfessionService _professionservice;

        public DeleteProfessionModel(IProfessionService proservice)
        {
            _professionservice = proservice;

        }


        public async Task OnGet(int proid)
        {
            Profession=_professionservice.GetProfession(proid).Result;
        }

        public async Task<IActionResult> OnPost()
        {
            //_professionservice.DeleteAllKnownTitles(id);
            return RedirectToPage("NamePage");
        }
    }
}
