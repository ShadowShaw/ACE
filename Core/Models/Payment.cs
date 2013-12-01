using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("payments")]
    public class Payment : EFEntity<int>
    {
        [Display(Name = "Částka")]
        public decimal Amount { get; set; }
        [Display(Name = "Datum platby")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Platební symbol")]
        public string PaymentSymbol { get; set; }
        [Display(Name = "Číslo faktury")]
        public decimal InvoiceNumber { get; set; }
    }
}