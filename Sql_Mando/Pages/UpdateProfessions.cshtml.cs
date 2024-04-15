using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class UpdateProfessionsModel : PageModel
    {

        [BindProperty]
        public Profession Profession { get; set; }

        private IProfessionService _professionservice;

        public UpdateProfessionsModel(IProfessionService proservice)
        {
            _professionservice = proservice;
        }

        public async Task OnGet(int proid)
        {
            Profession= await _professionservice.GetProfession(proid);
        }

        public async Task<IActionResult> OnPost(Profession profession)
        {
            await _professionservice.UpdateTitles(profession);
            return RedirectToPage("MoviePage");
        }
    }
}
