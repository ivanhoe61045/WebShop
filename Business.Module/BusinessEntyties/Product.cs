using System.Collections.Generic;

namespace Business.Module.BusinessEntyties
{
    public class Product
    {
        #region properties
        public long IdProduct { get; set; }

        public string ProducName { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool State { get; set; }

        public Gender Gender { get; set; }

        public List<Category> ListCategories { get; set; }
        
        #endregion
                
    }
}
