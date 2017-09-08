using Business.Module.BusinessEntyties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopSite.Models.WebShopViewModels
{
    public class ProdutCreationViewModel
    {
        [Display(Name = "Product Number")]
        public long IdProduct { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProducName { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Product Title")]
        public string Title { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Product Image")]
        public string Image { get; set; }

        [Display(Name = "Product State")]
        public bool State { get; set; }

        [Required]
        [Display(Name = "Product Gender")]
        public int IdGender { get; set; }
                
        [Display(Name = "Product Gender")]
        public Gender Gender { get; set; }
        
        [Display(Name ="Categories")]
        public List<CategoriesViewModel> ListCategories { get; set; }
    }
}