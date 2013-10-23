using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace ACEAgent.Models
{
    public class RegisterExternalLoginModel
    {
        [Required(ErrorMessage = "Uživatelské jméno nemůže být prázdné.")]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required(ErrorMessage = "Heslo nemůže být prázdné.")]
        [DataType(DataType.Password)]
        [Display(Name = "Současné heslo")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Heslo nemůže být prázdné.")]
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
        public int Id { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Název společnosti nemůže bý prázdný.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Název společnosti")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Křestní jméno nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Křestní jméno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Příjmení nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Korespondenční adresa nemůže být prázdná.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Korespondenční adresa")]
        public string CorrespondentionAddress { get; set; }

        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Fakturační adresa (Nevyplňujte, pokud je stejná s Korespondenční adresou)")]
        public string FacturationAddress { get; set; }

        [Required(ErrorMessage = "Web adresa eshopu nemůže být prázdná.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Web adresa eshopu, včetně http://, https://")]
        [Url(ErrorMessage = "Web adresa eshopu není ve správném formátu.")]
        public string EshopUrl { get; set; }

        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email nemůže bý prázdný.")]
        [Email(ErrorMessage = "Email není ve správném formátu.")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Plátce DPH")]
        public bool Dph { get; set; }

        [Required(ErrorMessage = "Platební symbol nemůže být prázdný.")]
        [StringLength(9, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 9)]
        [Display(Name = "Platební symbol")]
        public string PaymentSymbol { get; set; } // identifikace platby - variabilni symbol

        [Required(ErrorMessage = "ICO nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "ICO")]
        public string ICO { get; set; }

        [Required(ErrorMessage = "DIC nemůže být prázdný.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "DIC")]
        public string DIC { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Uživatelské jméno nemůže být prázdné.")]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Heslo nemůže být prázdné.")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Pamatovat si mě?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Uživatelské jméno nemůže být prázdné.")]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "Uživatelské jméno již existuje, vyberte prosím jiné.")]
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Heslo nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Heslo znovu")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Název společnosti nemůže být prázdný.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Název společnosti")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Křestní jméno nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Křestní jméno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Příjmení nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Korespondenční adresa nemůže být prázdná.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Korespondenční adresa")]
        public string CorrespondentionAddress { get; set; }

        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Fakturační adresa (Nevyplňujte, pokud je stejná s Korespondenční adresou)")]
        public string FacturationAddress { get; set; }

        [Required(ErrorMessage = "Web adresa eshopu nemůže být prázdná.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Web adresa eshopu, včetně http://, https://")]
        [Url(ErrorMessage = "Web adresa eshopu není ve správném formátu.")]
        public string EshopUrl { get; set; }

        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email nemůže bý prázdný.")]
        [Email(ErrorMessage = "Email není ve správném formátu.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Plátce DPH")]
        public bool Dph { get; set; }

        [Required(ErrorMessage = "Platební symbol nemůže být prázdný.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "Platební symbol(Variabilní symbol pro identifikaci platby).")]
        public string PaymentSymbol { get; set; } // identifikace platby - variabilni symbol

        [Required(ErrorMessage = "ICO nemůže být prázdné.")]
        [StringLength(100, ErrorMessage = "{0} musí být minimálně {2} znaky dlouhé.", MinimumLength = 2)]
        [Display(Name = "ICO")]
        public string ICO { get; set; }

        [Required(ErrorMessage = "DIC nemůže být prázdný.")]
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
