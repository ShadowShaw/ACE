using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PriceUpdater.Models
{
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Současné heslo")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nové heslo znovu")]
        [Compare("NewPassword", ErrorMessage = "Hesla se neshodují.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserPropertiesModel 
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Název společnosti")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Křestní jméno")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Adresa")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Plátce DPH")]
        public bool Dph { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Platební symbol")]
        public string PaymentSymbol { get; set; } // identifikace platby - variabilni symbol

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "ICO")]
        public string ICO { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "DIC")]
        public string DIC { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Pamatovat si mě?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Heslo znovu")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Název společnosti")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Křestní jméno")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Adresa")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Plátce DPH")]
        public bool Dph { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Platební symbol")]
        public string PaymentSymbol { get; set; } // identifikace platby - variabilni symbol

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "ICO")]
        public string ICO { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "DIC")]
        public string DIC { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
