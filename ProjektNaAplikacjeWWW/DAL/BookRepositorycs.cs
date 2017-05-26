using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public class BookRepositorycs
    {
        public async Task AddBook(Book a)
        {
            using (DatabaseContext db = new DatabaseContext())
            {

                db.Books.Add(a);
                await db.SaveChangesAsync();
            }
        }

    }
}