using System.Web;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public  interface IGetFilesFromRequest
    {
        string GetUrlFileFromRequest(HttpRequestBase Request, string server, ProdutCreationViewModel product);
        
    }
}