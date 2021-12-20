namespace DependencyInjectionNET6Demo.Extensions;

public static class ServiceExtensions
{
    public static void RegisterRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IMovieRepository, MovieRepository>();
        //Add other repositories
    }

    public static void RegisterLogging(this IServiceCollection collection)
    {
        //Register logging
    }

    public static void RegisterAuthentication(this IServiceCollection collection)
    {
        //Register authentication services.
    }
}