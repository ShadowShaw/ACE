using System;
using System.ComponentModel.DataAnnotations;

namespace ACEAgent.Models
{
    public class ModuleOrders
    {
        public int ModuleId { get; set; }
        
        [Display(Name = "Jméno modulu")]
        public string ModuleName { get; set; }

        [Display(Name = "Popis modulu")]
        public string ModuleDescription { get; set; }

        [Display(Name = "Cena modulu za měsíc")]
        public decimal MonthPrice { get; set; }

        [Display(Name = "Objednán")]
        public bool Active { get; set; }

        [Display(Name = "Objednán do")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }
    }

    public class PaymentFacture
    {
        public string IssuerName  { get; set; }
        public string IssuerAddress  { get; set; }
        public string ReceiverName  { get; set; }
        public string ReceiverAddress  { get; set; }
        
        [Display(Name = "Datum vydání")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime IssueDate  { get; set; }

        [Display(Name = "Datum splatnosti")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDate  { get; set; }

        [Display(Name = "Datum zdanitelného plnění")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FillingDate  { get; set; }

        public string FactureNumber  { get; set; }
        public decimal Price { get; set; }
    }

}
