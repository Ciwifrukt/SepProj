using FilmProj.Models;
using System;
using System.Linq;

namespace FilmProj
{
    internal class DbInitializer
    {
        internal static void Seed(AppDbContext context)
        {

            if (!context.Movie.Any())
            {
                context.AddRange
                (
                    new Movie { Title = "Forest Gump", Director = "", Description = "Fun", ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/71CHZi4vhWL._SY679_.jpg" },
                    new Movie { Title = "Apollo 13", Director = "", Description = "Fun", ImgUrl = "https://i.pinimg.com/originals/53/db/bd/53dbbd488e22c0479f923cf8fdf3b452.jpg" },
                    new Movie { Title = "Saving private ryan", Director = "", Description = "Fun", ImgUrl = "http://www.impawards.com/1998/posters/saving_private_ryan_ver2_xlg.jpg" },
                    new Movie { Title = "Hannibal", Director = "", Description = "Fun", ImgUrl = "https://m.media-amazon.com/images/M/MV5BZDMxMjhiZmItNWMxMC00NzYyLWJiOTYtNGYwOTAyYjU5OWY4XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg" }



                );

                context.SaveChanges();
            }
        }
    }
}