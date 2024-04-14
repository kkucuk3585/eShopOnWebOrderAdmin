using System.Collections.Generic;

namespace BlazorShared.Models;

public class GetAllOrdersResponse
{
    public List<Orders> OrderList { get; set; } = new List<Orders>();
}
