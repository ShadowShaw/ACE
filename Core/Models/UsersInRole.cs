using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{

    [Table("webpages_UsersInRoles")]
    public class UsersInRole //: EFEntity<int>
    {
        [Key, Column(Order = 0)]
        public int RoleId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        [Column("RoleId"), InverseProperty("UsersInRoles")]
        public Role Roles { get; set; }

        //[Column("UserId"), InverseProperty("UsersInRoles")]
        //public MemberShip Members { get; set; }



    }
}