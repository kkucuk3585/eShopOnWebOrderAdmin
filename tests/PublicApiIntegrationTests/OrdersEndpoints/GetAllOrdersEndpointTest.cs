using BlazorShared.Models;
using Microsoft.eShopWeb;
using Microsoft.eShopWeb.PublicApi.OrdersEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicApiIntegrationTests.OrdersEndpoints;

[TestClass]
public class GetAllOrdersEndpointTest
{
    [TestMethod]
    public async Task IfOrdersExist()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/orders");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = stringResponse.FromJson<GetAllOrdersResponse>();

        Assert.AreNotEqual(0, model?.OrderList.Count);
    }
}
