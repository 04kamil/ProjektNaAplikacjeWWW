using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public static class RegistrationRepository
    {
        public static async Task Create(Registration r)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Registrations.Add(r);
                await db.SaveChangesAsync();
            }
        }

        public static Registration Read(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Registration r = db.Registrations.Find(id);
                return r;
            }
        }

        public static Registration FindByConfirmationCode(Guid id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Registration r = (from p in db.Registrations where p.ConfirmRegistrationCode == id.ToString() select p).SingleOrDefault();
                return r;
            }
        }

    }
}