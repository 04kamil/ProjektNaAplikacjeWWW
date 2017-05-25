using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuthorID { get; set; }


        public string Name { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfDeath { get; set; }

        public string Descryption { get; set; }



    }
}