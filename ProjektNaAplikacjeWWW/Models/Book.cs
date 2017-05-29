using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BookId { get; set; }


        [Required]
        public string Title { get; set; }

        public string Lang { get; set; }

        public int Pages { get; set; }

        public string ISBN { get; set; }

        public string Descryption { get; set; }

        public string URL { get; set; }

        public virtual Author BookAuthor { get; set; }

    }
}