using System.Collections.Generic;

namespace BlazorShared.Models;

public class OrderDetail : Orders
{
    public List<OrderItem> OrderItems { get; set; } = new();
}
