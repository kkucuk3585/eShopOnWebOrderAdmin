namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class GetOrdersRequest : BaseRequest
{
    public int OrdersId { get; init; }
}
