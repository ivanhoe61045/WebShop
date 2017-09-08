using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module.BusinessEntyties
{
    public class Order
    {
        public long IdOrder { get; set; }

        public short IdOrderState { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual OrderState OrderState { get; set; }

        public virtual Customer Customers { get; set; }
    }
}
