using System.ComponentModel.DataAnnotations;

namespace WebShopSite.Models.WebShopViewModels
{
    public class CategoriesViewModel
    {
        [Display(Name = "Category Number")]
        public int IdCategory { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category State")]
        public bool CatergoryState { get; set; }
    }
}