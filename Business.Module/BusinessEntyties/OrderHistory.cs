using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module.BusinessEntyties
{
    public class OrderHistory
    {
        public long IdOrderHistory { get; set; }
        
        public DateTime DateUpdate { get; set; }

        public virtual OrderState OrderState { get; set; }

        public virtual Order Order { get; set; }
    }
}
