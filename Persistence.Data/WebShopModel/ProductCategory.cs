namespace Persistence.Data.WebShopModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebShop.ProductCategory")]
    public partial class ProductCategory
    {
        [Key]
        public long IdProductCategory { get; set; }

        public long IdProduct { get; set; }

        public int IdCategory { get; set; }

        public  Categories Categories { get; set; }

        public virtual Product Product { get; set; }
    }
}
