using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProj.Models.ViewModels
{
    public class AddRoleVm
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
