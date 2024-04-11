using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class MovieDeleteModel : PageModel
    {

        private IMovieService _movieservice;

        [BindProperty]
        public Movie movie { get; set; }

        public MovieDeleteModel(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }

        public async Task OnGet(string id)
        {
            movie= await _movieservice.FindMovieById(id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _movieservice.DeleteMovie(movie.tconst);
            return RedirectToPage("MoviePage");
        }
    }
}
