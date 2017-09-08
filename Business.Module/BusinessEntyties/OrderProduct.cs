using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Module.BusinessEntyties
{
    public class OrderProduct
    {
        public long IdOrderProduct { get; set; }
        
        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
