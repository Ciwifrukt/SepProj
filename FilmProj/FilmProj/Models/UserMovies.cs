using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProj.Models
{
    public class UserMovies
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Movie> ToWatch { get; set; }
        public List<Movie> Watched { get; set; }
    }
}
