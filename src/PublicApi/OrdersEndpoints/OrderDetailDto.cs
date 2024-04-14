using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class OrderDetailDto : OrdersDto
{
    public List<OrderItemDto> OrderItems { get; set; } = new();
}
