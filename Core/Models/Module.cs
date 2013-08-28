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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MonthPrice { get; set; }
    }
}