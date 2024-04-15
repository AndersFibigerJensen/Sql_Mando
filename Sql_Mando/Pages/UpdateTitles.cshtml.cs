using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class UpdateTitlesModel : PageModel
    {

        [BindProperty]
        public KnownTitles Title { get; set; }

        private IKnownTitlesService _titleservice;

        public UpdateTitlesModel(IKnownTitlesService titleservice)
        {
            _titleservice = titleservice;
        }

        public async Task OnGet(int proid)
        {
            Title = await _titleservice.GetKnownTitlesbyid(proid);
        }

        public async Task<IActionResult> OnPost()
        {
            await _titleservice.UpdateTitles(Title);
            return RedirectToPage("MoviePage");
        }
    }
}
