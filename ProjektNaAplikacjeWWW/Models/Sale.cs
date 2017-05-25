using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SaleID { get; set; }

        public DateTime DateOfSale { get; set; }

        public Decimal Price { get; set; }

        public virtual User Buyer { get; set; }

        public virtual Book Product { get; set; }


    }
}