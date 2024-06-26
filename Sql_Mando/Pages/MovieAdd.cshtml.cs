using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class MovieAddModel : PageModel
    {
        [BindProperty]
        public Movie movie { get; set; }

        private IMovieService _movieservice;
        public MovieAddModel(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            _movieservice.InsertMovie(movie);
            return RedirectToPage("MoviePage");
        }
    }
}
