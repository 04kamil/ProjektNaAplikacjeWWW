using ProjektNaAplikacjeWWW.CustomAttrib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektNaAplikacjeWWW.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }

        [Display(Name = "FirstName",ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorFirstName",ErrorMessageResourceType =typeof(Resources.Localization))]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorLastName", ErrorMessageResourceType = typeof(Resources.Localization))]
        public string LastName { get; set; }
     

        //[Remote("IsLoginAvailable","User",HttpMethod ="POST",ErrorMessage = "Login jest zajety")]
        [LogisExist]
        [Display(Name ="Login",ResourceType =typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorLogin", ErrorMessageResourceType = typeof(Resources.Localization))]
        public string Login { get; set; }

        [MinLength(6,ErrorMessage ="Hasło musi się składać z min 6 znaków")]
        [Display(Name = "Password", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorPassword", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    

        public bool Active { get; set; }

        [Required]
        public int AccountType { get; set; }

        [MailExist]
        [Display(Name = "Email", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorEmail", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorPhoneNumber", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public User()
        {
            Active = false;
            AccountType = 0;
        }

    }
}