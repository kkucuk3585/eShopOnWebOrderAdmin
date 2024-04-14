using System;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class GetOrdersByIdResponse : BaseResponse
{
    public GetOrdersByIdResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetOrdersByIdResponse()
    {
    }

    public OrderDetailDto SelectedOrder { get; set; }
}
