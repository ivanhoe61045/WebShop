using System.IO;
using System.Web;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public class FileOperationsRequest
    {
        public string GetNewPathFile(string server, ProdutCreationViewModel product, string extention)
        {            
            return string.Concat("/images/", product.ProducName + "-" + product.Gender.GenderName + extention);
        }

        public string GetExtentionFile(HttpPostedFileBase file)
        {
            return Path.GetExtension(file.FileName);
        }

        public string GetFileName(HttpPostedFileBase file)
        {
            return Path.GetFileName(file.FileName);
        }
    }
}
