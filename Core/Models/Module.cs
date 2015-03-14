using Core.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("acemodules")]
    public class AceModule : EfEntity<int>
    {
        [Display(Name = "Jméno modulu")]
        public string Name { get; set; }
        [Display(Name = "Popis modulu")]
        public string Description { get; set; }
        [Display(Name = "Měsíční platba")]
        public decimal MonthPrice { get; set; }
    }
}