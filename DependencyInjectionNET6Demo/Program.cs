using DependencyInjectionNET6Demo.Repositories;
using DependencyInjectionNET6Demo.Repositories.Interfaces;
using DependencyInjectionNET6Demo.Services;
using DependencyInjectionNET6Demo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Transient services are created by the container every time they need to be injected.
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IActorRepository, ActorRepository>(); //In the ActorRepository.cs file, uncomment the class's code to cause a circular dependency

//Scoped services are created once per request.
//That means, if a dependency needs to be injected twice in the same request,
//both injections will receive the same instance.
builder.Services.AddScoped<ICustomLogger, CustomLogger>();

//Singleton services are only created once; all injections receive the same instance.
builder.Services.AddSingleton<ICacheService, CacheService>();

//.NET includes a bunch of helper methods which can inject commonly-used services, such as the ones for Razor Pages.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Movies", "");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
