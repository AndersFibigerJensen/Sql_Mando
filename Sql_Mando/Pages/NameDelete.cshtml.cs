using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class NameDeleteModel : PageModel
    {
        private INameService _nameservice;

        [BindProperty]
        public Name name { get; set; }

        public NameDeleteModel(INameService nameservice)
        {
            _nameservice = nameservice;
        }

        public async Task OnGet(string id)
        {
            name = await _nameservice.GetNameByIdAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _nameservice.DeleteName(name.nconst);
            return RedirectToPage("NamePage");
        }

    }
}
