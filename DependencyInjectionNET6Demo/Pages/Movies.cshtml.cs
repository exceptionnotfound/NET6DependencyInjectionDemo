using DependencyInjectionNET6Demo.Models;
using DependencyInjectionNET6Demo.Repositories.Interfaces;
using DependencyInjectionNET6Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DependencyInjectionNET6Demo.Pages;

public class MoviesPageModel : PageModel
{
    private readonly IMovieRepository _movieRepo;
    private readonly ICacheService _cache;
    private readonly ICustomLogger _logger;
    public List<Movie> Movies { get; set; } = new List<Movie>();

    public MoviesPageModel(IMovieRepository movieRepo, ICacheService cache, ICustomLogger logger)
    {
        _movieRepo = movieRepo;
        _cache = cache;
        _logger = logger;
    }

    public void OnGet()
    {
        try
        {
            var movies = _cache.Get<List<Movie>>("allMovies");

            if (movies == null)
            {
                Movies = _movieRepo.GetAll();
                _cache.Add("allMovies", Movies);
            }
            else
            {
                Movies = movies;
            }
        }
        catch(Exception ex)
        {
            _logger.Log(ex);
        }
    }
}