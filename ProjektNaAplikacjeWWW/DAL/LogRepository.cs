using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjektNaAplikacjeWWW.DAL
{
    public static class LogRepository
    {
        //Send log
        public static async Task Create(Log l)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Logs.Add(l);
                await db.SaveChangesAsync();
            }
        }

        //ClearDataBase
        public static async Task Clear()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                foreach(Log l in db.Logs)
                {
                    db.Logs.Remove(l);
                }
                await db.SaveChangesAsync();

            }
        }
    }
}