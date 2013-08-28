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
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}