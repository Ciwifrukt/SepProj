using System;
using System.Collections.Generic;
using System.Text;
using FilmProj.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmProj.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Movie> Movies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
