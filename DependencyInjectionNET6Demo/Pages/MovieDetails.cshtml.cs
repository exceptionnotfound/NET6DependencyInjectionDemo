using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DependencyInjectionNET6Demo.Pages;

public class MovieDetailsModel : PageModel
{
    private readonly IMovieRepository _movieRepo;
    private readonly ICustomLogger _logger;
    public Movie Movie = new();

    //In the Program.cs file, IMovieRepository is declared as transient, and ICustomLogger is declared as scoped.
    //MovieRepository has an instance of ICustomLogger in its constructor, just like this class does.
    //When the user goes to this page, the MovieRepository instance and the MovieDetailsModel instance
    //  will receive the *same* instance of CustomLogger.
    //But, if the user refreshes the page, both dependencies will receive a *new* instance of CustomLogger (each one receiving the same new instance)
    
    public MovieDetailsModel(IMovieRepository movieRepo, ICustomLogger logger)
    {
        _movieRepo = movieRepo;
        _logger = logger;
    }

    public void OnGet(int id)
    {
        Movie = _movieRepo.GetByID(id);
        _logger.Log("GET action fired!");
    }

    public void OnPost()
    {
        _logger.Log("POST action fired!");
    }
}