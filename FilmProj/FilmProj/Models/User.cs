using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProj.Models
{
    public enum Role
    {
        basic, super
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role role { get; set; }
    }
}
