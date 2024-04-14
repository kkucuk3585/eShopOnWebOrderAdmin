namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class GetOrdersByIdRequest : BaseRequest
{
    public int OrderId { get; init; }

    public GetOrdersByIdRequest(int orderId)
    {
        OrderId = orderId;
    }
}
