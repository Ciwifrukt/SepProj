using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class Pie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        /*
        Denna rad ger info till Entity Framework exakt vilken datatyp som ska användas i SQL-databasen
        Tack vare den info så slipper vi få varningar när vi kör Add-Migration och Update-Database
        Generellt: alla attribut skrivs inom hakparanteser och de innehåller meta-info om (endast) den följande propertyn. Eller klassen.
        */
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool IsInStock { get; set; }

    }
}
