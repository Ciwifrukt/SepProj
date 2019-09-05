using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop
{
    /*
     Denna klass körs när din app startar. Här konfigurerar du sajten. 
     T.ex säger du vilken connectionsträng som ska användas till databasen.
     Du kan också välja att göra olika konfigurering beroende på om sajten körs på din dator eller i produktion 
     (t.ex vill du ha detaljerade felmeddelanden när du körs på din dator men inte i produktion)
     
     Det kan vara intressant att se vilken ordning saker körs. 
     Det ser du genom att sätta massa breakpoints i "Program.cs" och i denna fil.

     Då ser du att ordningen är
     1) Main (i Startup.cs)
     2) Startup (konstruktorn i denna fil)
     3) ConfigureServices
     4) Configure
    */
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            /*
               Här konfigureras "Dependency Injection" (detta är lite advanced stuff)

               Om du ser "IPieRepository" i konstruktorn på en klass (normalt sett en Controller) så skapa en instans av PieRepository
               
               Om du istället vill använda "MockPieRepository" så hade du skrivit:
               
               services.AddTransient<IPieRepository, MockPieRepository>();
            */
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();

            /*
               "AddDbContext" => använd Entity Framework med konfigureringen ur klassen "AppDbContext"
               "UseSqlServer" => vi vill använda SQL Server som databas 
               "DefaultConnection" => använd connectionsträngen "DefaultConnection" i appsettings.json
            */
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            /*
             Raden nedan gör att vi kan använda Identity (Microsoft sätt att hantera inloggning och roller)
             */
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
