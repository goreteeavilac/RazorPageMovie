using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Plugins;
using RazorPageMovie.Data;
using RazorPageMovie.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorPageMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPageMovieContext' not found.")));
//Si no se me genera lo del scaffol se debe eliminar la parte de builder
var app = builder.Build();
//Instanciar SeedData en caso de que no tengamos ningun dato
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
