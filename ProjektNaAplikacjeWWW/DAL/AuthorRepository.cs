using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public static class AuthorRepository
    {

        //Torzymy CRUD

        //Create
        public static async Task Create(Author a )
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Authors.Add(a);
                await db.SaveChangesAsync();
            }
        }

        //Read(all)
        public static List<Author> ReadAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Authors.ToList();
            }
        }

        public static Author Read(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Author a = db.Authors.Find(id);
                return a;
            }
        }


        //Update
        public static async Task Update(Author NewAuthor)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Author OldAuthor = db.Authors.Find(NewAuthor.AuthorID);
                OldAuthor.DateOfBirth = NewAuthor.DateOfBirth;
                OldAuthor.DateOfDeath = NewAuthor.DateOfDeath;
                OldAuthor.Descryption = NewAuthor.Descryption;
                OldAuthor.Name = NewAuthor.Name;
                await db.SaveChangesAsync();

            }
        }

        //Delete
        public static async Task Delete(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Authors.Remove((from p in db.Authors where p.AuthorID == id select p).SingleOrDefault());
                await db.SaveChangesAsync();
            }
        }
    }
}