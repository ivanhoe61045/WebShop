namespace Persistence.Data.WebShopModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebShop.OrderProduct")]
    public partial class OrderProduct
    {
        [Key]
        public long IdOrderProduct { get; set; }

        public long IdOrder { get; set; }

        public long IdProduct { get; set; }

        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
