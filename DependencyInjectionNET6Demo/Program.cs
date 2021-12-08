using DependencyInjectionNET6Demo.Repositories;
using DependencyInjectionNET6Demo.Repositories.Interfaces;
using DependencyInjectionNET6Demo.Services;
using DependencyInjectionNET6Demo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICustomLogger, CustomLogger>();
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
