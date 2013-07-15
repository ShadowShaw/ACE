using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace Core.Models
{
    [Table("webpages_Membership")]
    public class MemberShip : EFEntity<int>
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
	    public string ConfirmationToken { get; set; }
	    public bool IsConfirmed { get; set; }
	    public DateTime? LastPasswordFailureDate { get; set; }
	    public int PasswordFailuresSinceLastSuccess { get; set; }
	    public string Password { get; set; }
	    public DateTime? PasswordChangedDate { get; set; }
	    public string PasswordSalt { get; set; }
	    public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}
