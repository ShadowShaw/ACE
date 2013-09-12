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
    public class ModuleOrders
    {
        public int ModuleId { get; set; }
        
        [Display(Name = "Jméno modulu")]
        public string ModuleName { get; set; }

        [Display(Name = "Cena modulu za měsíc")]
        public decimal MonthPrice { get; set; }

        [Display(Name = "Objednán")]
        public bool Active { get; set; }

        [Display(Name = "Objednán do")]
        public DateTime? OrderDate { get; set; }
    }

    public class PaymentFacture
    {
        public int FactureId { get; set; }
        
        public string FactureName { get; set; }

        public decimal Price { get; set; }
    }

}
