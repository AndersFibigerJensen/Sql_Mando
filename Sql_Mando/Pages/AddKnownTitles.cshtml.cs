using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class AddKnownTitlesModel : PageModel
    {
        [BindProperty]
        public KnownTitles title { get; set; }
        public void OnGet()
        {
        }
    }
}
