using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public class AuthorRepository
    {
        //Crud

        //Create Author
        public async Task AddAuthor(Author a)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                
                db.Authors.Add(a);
                await db.SaveChangesAsync();
            }
        }

        //Get author
        public Author GetAuthor(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var choosen = db.Authors.First(item => item.AuthorID == id);
                return choosen;
            }
        }
        //get uthor list
        public List<Author> GetAuthorList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var list = db.Authors.ToList();
                return list;
            }
        }

        //remove author from list
        public async Task RemoveAuthor(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var querry = db.Authors.FirstOrDefault(item => item.AuthorID == id);
                db.Authors.Remove(querry);
                await db.SaveChangesAsync();
            }
        }

        //public async Task Edit()
        public async Task EditAuthor(Guid id, string _name, string _DateOfBirth, string _DateOfDeath, string _descryption)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var author = db.Authors.SingleOrDefault(item => item.AuthorID == id);

                if (_name != null)
                {
                    author.Name = _name;
                }

                if (_DateOfBirth != null)
                {
                    author.DateOfBirth = _DateOfBirth;
                }

                if (_DateOfDeath != null)
                {
                    author.DateOfDeath = _DateOfDeath;
                }

                if (_descryption != null)
                {
                    author.Descryption = _descryption;
                }
                await db.SaveChangesAsync();
            }
        }


    }
}