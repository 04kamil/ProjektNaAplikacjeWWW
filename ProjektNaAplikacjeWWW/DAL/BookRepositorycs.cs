using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public static class BookRepositorycs
    {

        //Create
        public static async Task Create(Book a)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Books.Add(a);
                await db.SaveChangesAsync();
            }
        }

        //Read All
        public static List<Book> ReadAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Books.ToList();
            }
        }
        //Read
        public static Book Read(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Book b = db.Books.Find(id);
                return b;
            }
        }

        //Update
        public static async Task Update(Book NewBook)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Book OldBook = db.Books.Find(NewBook.BookId);
                OldBook.BookAuthor = NewBook.BookAuthor;
                OldBook.Descryption = NewBook.Descryption;
                OldBook.URL = NewBook.URL;
                OldBook.ISBN = NewBook.ISBN;
                OldBook.Lang = NewBook.Lang;
                OldBook.Pages = NewBook.Pages;
                OldBook.Title = NewBook.Title;
                await db.SaveChangesAsync();
            }
        }



        //Delete
        public static async Task Delete(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Books.Remove((from p in db.Books where p.BookId==id select p).FirstOrDefault());
                await db.SaveChangesAsync();
            }
        }



    }
}