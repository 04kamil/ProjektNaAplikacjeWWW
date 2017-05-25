using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }

        [Display(Name = "FirstName",ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorFirstName",ErrorMessageResourceType =typeof(Resources.Localization))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorLastName", ErrorMessageResourceType = typeof(Resources.Localization))]
        public string LastName { get; set; }

        [Display(Name ="Login",ResourceType =typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorLogin", ErrorMessageResourceType = typeof(Resources.Localization))]
        public string Login { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorPassword", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        public bool Active { get; set; }

        [Required]
        public int AccountType { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorEmail", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessage = "ErrorPhoneNumber", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public User()
        {
            Active = false;
            AccountType = 0;
        }

    }
}