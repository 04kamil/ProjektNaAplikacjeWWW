using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.Models
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RegistrationID { get; set; }

        public DateTime EmailSend { get; set; }
        public DateTime EmailExpired { get; set; }

        public string ConfirmRegistrationCode { get; set; }

        public virtual User Uzk { get; set; }

    }
}