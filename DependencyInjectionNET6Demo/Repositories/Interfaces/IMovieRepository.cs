namespace DependencyInjectionNET6Demo.Repositories.Interfaces;

public interface IMovieRepository
{
    List<Movie> GetAll();
    Movie GetByID(int id);
}
