using System;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class GetOrdersResponse : BaseResponse
{
    public GetOrdersResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetOrdersResponse()
    {
    }

    public List<OrdersDto> OrderList { get; set; } = new List<OrdersDto>();
}
