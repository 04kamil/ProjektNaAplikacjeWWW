using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public static class UserRepository
    {
        //Create

        public static async Task Create(User u)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(u);
                await db.SaveChangesAsync();
            }
        }




        //Read(all)
        public static List<User> ReadAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.ToList();
            }
        }

        public static User Read(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User a = db.Users.Find(id);
                return a;
            }
        }


        //Update
        public static async Task Update(User NewUser)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User OldUser = db.Users.Find(NewUser.UserID);
                OldUser.FirstName = NewUser.FirstName;
                OldUser.LastName = NewUser.LastName;
                OldUser.Email = NewUser.Email;
                OldUser.Phone = NewUser.Phone;
                OldUser.Login = NewUser.Login;
                await db.SaveChangesAsync();

            }
        }

        //Delete
        public static async Task Delete(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Remove((from p in db.Users where p.UserID == id select p).SingleOrDefault());
                await db.SaveChangesAsync();
            }
        }

        //ActiveAcount

        public static async Task ActiveAccount(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User u = (from p in db.Users where p.UserID == id select p).SingleOrDefault();
                if(u!=null)
                {
                    u.Active = true;
                    await db.SaveChangesAsync();
                }
            }
        }



    }
}