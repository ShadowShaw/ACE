using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("acemodules")]
    public class ACEModule : EFEntity<int>
    {
        [Display(Name = "Jméno modulu")]
        public string Name { get; set; }
        [Display(Name = "Popis modulu")]
        public string Description { get; set; }
        [Display(Name = "Měsíční platba")]
        public decimal MonthPrice { get; set; }
    }
}