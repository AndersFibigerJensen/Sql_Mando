using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class NameAddModel : PageModel
    {
        [BindProperty]
        public Name name { get; set; }

        private INameService _nameService; 

        public NameAddModel(INameService nameservice)
        {
            _nameService = nameservice;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _nameService.AddName(name);
            return RedirectToPage("NamePage");
        }
    }
}
