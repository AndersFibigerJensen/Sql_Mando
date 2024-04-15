using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class AddGenreModel : PageModel
    {
        [BindProperty]
        public Genre Genre { get; set; }

        [BindProperty]
        public string id { get; set; }

        private IGenreService _genreservice;

        public AddGenreModel(IGenreService genreservice)
        {
            _genreservice = genreservice;
        }

        public async Task OnGet(string movieid)
        {
            id = movieid;
        }

        public async Task<IActionResult> OnPost()
        {
            _genreservice.AddGenre(Genre);
            return RedirectToPage("MoviePage");
        }
    }
}
