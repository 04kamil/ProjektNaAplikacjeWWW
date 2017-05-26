using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.ViewModel
{
    public class CreateBookViewModel
    {
        public Book book { get; set; }
        public Author aut { get; set; }
        public List<Author> authors{ get; set; }
    }
}