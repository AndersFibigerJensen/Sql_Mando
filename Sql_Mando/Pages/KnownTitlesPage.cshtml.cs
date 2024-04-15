using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class KnownTitlesPageModel : PageModel
    {

        [BindProperty]
        public List<KnownTitles> Titles { get; set; }

        private IKnownTitlesService _titleservice;

        public KnownTitlesPageModel(IKnownTitlesService titleservice)
        {
            _titleservice = titleservice;
        }

        public async Task OnGet(string proid)
        {
            Titles = _titleservice.GetKnownTitles(proid).Result;
        }
    }
}
