using System.IO;
using System.Web;
using Transversal.Module.CustomException;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public class SaveFilesFromRequest : FileOperationsRequest, ISaveFilesFromRequest
    {
        public bool SaveFile(HttpRequestBase Request, string server, ProdutCreationViewModel product)
        {
            bool successfull = false;
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    var extention = Path.GetExtension(file.FileName);
                    if (extention.ToLower()!=".jpg" && extention.ToLower() != ".png" && extention.ToLower() != ".gif")
                    {
                        throw new NotValidExtentionException("Not valid Extention");
                    }
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);                        
                        var path = Path.Combine(server, product.ProducName + "-" + product.Gender.GenderName + extention);
                        file.SaveAs(path);
                        successfull = true;
                    }
                    else
                        successfull = false;
                }
            }
            catch (System.Exception ex)
            {

                throw new FilesRequestFailedException(ex.Message);
            }
            
            return successfull;
        }
    }
}