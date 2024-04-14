

namespace BlazorShared.Models;

public class OrderItem
{
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
    public string? PictureUrl { get; set; }
}
