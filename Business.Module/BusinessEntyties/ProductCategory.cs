using System.Collections.Generic;

namespace Business.Module.BusinessEntyties
{
    public class ProductCategory
    {
        public long IdProductCategory { get; set; }

        public virtual IEnumerable<Category> Category { get; set; }

        public virtual Product Product { get; set; }
       
    }
}
