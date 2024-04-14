using Microsoft.eShopWeb;
using Microsoft.eShopWeb.PublicApi.OrdersEndpoints;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace PublicApiIntegrationTests.OrdersEndpoints;

[TestClass]
public class GetOrdersByIdEndpointTest
{
    [TestMethod]
    public async Task IfOrderExist()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/orders/1");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = stringResponse.FromJson<GetOrdersByIdResponse>();

        Assert.AreEqual(1, model?.SelectedOrder.Id);
    }

    [TestMethod]
    public async Task IfOrderNotFound()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/orders/0");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
