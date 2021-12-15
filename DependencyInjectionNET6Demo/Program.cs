using DependencyInjectionNET6Demo.Repositories;
using DependencyInjectionNET6Demo.Repositories.Interfaces;
using DependencyInjectionNET6Demo.Services;
using DependencyInjectionNET6Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Transient services are created by the container every time they need to be injected.
builder.Services.AddTransient<IMovieRepository, MovieRepository>();

//Uncomment the below line
builder.Services.AddTransient<IActorRepository, ActorRepository>();

//Scoped services are created once per request.
//That means, if a dependency needs to be injected twice in the same request,
//both injections will receive the same instance.
builder.Services.AddScoped<ICustomLogger, CustomLogger>();

//Singleton services are only created once; all injections receive the same instance.
builder.Services.AddSingleton<ICacheService, CacheService>();
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
