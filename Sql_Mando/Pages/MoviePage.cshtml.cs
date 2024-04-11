using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sql_Mando.Interfaces;
using Sql_Mando.Models;

namespace Sql_Mando.Pages
{
    public class MoviePageModel : PageModel
    {
        public List<Movie> movies;

        private IMovieService _movieservice;

        public MoviePageModel(IMovieService movieservice)
        {
            _movieservice = movieservice;
        }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public async Task OnGet()
        {
            if(FilterCriteria==null)
            {
                FilterCriteria = "";
            }
            movies = await _movieservice.FindMovie(FilterCriteria);
        }
    }
}
