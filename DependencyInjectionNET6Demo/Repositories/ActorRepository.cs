namespace DependencyInjectionNET6Demo.Repositories;

public class ActorRepository : IActorRepository 
{
    //Uncomment the below lines to cause a circular dependency.

    //private readonly IMovieRepository _movieRepo;

    //public ActorRepository(IMovieRepository movieRepo)
    //{
    //    _movieRepo = movieRepo;
    //}
}