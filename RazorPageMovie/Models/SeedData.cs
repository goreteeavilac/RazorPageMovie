using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;


namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize (IServiceProvider serviceProvider) //Constructor
        {
            //Inicializando para meter parametros datos en nuestra BD cuando se corra por primera vez nuestro proyecto
            using (var context = new RazorPageMovieContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<RazorPageMovieContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPageMovieContext"); //Manda mensaje
                }
                //Para ver cualquier pelicula
                if (context.Movie.Any())
                {
                    return; //La base de datos muestra todo lo que contiene la clase
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Encanto",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Gender = "Princesas",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Sirenita",
                        ReleaseDate = DateTime.Parse("1990-3-24"),
                        Gender = "Princesas",
                        Price = 9.10M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Bella Durmiente",
                        ReleaseDate = DateTime.Parse("1994-5-13"),
                        Gender = "Princesas",
                        Price = 3.4M,
                        Rating = "NA"
                    },
                    new Movie
                    {
                        Title = "Cars",
                        ReleaseDate = DateTime.Parse("2005-5-23"),
                        Gender = "Carros",
                        Price = 1.2M,
                        Rating = "G"
                    }
                    );
                context.SaveChanges();        
            }
        }

    }
}