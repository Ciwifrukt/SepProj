using FilmProj.Models;
using System.Security.Principal;
namespace FilmProj.ViewModels
{
    public class MovieVm
    {
        public IIdentity UserId { get; set; }
        public Movie Movie { get; set; }

    }
}
