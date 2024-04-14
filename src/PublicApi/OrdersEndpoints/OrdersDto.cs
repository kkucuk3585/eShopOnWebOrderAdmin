using System;
namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class OrdersDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public int Status { get; set; }
}
