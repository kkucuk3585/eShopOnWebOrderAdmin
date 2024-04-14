using System;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class UpdateOrdersResponse : BaseResponse
{
    public UpdateOrdersResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateOrdersResponse()
    {
    }

    public OrdersDto SelectedOrder { get; set; }
}
