using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("UserProfile")]
    public class UserProfile : EFEntity<int>
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public int UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CorrespondentionAddress { get; set; }
        public string FacturationAddress { get; set; }
        public string EshopUrl { get; set; }
        public bool Dph { get; set; }
        public string PaymentSymbol { get; set; } // identifikace platby - variabilni symbol
        public string ICO { get; set; }
        public string DIC { get; set; }
        public decimal Credit { get; set; }
    }
}
