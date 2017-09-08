using System.Web;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public interface ISaveFilesFromRequest
    {
        bool SaveFile(HttpRequestBase Request, string server, ProdutCreationViewModel product);
    }
}
