var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

//Transient services are created by the container every time they need to be injected.
//If two classes rely on the same dependency, and both classes are used during the same request,
//each class will receive different instances of that dependency.
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IActorRepository, ActorRepository>(); //In the ActorRepository.cs file, uncomment the class's code to cause a circular dependency

//Scoped services are created once per request.
//That means, if a dependency needs to be injected twice in the same request,
//both injections will receive the same instance.
//However, on the next web request, the dependency being injected will be a NEW instance.
builder.Services.AddScoped<ICustomLogger, CustomLogger>();

//Singleton services are only created once; all injections receive the same instance.
//In this way, state changes to the dependency are preserved.
builder.Services.AddSingleton<ICacheService, CacheService>();

//.NET includes a bunch of helper methods which can inject commonly-used services, such as the ones for Razor Pages.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    //This particular option sets the default route to the /Movies route, which maps to the Movies.cshtml Razor Page.
    options.Conventions.AddPageRoute("/Movies", "");
});

var app = builder.Build();

//The below code means that, when running in a development environment, exceptions will not be handled
//by the Error.cshtml page, and will instead be shown to the user.
if (!app.Environment.IsDevelopment()) //If the app is NOT running in a development environment
{
    app.UseExceptionHandler("/Error"); //Route all exceptions to the Error.csthml Razor Page.
}

app.UseHttpsRedirection();

//Enables the use of CSS and JS files in the wwwroot folder.
app.UseStaticFiles();

//Enables the routing subsystem
app.UseRouting();

app.UseAuthorization();

//Adds endpoints for Razor Pages to the routing system.
app.MapRazorPages();

app.Run();
