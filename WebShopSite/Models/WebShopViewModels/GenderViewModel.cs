using System.ComponentModel.DataAnnotations;

namespace WebShopSite.Models.WebShopViewModels
{
    public class GenderViewModel
    {
        public short IdGender { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Gender Name")]
        public string GenderName { get; set; }
    }
}