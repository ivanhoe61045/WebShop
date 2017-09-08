namespace Persistence.Data.WebShopModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WebShop.OrderHistory")]
    public partial class OrderHistory
    {
        [Key]
        public long IdOrderHistory { get; set; }

        public long IdOrder { get; set; }

        public short IdOrderState { get; set; }

        public DateTime DateUpdate { get; set; }

        public virtual OrderState OrderState { get; set; }

        public virtual Order Order { get; set; }
    }
}
