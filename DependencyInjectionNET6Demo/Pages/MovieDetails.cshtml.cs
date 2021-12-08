using DependencyInjectionNET6Demo.Models;
using DependencyInjectionNET6Demo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DependencyInjectionNET6Demo.Pages
{
    public class MovieDetailsModel : PageModel
    {
        private readonly IMovieRepository _movieRepo;
        public Movie Movie;

        public MovieDetailsModel(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public void OnGet(int id)
        {
            Movie = _movieRepo.GetByID(id);
        }
    }
}
