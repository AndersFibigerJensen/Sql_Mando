using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class DeleteKnownTitlesModel : PageModel
    {

        [BindProperty]
        public string id { get; set; }

        [BindProperty]
        public KnownTitles title { get; set; }

        private IKnownTitlesService _titleservice;

        public DeleteKnownTitlesModel(IKnownTitlesService titleservice)
        {
            _titleservice= titleservice;
        }


        public async Task OnGet(int nameid)
        {
            title= await _titleservice.GetKnownTitlesbyid(nameid);
        }

        public async Task<IActionResult> OnPost()
        {
            await _titleservice.DeleteKnownTitles(title);
            return RedirectToPage("NamePage");
        }

    }
}
