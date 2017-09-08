using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebShopSite.Hubs
{
    public class ProductHub : Hub
    {        
        [HubMethodName("ProductData")]
        public static void ProductData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ProductHub>();
            context.Clients.All.updatedData();
        }
    }
}