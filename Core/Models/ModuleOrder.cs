using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("moduleOrder")]
    public class ModuleOrder : EFEntity<int>
    {
        [Display(Name = "Uživatel")]
        public int UserId { get; set; }
        [Display(Name = "Modul")]
        public int ModuleId { get; set; }
        [Display(Name = "Datum objednávky")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

    }
}