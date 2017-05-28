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

        public static void ActiveAccount(User u)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User user = db.Users.Find(u.UserID);
                if(u!=null)
                {
                    user.Active = true;
                    //testowanie co mu sie nie podoba
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting
                                // the current instance as InnerException
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                    
                }
            }
        }



    }
}