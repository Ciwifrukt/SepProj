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
                    new Movie { Title = "Forest Gump", Director = "", Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75. ", ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/71CHZi4vhWL._SY679_.jpg" },
                    new Movie { Title = "Apollo 13", Director = "", Description = "NASA must devise a strategy to return Apollo 13 to Earth safely after the spacecraft undergoes massive internal damage putting the lives of the three astronauts on board in jeopardy. ", ImgUrl = "https://i.pinimg.com/originals/53/db/bd/53dbbd488e22c0479f923cf8fdf3b452.jpg" },
                    new Movie { Title = "Saving private ryan", Director = "", Description = "Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action. ", ImgUrl = "http://www.impawards.com/1998/posters/saving_private_ryan_ver2_xlg.jpg" },
                    new Movie { Title = "Hannibal", Director = "Ridley Scott", Description = "Living in exile, Dr. Hannibal Lecter tries to reconnect with now disgraced F.B.I. Agent Clarice Starling, and finds himself a target for revenge from a powerful victim. ", ImgUrl = "https://m.media-amazon.com/images/M/MV5BZDMxMjhiZmItNWMxMC00NzYyLWJiOTYtNGYwOTAyYjU5OWY4XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg" }

                );

                context.SaveChanges();
            }
        }
    }
}