using ProjektNaAplikacjeWWW.DAL;
using ProjektNaAplikacjeWWW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektNaAplikacjeWWW.CustomAttrib
{

    public class LogisExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as User;
            if (owner == null)
                return new ValidationResult("Model is empty");
            var user = UserRepository.IsLoginAvailable(value.ToString());

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Login already exist");

        }
    }


    public class MailExist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as User;
            if (owner == null)
                return new ValidationResult("Model is empty");
            var user = UserRepository.IsmailAvailable(value.ToString());

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Mail already exist");

        }
    }
}