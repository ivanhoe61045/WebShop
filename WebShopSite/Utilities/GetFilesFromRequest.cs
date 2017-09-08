using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebShopSite.Models.WebShopViewModels;

namespace WebShopSite.Utilities
{
    public class GetFilesFromRequest : FileOperationsRequest, IGetFilesFromRequest
    {
        public string GetUrlFileFromRequest(HttpRequestBase Request, string server, ProdutCreationViewModel product)
        {
            string ImageUrl = string.Empty;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = GetFileName(file);
                    string extention = GetExtentionFile(file);
                    string path = GetNewPathFile(server, product, extention);
                    if (!string.IsNullOrEmpty(path))
                        ImageUrl = path;
                }
            }
            return ImageUrl;
        }


    }
}