using System.Collections.Generic;

namespace BlazorShared.Models;

public class GetOrdersByIdResponse
{
    public OrderDetail SelectedOrder { get; set; } = new OrderDetail();
}
