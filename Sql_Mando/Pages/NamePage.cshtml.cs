using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class NamePageModel : PageModel
    {

        public List<Name> names;

        private INameService _nameService;

        public NamePageModel(INameService nameservice)
        {
            _nameService = nameservice;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public async Task OnGet()
        {
            if (FilterCriteria == null)
            {
                FilterCriteria = "";
            }
            names = await _nameService.FindName(FilterCriteria);
        }
    }
}
