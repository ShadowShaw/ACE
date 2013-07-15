using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("webpages_Roles")]
    public class UserRole : EFEntity<int>
    {
        public int UserId { get; set; }
	    public string RoleName { get; set; }
    }
}