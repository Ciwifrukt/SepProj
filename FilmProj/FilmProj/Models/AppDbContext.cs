using FilmProj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmProj
{
    public class AppDbContext : IdentityDbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<UserMovies> UserMovies { get; set; }

    }
}
