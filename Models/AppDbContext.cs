using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    /*
       I normala fall så ärver vi ifrån DbContext
       Men eftersom vi använder "Identity" så behöver vi ärva från "IdentityDbContext" (som i sin tur ärver från DbContext)
       IdentityDbContext är ett barnbarnbarnbarnbarn av DbContext
    */
    public class AppDbContext: IdentityDbContext
    {
        /*
         ...och konstruktorn ser lite annorlunda ut. 
         Detta är omöjligt att komma ihåg. Typiskt en sådan sak som du utan dåligt samvete kan kopiera från ett tidigare projekt.
        */
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
