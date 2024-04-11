using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class NameUpdateModel : PageModel
    {

        private INameService _nameservice;

        [BindProperty]
        public Name name { get; set; }

        public NameUpdateModel(INameService nameservice)
        {
            _nameservice = nameservice;
        }

        public async Task OnGet(string id)
        {
            name = await _nameservice.GetNameByIdAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
           await _nameservice.UpdateName(name.nconst, name);
           return RedirectToPage("NamePage");
        }
    }
}
