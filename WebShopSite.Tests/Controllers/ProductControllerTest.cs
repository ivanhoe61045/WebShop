using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShopSite.Controllers;

namespace WebShopSite.Tests.Controllers
{
    public class ProductControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
