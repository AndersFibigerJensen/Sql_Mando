using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class ProfessionPageModel : PageModel
    {
        [BindProperty]
        public List<Profession> Professions { get; set; }

        private IProfessionService _professionservice;

        public ProfessionPageModel(IProfessionService proservice)
        {
            _professionservice = proservice;
        }

        public async Task OnGet(string proid)
        {
            Professions = await _professionservice.GetKnownTitles(proid);
        }
    }
}
